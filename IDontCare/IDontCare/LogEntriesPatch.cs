using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.Core;

namespace IDontCare
{
    [HarmonyPatch(typeof(CampaignInformationManager))]
    [HarmonyPatch("AddLogEntry")]
    [HarmonyPatch(new Type[] { typeof(LogEntry) })]
    public static class LogEntriesPatch
    {
        public static bool Prefix(ref LogEntry log)
        {
            bool shouldPlayerCare = false;

            // Only IChatNotification log entries are actually displayed to player. Rest are saved in history.
            if (!(log is IChatNotification) || !IDontCareMenu.Instance.IsFilterEnabled) 
            {
                return true;
            }

            if (!IDontCareMenu.Instance.IsBlockEverythingMode) 
            {
                shouldPlayerCare = CheckByFactionsShouldPlayerCare(log);
            }
            else
            {
                if (IDontCareMenu.Instance.IsDebugMode)
                {
                    DebugLog(log);
                }
                return false;
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
                        if (IDontCareMenu.Instance.ArmyDispersionFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                        {
                            var armyLeader = GetLogEntryPrivateField(armyDispersion, "_armyLeader") as CharacterObject;
                            factionsInvolved.Add(armyLeader?.HeroObject?.MapFaction);
                        }
                        else 
                        {
                            shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.ArmyDispersionFilterMode.SelectedIndex);
                            isFilterOverriden = true;
                        }
                    }
                    break;
                case BattleStartedLogEntry battleStarted:
                    {
                        if (IDontCareMenu.Instance.BattleStartedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                        {
                            var attackerFaction = GetLogEntryPrivateField(battleStarted, "_attackerFaction") as IFaction;
                            factionsInvolved.Add(attackerFaction);
                        }
                        else
                        {
                            shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.BattleStartedFilterMode.SelectedIndex);
                            isFilterOverriden = true;
                        }
                    }
                    break;
                case BesiegeSettlementLogEntry besiegeSettlement:
                    if (IDontCareMenu.Instance.BesiegedSettlementFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(besiegeSettlement?.BesiegerFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.BesiegedSettlementFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case ChangeCommonAreaOwnerLogEntry changeCommonAreaOwner:
                    if (IDontCareMenu.Instance.ChangeCommonAreaOwnerFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(changeCommonAreaOwner?.NewOwner?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.ChangeCommonAreaOwnerFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case CharacterBornLogEntry characterBorn:
                    if (IDontCareMenu.Instance.CharacterBornFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(characterBorn?.BornCharacter?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.CharacterBornFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case CharacterInsultedLogEntry characterInsulted:
                    if (IDontCareMenu.Instance.CharacterInsultedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(characterInsulted?.Insultee?.MapFaction);
                        factionsInvolved.Add(characterInsulted?.Insulter?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.CharacterInsultedFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case CharacterKilledLogEntry characterKilled:
                    if (IDontCareMenu.Instance.CharacterKilledFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(characterKilled?.Killer?.MapFaction);
                        factionsInvolved.Add(characterKilled?.Victim?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.CharacterKilledFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case CharacterMarriedLogEntry characterMarried:
                    if (IDontCareMenu.Instance.CharacterMarriedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(characterMarried?.MarriedHero?.MapFaction);
                        factionsInvolved.Add(characterMarried?.MarriedTo?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.CharacterMarriedFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case ChildbirthLogEntry childbirth:
                    if (IDontCareMenu.Instance.ChildbirthFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(childbirth?.Mother?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.ChildbirthFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case ClanChangeKingdomLogEntry clanChangeKingdom:
                    if (IDontCareMenu.Instance.ClanChangeKingdomFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(clanChangeKingdom?.OldKingdom);
                        factionsInvolved.Add(clanChangeKingdom?.NewKingdom);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.ClanChangeKingdomFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case DeclareWarLogEntry declareWar:
                    if (IDontCareMenu.Instance.DeclareWarFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(declareWar?.Faction1);
                        factionsInvolved.Add(declareWar?.Faction2);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.DeclareWarFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case EndCaptivityLogEntry endCaptivity:
                    if (IDontCareMenu.Instance.EndCaptivityFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(endCaptivity?.CapturerMapFaction);
                        factionsInvolved.Add(endCaptivity?.Prisoner?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.EndCaptivityFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case GatherArmyLogEntry gatherArmy:
                    if (IDontCareMenu.Instance.GatherArmyFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(gatherArmy?.ArmyMapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.GatherArmyFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case KingdomDecisionConcludedLogEntry kingdomDecisionConcluded:
                    if (IDontCareMenu.Instance.KingdomDecisionConcludedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(kingdomDecisionConcluded?.Kingdom);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.KingdomDecisionConcludedFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case KingdomDestroyedLogEntry kingdomDestroyed:
                    if (IDontCareMenu.Instance.KingdomDestroyedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        var kingdom = GetLogEntryPrivateField(kingdomDestroyed, "_kingdom") as Kingdom;
                        factionsInvolved.Add(kingdom?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.KingdomDecisionConcludedFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case MakePeaceLogEntry makePeace:
                    if (IDontCareMenu.Instance.MakePeaceFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(makePeace?.Faction1);
                        factionsInvolved.Add(makePeace?.Faction2);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.MakePeaceFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case MercenaryClanChangedKingdomLogEntry mercenaryClanChangedKingdom:
                    if (IDontCareMenu.Instance.MercenaryClanChangedKingdomFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(mercenaryClanChangedKingdom?.OldKingdom);
                        factionsInvolved.Add(mercenaryClanChangedKingdom?.NewKingdom);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.MercenaryClanChangedKingdomFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case PlayerBattleEndedLogEntry playerBattleEnded:
                    if (IDontCareMenu.Instance.PlayerBattleEndedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        var winningSideHero = GetLogEntryPrivateField(playerBattleEnded, "_winnerSideHero") as Hero;
                        var defeatedSideHero = GetLogEntryPrivateField(playerBattleEnded, "_defeatedSideHero") as Hero;

                        factionsInvolved.Add(winningSideHero?.MapFaction);
                        factionsInvolved.Add(defeatedSideHero?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.MercenaryClanChangedKingdomFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case PregnancyLogEntry pregnancy:
                    if (IDontCareMenu.Instance.PregnancyFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(pregnancy?.Mother?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.PregnancyFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case RebellionStartedLogEntry rebellionStarted:
                    if (IDontCareMenu.Instance.RebellionStartedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(rebellionStarted?.Settlement?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.RebellionStartedFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case SettlementClaimedLogEntry settlementClaimed:
                    if (IDontCareMenu.Instance.SettlementClaimedFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(settlementClaimed?.Claimant?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.SettlementClaimedFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case TakePrisonerLogEntry takePrisoner:
                    if (IDontCareMenu.Instance.TakePrisonerFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(takePrisoner?.CapturerHero?.MapFaction);
                        factionsInvolved.Add(takePrisoner?.Prisoner?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.TakePrisonerFilterMode.SelectedIndex);
                        isFilterOverriden = true;
                    }
                    break;
                case TournamentWonLogEntry tournamentWon:
                    if (IDontCareMenu.Instance.TournamentWonFilterMode.SelectedIndex == IDontCareMenu.FILTERMODE_DEFAULT)
                    {
                        factionsInvolved.Add(tournamentWon?.Town?.MapFaction);
                        factionsInvolved.Add(tournamentWon?.Winner?.MapFaction);
                    }
                    else
                    {
                        shouldPlayerCare = SwitchShouldPlayerCareDependingOnFilterMode(IDontCareMenu.Instance.TournamentWonFilterMode.SelectedIndex);
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

            if (IDontCareMenu.Instance.IsDebugMode && (!shouldPlayerCare || isFilterOverriden)) 
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
            var type = instance?.GetType();
            if (type is null)
            {
                return null;
            }

            var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var field = type.GetField(fieldName, bindFlags);
            return field?.GetValue(instance);
        }
    }
}
