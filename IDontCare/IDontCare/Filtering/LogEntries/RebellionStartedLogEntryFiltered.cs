using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class RebellionStartedLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var rebellionStartedLogEntry = logEntry as RebellionStartedLogEntry;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.RebellionStartedFilterMode.GetFilterMode(),
                                                     rebellionStartedLogEntry?.Settlement?.MapFaction);
        }
    }
}
