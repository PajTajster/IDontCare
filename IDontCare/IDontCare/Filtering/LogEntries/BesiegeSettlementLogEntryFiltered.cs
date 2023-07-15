using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class BesiegeSettlementLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var besiegeSettlementLogEntry = logEntry as BesiegeSettlementLogEntry;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.BesiegedSettlementFilterMode.GetFilterMode(),
                                                     besiegeSettlementLogEntry?.BesiegerFaction);
        }
    }
}
