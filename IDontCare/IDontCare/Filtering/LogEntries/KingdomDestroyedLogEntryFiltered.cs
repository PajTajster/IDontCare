using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class KingdomDestroyedLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var kingdomDestroyedLogEntry = logEntry as KingdomDestroyedLogEntry;

            var kingdom = FilteringMethods.GetLogEntryPrivateField(kingdomDestroyedLogEntry, "_kingdom") as Kingdom;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.KingdomDestroyedFilterMode.GetFilterMode(),
                                                     kingdom?.MapFaction);
        }
    }
}
