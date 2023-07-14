using System.Collections.Generic;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal static class LogFilteringAssignments
    {
        internal static readonly Dictionary<string, FilteredLogBase> FilteringLogEntriesDict = new Dictionary<string, FilteredLogBase>()
        {
            { typeof(ArmyDispersionLogEntry).Name, new ArmyDispersionLogEntryFiltered() },
            { typeof(BattleStartedLogEntry).Name, new BattleStartedLogEntryFiltered() },
            { typeof(BesiegeSettlementLogEntry).Name, new BesiegeSettlementLogEntryFiltered() },
            { typeof(CharacterBornLogEntry).Name, new CharacterBornLogEntryFiltered() },
            { typeof(CharacterInsultedLogEntry).Name, new CharacterInsultedLogEntryFiltered() },
            { typeof(CharacterKilledLogEntry).Name, new CharacterKilledLogEntryFiltered() },
            { typeof(CharacterMarriedLogEntry).Name, new CharacterMarriedLogEntryFiltered() },
            { typeof(ChildbirthLogEntry).Name, new ChildbirthLogEntryFiltered() },
            { typeof(ClanChangeKingdomLogEntry).Name, new ClanChangeKingdomLogEntryFiltered() },
            { typeof(DeclareWarLogEntry).Name, new DeclareWarLogEntryFiltered() },
            { typeof(EndCaptivityLogEntry).Name, new EndCaptivityLogEntryFiltered() },
            { typeof(GatherArmyLogEntry).Name, new GatherArmyLogEntryFiltered() },
            { typeof(KingdomDecisionConcludedLogEntry).Name, new KingdomDecisionConcludedLogEntryFiltered() },
            { typeof(KingdomDestroyedLogEntry).Name, new KingdomDestroyedLogEntryFiltered() },
            { typeof(MakePeaceLogEntry).Name, new MakePeaceLogEntryFiltered() },
            { typeof(MercenaryClanChangedKingdomLogEntry).Name, new MercenaryClanChangedKingdomLogEntryFiltered() },
            { typeof(PlayerBattleEndedLogEntry).Name, new PlayerBattleEndedLogEntryFiltered() },
            { typeof(PregnancyLogEntry).Name, new PregnancyLogEntryFiltered() },
            { typeof(RebellionStartedLogEntry).Name, new RebellionStartedLogEntryFiltered() },
            { typeof(SettlementClaimedLogEntry).Name, new SettlementClaimedLogEntryFiltered() },
            { typeof(TakePrisonerLogEntry).Name, new TakePrisonerLogEntryFiltered() },
            { typeof(TournamentWonLogEntry).Name, new TournamentWonLogEntryFiltered() }
        };
    }
}
