using IDontCare.Menu;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
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
