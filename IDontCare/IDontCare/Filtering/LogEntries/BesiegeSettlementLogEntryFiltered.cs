using IDontCare.Menu;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class BesiegeSettlementLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var besiegeSettlementLogEntry = logEntry as BesiegeSettlementLogEntry;

            return ShouldPlayerCare(IDontCareMenu.Instance.BesiegedSettlementFilterMode.SelectedIndex,
                                    besiegeSettlementLogEntry?.BesiegerFaction);
        }
    }
}
