using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace IDontCare
{
    [HarmonyPatch(typeof(LogEntry))]
    [HarmonyPatch("AddLogEntry")]
    [HarmonyPatch(new Type[] { typeof(LogEntry) })]
    public static class IDontCarePatch
    {
        public static bool Prefix(ref LogEntry logEntry)
        {
            //bool shouldPlayerCare = false;

            //// Put into list, to not repeat same damn code every switch case block
            //var factionsInvolved = new List<IFaction>();

            //switch (logEntry)
            //{
            //    case BesiegeSettlementLogEntry besiegeSettlement:
            //        factionsInvolved.Add(besiegeSettlement.BesiegerFaction);
            //        break;
            //    case ChangeCommonAreaOwnerLogEntry changeCommonAreaOwner:
            //        factionsInvolved.Add(changeCommonAreaOwner.NewOwner.MapFaction);
            //        break;
            //    case ChangeRomanticStateLogEntry changeRomanticState:
            //        factionsInvolved.Add(changeRomanticState.Hero1.MapFaction);
            //        factionsInvolved.Add(changeRomanticState.Hero2.MapFaction);
            //        break;
            //    case ChangeSettlementOwnerLogEntry changeSettlementOwner:
            //        factionsInvolved.Add(changeSettlementOwner.NewClan);
            //        factionsInvolved.Add(changeSettlementOwner.PreviousClan);
            //        break;
            //    case CharacterBecameFugitiveLogEntry characterBecameFugitive:
            //        factionsInvolved.Add(characterBecameFugitive.Hero.MapFaction);
            //        break;
            //    case CharacterBornLogEntry characterBorn:
            //        factionsInvolved.Add(characterBorn.BornCharacter.MapFaction);
            //        break;
            //    case CharacterInsultedLogEntry characterInsulted:
            //        factionsInvolved.Add(characterInsulted.Insultee.MapFaction);
            //        factionsInvolved.Add(characterInsulted.Insulter.MapFaction);
            //        break;
            //    case CharacterKilledLogEntry characterKilled:
            //        factionsInvolved.Add(characterKilled.Killer.MapFaction);
            //        factionsInvolved.Add(characterKilled.Victim.MapFaction);
            //        break;
            //    case CharacterMarriedLogEntry characterMarried:
            //        factionsInvolved.Add(characterMarried.MarriedHero.MapFaction);
            //        factionsInvolved.Add(characterMarried.MarriedTo.MapFaction);
            //        break;
            //    case ChildbirthLogEntry childbirth:
            //        factionsInvolved.Add(childbirth.Mother.MapFaction);
            //        break;
            //    case ClanChangeKingdomLogEntry clanChangeKingdom:
            //        factionsInvolved.Add(clanChangeKingdom.OldKingdom);
            //        factionsInvolved.Add(clanChangeKingdom.NewKingdom);
            //        break;
            //    case ClanLeaderChangedLogEntry clanLeaderChanged:
            //        factionsInvolved.Add(clanLeaderChanged.OldLeader.MapFaction);
            //        factionsInvolved.Add(clanLeaderChanged.NewLeader.MapFaction);
            //        break;
            //    case DeclareWarLogEntry declareWar:
            //        factionsInvolved.Add(declareWar.Faction1);
            //        factionsInvolved.Add(declareWar.Faction2);
            //        break;
            //    case DefeatCharacterLogEntry defeatCharacter:
            //        factionsInvolved.Add(defeatCharacter.WinnerHero.MapFaction);
            //        factionsInvolved.Add(defeatCharacter.LoserHero.MapFaction);
            //        break;
            //    case DestroyMobilePartyLogEntry destroyMobileParty:
            //        factionsInvolved.Add(destroyMobileParty.DestroyerPartyFaction);
            //        factionsInvolved.Add(destroyMobileParty.Faction);
            //        break;
            //    case EndCaptivityLogEntry endCaptivity:
            //        factionsInvolved.Add(endCaptivity.CapturerMapFaction);
            //        factionsInvolved.Add(endCaptivity.Prisoner.MapFaction);
            //        break;
            //    case GatherArmyLogEntry gatherArmy:
            //        factionsInvolved.Add(gatherArmy.ArmyMapFaction);
            //        break;
            //    case KingdomDecisionConcludedLogEntry kingdomDecisionConcluded:
            //        factionsInvolved.Add(kingdomDecisionConcluded.Kingdom);
            //        break;
            //    case MakePeaceLogEntry makePeace:
            //        factionsInvolved.Add(makePeace.Faction1);
            //        factionsInvolved.Add(makePeace.Faction2);
            //        break;
            //    case MercenaryClanChangedKingdomLogEntry mercenaryClanChangedKingdom:
            //        factionsInvolved.Add(mercenaryClanChangedKingdom.OldKingdom);
            //        factionsInvolved.Add(mercenaryClanChangedKingdom.NewKingdom);
            //        break;
            //    case PregnancyLogEntry pregnancy:
            //        factionsInvolved.Add(pregnancy.Mother.MapFaction);
            //        break;
            //    case RebellionStartedLogEntry rebellionStarted:
            //        factionsInvolved.Add(rebellionStarted.Settlement.MapFaction);
            //        break;
            //    case SettlementClaimedLogEntry settlementClaimed:
            //        factionsInvolved.Add(settlementClaimed.Claimant.MapFaction);
            //        break;
            //    case TakePrisonerLogEntry takePrisoner:
            //        factionsInvolved.Add(takePrisoner.CapturerHero.MapFaction);
            //        factionsInvolved.Add(takePrisoner.Prisoner.MapFaction);
            //        break;
            //    case TournamentWonLogEntry tournamentWon:
            //        factionsInvolved.Add(tournamentWon.Town.MapFaction);
            //        factionsInvolved.Add(tournamentWon.Winner.MapFaction);
            //        break;
            //    case VillageStateChangedLogEntry villageStateChanged:
            //        factionsInvolved.Add(villageStateChanged.RaiderPartyMapFaction);
            //        factionsInvolved.Add(villageStateChanged.Village.MarketTown.MapFaction);
            //        break;
            //    case BattleStartedLogEntry battleStarted:

            //        break;
            //    default:
            //        break;
            //}


            //shouldPlayerCare = IsAnyFactionAllyOrEnemyOfPlayer(factionsInvolved);

            //if (shouldPlayerCare)
            //{
            //    InformationManager.DisplayMessage(new InformationMessage($"DEBUG: BLOCKED MESSAGE of type {logEntry.GetType().Name}", Color.ConvertStringToColor("#FF1100")));
            //    StringBuilder sb = new StringBuilder();
            //    foreach (var faction in factionsInvolved)
            //    {
            //        sb.Append($"{faction.Name} ");
            //    }
            //    InformationManager.DisplayMessage(new InformationMessage($"DETECTED FACTIONS: {sb.ToString()}", Color.ConvertStringToColor("#FF1100")));
            //}

            return logEntry.GetImportanceForClan(Hero.MainHero.Clan) == PlayerCareImportanceLevel; ;
        }

        private static bool CheckByFactionsShouldPlayerCare(LogEntry logEntry)
        {
            bool shouldPlayerCare = false;

            // Put into list, to not repeat same damn code every switch case block
            var factionsInvolved = new List<IFaction>();

            switch (logEntry)
            {
                case BesiegeSettlementLogEntry besiegeSettlement:
                    factionsInvolved.Add(besiegeSettlement.BesiegerFaction);
                    break;
                case ChangeCommonAreaOwnerLogEntry changeCommonAreaOwner:
                    factionsInvolved.Add(changeCommonAreaOwner.NewOwner.MapFaction);
                    break;
                case ChangeRomanticStateLogEntry changeRomanticState:
                    factionsInvolved.Add(changeRomanticState.Hero1.MapFaction);
                    factionsInvolved.Add(changeRomanticState.Hero2.MapFaction);
                    break;
                case ChangeSettlementOwnerLogEntry changeSettlementOwner:
                    factionsInvolved.Add(changeSettlementOwner.NewClan);
                    factionsInvolved.Add(changeSettlementOwner.PreviousClan);
                    break;
                case CharacterBecameFugitiveLogEntry characterBecameFugitive:
                    factionsInvolved.Add(characterBecameFugitive.Hero.MapFaction);
                    break;
                case CharacterBornLogEntry characterBorn:
                    factionsInvolved.Add(characterBorn.BornCharacter.MapFaction);
                    break;
                case CharacterInsultedLogEntry characterInsulted:
                    factionsInvolved.Add(characterInsulted.Insultee.MapFaction);
                    factionsInvolved.Add(characterInsulted.Insulter.MapFaction);
                    break;
                case CharacterKilledLogEntry characterKilled:
                    factionsInvolved.Add(characterKilled.Killer.MapFaction);
                    factionsInvolved.Add(characterKilled.Victim.MapFaction);
                    break;
                case CharacterMarriedLogEntry characterMarried:
                    factionsInvolved.Add(characterMarried.MarriedHero.MapFaction);
                    factionsInvolved.Add(characterMarried.MarriedTo.MapFaction);
                    break;
                case ChildbirthLogEntry childbirth:
                    factionsInvolved.Add(childbirth.Mother.MapFaction);
                    break;
                case ClanChangeKingdomLogEntry clanChangeKingdom:
                    factionsInvolved.Add(clanChangeKingdom.OldKingdom);
                    factionsInvolved.Add(clanChangeKingdom.NewKingdom);
                    break;
                case ClanLeaderChangedLogEntry clanLeaderChanged:
                    factionsInvolved.Add(clanLeaderChanged.OldLeader.MapFaction);
                    factionsInvolved.Add(clanLeaderChanged.NewLeader.MapFaction);
                    break;
                case DeclareWarLogEntry declareWar:
                    factionsInvolved.Add(declareWar.Faction1);
                    factionsInvolved.Add(declareWar.Faction2);
                    break;
                case DefeatCharacterLogEntry defeatCharacter:
                    factionsInvolved.Add(defeatCharacter.WinnerHero.MapFaction);
                    factionsInvolved.Add(defeatCharacter.LoserHero.MapFaction);
                    break;
                case DestroyMobilePartyLogEntry destroyMobileParty:
                    factionsInvolved.Add(destroyMobileParty.DestroyerPartyFaction);
                    factionsInvolved.Add(destroyMobileParty.Faction);
                    break;
                case EndCaptivityLogEntry endCaptivity:
                    factionsInvolved.Add(endCaptivity.CapturerMapFaction);
                    factionsInvolved.Add(endCaptivity.Prisoner.MapFaction);
                    break;
                case GatherArmyLogEntry gatherArmy:
                    factionsInvolved.Add(gatherArmy.ArmyMapFaction);
                    break;
                case KingdomDecisionConcludedLogEntry kingdomDecisionConcluded:
                    factionsInvolved.Add(kingdomDecisionConcluded.Kingdom);
                    break;
                case MakePeaceLogEntry makePeace:
                    factionsInvolved.Add(makePeace.Faction1);
                    factionsInvolved.Add(makePeace.Faction2);
                    break;
                case MercenaryClanChangedKingdomLogEntry mercenaryClanChangedKingdom:
                    factionsInvolved.Add(mercenaryClanChangedKingdom.OldKingdom);
                    factionsInvolved.Add(mercenaryClanChangedKingdom.NewKingdom);
                    break;
                case PregnancyLogEntry pregnancy:
                    factionsInvolved.Add(pregnancy.Mother.MapFaction);
                    break;
                case RebellionStartedLogEntry rebellionStarted:
                    factionsInvolved.Add(rebellionStarted.Settlement.MapFaction);
                    break;
                case SettlementClaimedLogEntry settlementClaimed:
                    factionsInvolved.Add(settlementClaimed.Claimant.MapFaction);
                    break;
                case TakePrisonerLogEntry takePrisoner:
                    factionsInvolved.Add(takePrisoner.CapturerHero.MapFaction);
                    factionsInvolved.Add(takePrisoner.Prisoner.MapFaction);
                    break;
                case TournamentWonLogEntry tournamentWon:
                    factionsInvolved.Add(tournamentWon.Town.MapFaction);
                    factionsInvolved.Add(tournamentWon.Winner.MapFaction);
                    break;
                case VillageStateChangedLogEntry villageStateChanged:
                    factionsInvolved.Add(villageStateChanged.RaiderPartyMapFaction);
                    factionsInvolved.Add(villageStateChanged.Village.MarketTown.MapFaction);
                    break;
                case BattleStartedLogEntry battleStarted:
                    // No idea why those fields are private tbh
                    
                    break;
                default:
                    break;
            }


            shouldPlayerCare = IsAnyFactionAllyOrEnemyOfPlayer(factionsInvolved);

            if (shouldPlayerCare)
            {
                InformationManager.DisplayMessage(new InformationMessage($"DEBUG: BLOCKED MESSAGE of type {logEntry.GetType().Name}", Color.ConvertStringToColor("#FF1100")));
                StringBuilder sb = new StringBuilder();
                foreach (var faction in factionsInvolved)
                {
                    sb.Append($"{faction.Name} ");
                }
                InformationManager.DisplayMessage(new InformationMessage($"DETECTED FACTIONS: {sb.ToString()}", Color.ConvertStringToColor("#FF1100")));
            }

            return shouldPlayerCare;
        }

        private static bool CheckByImportanceShouldPlayerCare(LogEntry logEntry)
        {
            return logEntry.GetImportanceForClan(Hero.MainHero.Clan) == PlayerCareImportanceLevel;
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

                var factionsStance = playerFaction.GetStanceWith(faction);
                if (factionsStance.IsAllied || factionsStance.IsAtWar)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ShouldCheckByFactions = false;
        public static ImportanceEnum PlayerCareImportanceLevel = ImportanceEnum.MatterOfLifeAndDeath;
    }
}
