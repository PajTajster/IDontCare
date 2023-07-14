using IDontCare;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class PregnancyLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var pregnancyLogEntry = logEntry as PregnancyLogEntry;

            return ShouldPlayerCare(IDontCareMenu.Instance.PregnancyFilterMode.SelectedIndex,
                                    pregnancyLogEntry?.Mother);
        }
    }
}
