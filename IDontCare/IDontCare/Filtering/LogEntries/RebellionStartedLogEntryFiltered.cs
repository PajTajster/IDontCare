using IDontCare.Menu;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class RebellionStartedLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var rebellionStartedLogEntry = logEntry as RebellionStartedLogEntry;

            return ShouldPlayerCare(IDontCareMenu.Instance.RebellionStartedFilterMode.SelectedIndex,
                                rebellionStartedLogEntry?.Settlement?.MapFaction);
        }
    }
}
