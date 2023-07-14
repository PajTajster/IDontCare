using Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class KingdomDestroyedLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var kingdomDestroyedLogEntry = logEntry as KingdomDestroyedLogEntry;

            var kingdom = GetLogEntryPrivateField(kingdomDestroyedLogEntry, "_kingdom") as Kingdom;

            return ShouldPlayerCare(IDontCareMenu.Instance.KingdomDestroyedFilterMode.SelectedIndex,
                                    kingdom?.MapFaction);
        }
    }
}
