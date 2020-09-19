using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace IDontCare
{
    [HarmonyPatch(typeof(CampaignInformationManager))]
    [HarmonyPatch("AddLogEntry")]
    [HarmonyPatch(new Type[] { typeof(LogEntry) })]
    public static class IDontCarePatch
    {
        public static bool IsDebugLogging = false;
        public static bool ShouldCheckByFactions = true;
        public static ImportanceEnum PlayerCareImportanceLevel = ImportanceEnum.Important;

        public static bool Prefix(ref LogEntry log)
        {
            bool shouldPlayerCare = false;

            // Only IChatNotification log entries are actually displayed to player. Rest are saved in history.
            if (!(log is IChatNotification)) 
            {
                return true;
            }

            if (ShouldCheckByFactions)
            {
                shouldPlayerCare = CheckByFactionsShouldPlayerCare(log);
            }
            else
            {
                shouldPlayerCare = CheckByImportanceShouldPlayerCare(log);
            }

            return shouldPlayerCare;
        }

        private static bool CheckByFactionsShouldPlayerCare(LogEntry logEntry)
        {
            bool shouldPlayerCare = false;

            // Put into list, to not repeat same damn code every switch case block
            var factionsInvolved = new List<IFaction>();

            switch (logEntry)
            {
                case ArmyDispersionLogEntry armyDispersion:
                    {
                        var armyLeader = GetLogEntryPrivateField(armyDispersion, "_armyLeader") as CharacterObject;
                        factionsInvolved.Add(armyLeader?.HeroObject?.MapFaction);
                    }
                    break;
                case BattleStartedLogEntry battleStarted:
                    {
                        var attackerFaction = GetLogEntryPrivateField(battleStarted, "_attackerFaction") as IFaction;
                        factionsInvolved.Add(attackerFaction);
                    }
                    break;
                case BesiegeSettlementLogEntry besiegeSettlement:
                    factionsInvolved.Add(besiegeSettlement?.BesiegerFaction);
                    break;
                case ChangeCommonAreaOwnerLogEntry changeCommonAreaOwner:
                    factionsInvolved.Add(changeCommonAreaOwner?.NewOwner?.MapFaction);
                    break;
                case CharacterBornLogEntry characterBorn:
                    factionsInvolved.Add(characterBorn?.BornCharacter?.MapFaction);
                    break;
                case CharacterInsultedLogEntry characterInsulted:
                    factionsInvolved.Add(characterInsulted?.Insultee?.MapFaction);
                    factionsInvolved.Add(characterInsulted?.Insulter?.MapFaction);
                    break;
                case CharacterKilledLogEntry characterKilled:
                    factionsInvolved.Add(characterKilled?.Killer?.MapFaction);
                    factionsInvolved.Add(characterKilled?.Victim?.MapFaction);
                    break;
                case CharacterMarriedLogEntry characterMarried:
                    factionsInvolved.Add(characterMarried?.MarriedHero?.MapFaction);
                    factionsInvolved.Add(characterMarried?.MarriedTo?.MapFaction);
                    break;
                case ChildbirthLogEntry childbirth:
                    factionsInvolved.Add(childbirth?.Mother?.MapFaction);
                    break;
                case ClanChangeKingdomLogEntry clanChangeKingdom:
                    factionsInvolved.Add(clanChangeKingdom?.OldKingdom);
                    factionsInvolved.Add(clanChangeKingdom?.NewKingdom);
                    break;
                case DeclareWarLogEntry declareWar:
                    factionsInvolved.Add(declareWar?.Faction1);
                    factionsInvolved.Add(declareWar?.Faction2);
                    break;
                case EndCaptivityLogEntry endCaptivity:
                    factionsInvolved.Add(endCaptivity?.CapturerMapFaction);
                    factionsInvolved.Add(endCaptivity?.Prisoner?.MapFaction);
                    break;
                case GatherArmyLogEntry gatherArmy:
                    factionsInvolved.Add(gatherArmy?.ArmyMapFaction);
                    break;
                case KingdomDecisionConcludedLogEntry kingdomDecisionConcluded:
                    factionsInvolved.Add(kingdomDecisionConcluded?.Kingdom);
                    break;
                case MakePeaceLogEntry makePeace:
                    factionsInvolved.Add(makePeace?.Faction1);
                    factionsInvolved.Add(makePeace?.Faction2);
                    break;
                case MercenaryClanChangedKingdomLogEntry mercenaryClanChangedKingdom:
                    factionsInvolved.Add(mercenaryClanChangedKingdom?.OldKingdom);
                    factionsInvolved.Add(mercenaryClanChangedKingdom?.NewKingdom);
                    break;
                case PregnancyLogEntry pregnancy:
                    factionsInvolved.Add(pregnancy?.Mother?.MapFaction);
                    break;
                case RebellionStartedLogEntry rebellionStarted:
                    factionsInvolved.Add(rebellionStarted?.Settlement?.MapFaction);
                    break;
                case SettlementClaimedLogEntry settlementClaimed:
                    factionsInvolved.Add(settlementClaimed?.Claimant?.MapFaction);
                    break;
                case TakePrisonerLogEntry takePrisoner:
                    factionsInvolved.Add(takePrisoner?.CapturerHero?.MapFaction);
                    factionsInvolved.Add(takePrisoner?.Prisoner?.MapFaction);
                    break;
                case TournamentWonLogEntry tournamentWon:
                    factionsInvolved.Add(tournamentWon?.Town?.MapFaction);
                    factionsInvolved.Add(tournamentWon?.Winner?.MapFaction);
                    break;
                case VillageStateChangedLogEntry villageStateChanged:
                    factionsInvolved.Add(villageStateChanged?.RaiderPartyMapFaction);
                    factionsInvolved.Add(villageStateChanged?.Village?.MarketTown?.MapFaction);
                    break;
                default:
                    break;
            }

            shouldPlayerCare = IsAnyFactionAllyOrEnemyOfPlayer(factionsInvolved);

            if (IsDebugLogging && !shouldPlayerCare)
            {
                DebugLog(logEntry);
            }

            return shouldPlayerCare;
        }

        private static bool CheckByImportanceShouldPlayerCare(LogEntry logEntry)
        {
            var shouldPlayerCare = logEntry.GetImportanceForClan(Hero.MainHero.Clan) == PlayerCareImportanceLevel;

            if (IsDebugLogging && !shouldPlayerCare)
            {
                DebugLog(logEntry);
            }

            return shouldPlayerCare;
        }

        private static void DebugLog(LogEntry logEntry)
        {
            InformationManager.DisplayMessage(new InformationMessage($"Blocked message! Message type: {logEntry.GetType()?.Name}"));
        }

        private static bool IsAnyFactionAllyOrEnemyOfPlayer(IList<IFaction> factions)
        {
            var playerFaction = Hero.MainHero.MapFaction;
            foreach (var faction in factions)
            {
                if (faction is null)
                {
                    continue;
                }

                // Faction is treated as neutral to itself, e.g.: Vlandia to Vlandia stance is Neutral
                if (playerFaction?.Name == faction?.Name)
                {
                    return true;
                }
                else
                {
                    var factionsStance = playerFaction.GetStanceWith(faction);
                    if (factionsStance.IsAllied || factionsStance.IsAtWar)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // I know it's ugly to get privates, but I need them for filtering
        internal static object GetLogEntryPrivateField(object instance, string fieldName)
        {
            var type = instance.GetType();

            var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var field = type.GetField(fieldName, bindFlags);
            return field.GetValue(instance);
        }
    }
}
