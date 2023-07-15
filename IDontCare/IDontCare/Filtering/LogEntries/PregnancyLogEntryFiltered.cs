using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class PregnancyLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var pregnancyLogEntry = logEntry as PregnancyLogEntry;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.PregnancyFilterMode.GetFilterMode(),
                                                     pregnancyLogEntry?.Mother);
        }
    }
}
