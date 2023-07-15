using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class KingdomDecisionConcludedLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var kingdomDecisionConcluded = logEntry as KingdomDecisionConcludedLogEntry;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.KingdomDecisionConcludedFilterMode.GetFilterMode(),
                                                     kingdomDecisionConcluded?.Kingdom);
        }
    }
}
