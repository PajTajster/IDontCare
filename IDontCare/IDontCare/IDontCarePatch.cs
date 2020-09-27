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
        public static bool Prefix(ref LogEntry log)
        {
            bool shouldPlayerCare = false;

            // Only IChatNotification log entries are actually displayed to player. Rest are saved in history.
            if (!(log is IChatNotification)) 
            {
                return true;
            }

            if (!IDontCareMenu.IsBlockEverythingMode) 
            {
                shouldPlayerCare = CheckByFactionsShouldPlayerCare(log);
            }
            else
            {
                shouldPlayerCare = false;
            }

            return shouldPlayerCare;
        }

        private static bool CheckByFactionsShouldPlayerCare(LogEntry logEntry)
        {
            bool shouldPlayerCare = false;
            bool isFilterOverriden = false;

            var factionsInvolved = new List<IFaction>();

            switch (logEntry)
            {
                case ArmyDispersionLogEntry armyDispersion:
                    {
                        if (IDontCareMenu.ArmyDispersionFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                        {
                            var armyLeader = GetLogEntryPrivateField(armyDispersion, "_armyLeader") as CharacterObject;
                            factionsInvolved.Add(armyLeader?.HeroObject?.MapFaction);
                        }
                        else 
                        {
                            shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.ArmyDispersionFilterMode.SelectedIndex);
                            isFilterOverriden = true;
                        }
                    }
                    break;
                case BattleStartedLogEntry battleStarted:
                    {
                        if (IDontCareMenu.BattleStartedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                        {
                            var attackerFaction = GetLogEntryPrivateField(battleStarted, "_attackerFaction") as IFaction;
                            factionsInvolved.Add(attackerFaction);
                        }
                        else
                        {
                            shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.BattleStartedFilterMode.SelectedIndex);
                            isFilterOverriden = true;
                        }
                    }
                    break;
                case BesiegeSettlementLogEntry besiegeSettlement:
                    if (IDontCareMenu.BesiegedSettlementFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(besiegeSettlement?.BesiegerFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.BesiegedSettlementFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case ChangeCommonAreaOwnerLogEntry changeCommonAreaOwner:
                    if (IDontCareMenu.ChangeCommonAreaOwnerFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(changeCommonAreaOwner?.NewOwner?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.ChangeCommonAreaOwnerFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case CharacterBornLogEntry characterBorn:
                    if (IDontCareMenu.CharacterBornFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(characterBorn?.BornCharacter?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.CharacterBornFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case CharacterInsultedLogEntry characterInsulted:
                    if (IDontCareMenu.CharacterInsultedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(characterInsulted?.Insultee?.MapFaction);
                        factionsInvolved.Add(characterInsulted?.Insulter?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.CharacterInsultedFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case CharacterKilledLogEntry characterKilled:
                    if (IDontCareMenu.CharacterKilledFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(characterKilled?.Killer?.MapFaction);
                        factionsInvolved.Add(characterKilled?.Victim?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.CharacterKilledFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case CharacterMarriedLogEntry characterMarried:
                    if (IDontCareMenu.CharacterMarriedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(characterMarried?.MarriedHero?.MapFaction);
                        factionsInvolved.Add(characterMarried?.MarriedTo?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.CharacterMarriedFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case ChildbirthLogEntry childbirth:
                    if (IDontCareMenu.ChildbirthFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(childbirth?.Mother?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.ChildbirthFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case ClanChangeKingdomLogEntry clanChangeKingdom:
                    if (IDontCareMenu.ClanChangeKingdomFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(clanChangeKingdom?.OldKingdom);
                        factionsInvolved.Add(clanChangeKingdom?.NewKingdom);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.ClanChangeKingdomFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case DeclareWarLogEntry declareWar:
                    if (IDontCareMenu.DeclareWarFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(declareWar?.Faction1);
                        factionsInvolved.Add(declareWar?.Faction2);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.DeclareWarFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case EndCaptivityLogEntry endCaptivity:
                    if (IDontCareMenu.EndCaptivityFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(endCaptivity?.CapturerMapFaction);
                        factionsInvolved.Add(endCaptivity?.Prisoner?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.EndCaptivityFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case GatherArmyLogEntry gatherArmy:
                    if (IDontCareMenu.GatherArmyFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(gatherArmy?.ArmyMapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.GatherArmyFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case KingdomDecisionConcludedLogEntry kingdomDecisionConcluded:
                    if (IDontCareMenu.KingdomDecisionConcludedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(kingdomDecisionConcluded?.Kingdom);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.KingdomDecisionConcludedFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case MakePeaceLogEntry makePeace:
                    if (IDontCareMenu.MakePeaceFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(makePeace?.Faction1);
                        factionsInvolved.Add(makePeace?.Faction2);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.MakePeaceFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case MercenaryClanChangedKingdomLogEntry mercenaryClanChangedKingdom:
                    if (IDontCareMenu.MercenaryClanChangedKingdomFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(mercenaryClanChangedKingdom?.OldKingdom);
                        factionsInvolved.Add(mercenaryClanChangedKingdom?.NewKingdom);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.MercenaryClanChangedKingdomFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case PregnancyLogEntry pregnancy:
                    if (IDontCareMenu.PregnancyFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(pregnancy?.Mother?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.PregnancyFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case RebellionStartedLogEntry rebellionStarted:
                    if (IDontCareMenu.RebellionStartedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(rebellionStarted?.Settlement?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.RebellionStartedFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case SettlementClaimedLogEntry settlementClaimed:
                    if (IDontCareMenu.SettlementClaimedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(settlementClaimed?.Claimant?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.SettlementClaimedFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case TakePrisonerLogEntry takePrisoner:
                    if (IDontCareMenu.TakePrisonerFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(takePrisoner?.CapturerHero?.MapFaction);
                        factionsInvolved.Add(takePrisoner?.Prisoner?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.TakePrisonerFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case TournamentWonLogEntry tournamentWon:
                    if (IDontCareMenu.TournamentWonFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(tournamentWon?.Town?.MapFaction);
                        factionsInvolved.Add(tournamentWon?.Winner?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.TournamentWonFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                default:
                    break;
            }

            if (!isFilterOverriden)
            {
                shouldPlayerCare = IsAnyFactionAllyOrEnemyOfPlayer(factionsInvolved);
            }

            if (IDontCareMenu.IsDebugMode && (!shouldPlayerCare || isFilterOverriden)) 
            {
                DebugLog(logEntry);
            }

            return shouldPlayerCare;
        }

        private static bool SwitchShouldPlayerCareDependingOnFilterMode(int filterModeSelectedIndex)
        {
            if (filterModeSelectedIndex == IDontCareMenu.FILTERMODE_FILTER_ALL)
            {
                return false;
            }
            if (filterModeSelectedIndex == IDontCareMenu.FILTERMODE_FILTER_NOTHING)
            {
                return true;
            }

            // Shouldn't happen
            return false;
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
