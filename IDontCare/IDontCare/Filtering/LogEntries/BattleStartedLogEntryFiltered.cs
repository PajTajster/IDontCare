using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class BattleStartedLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var battleStartedLogEntry = logEntry as BattleStartedLogEntry;

            var attackerFaction = FilteringMethods.GetLogEntryPrivateField(battleStartedLogEntry,
                                                                           "_attackerFaction") as IFaction;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.BattleStartedFilterMode.GetFilterMode(),
                                                     attackerFaction);
        }
    }
}
