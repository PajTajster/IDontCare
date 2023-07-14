using IDontCare;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class KingdomDecisionConcludedLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var kingdomDecisionConcluded = logEntry as KingdomDecisionConcludedLogEntry;

            return ShouldPlayerCare(IDontCareMenu.Instance.KingdomDecisionConcludedFilterMode.SelectedIndex,
                                    kingdomDecisionConcluded?.Kingdom);
        }
    }
}
