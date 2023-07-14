using IDontCare;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class GatherArmyLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var gatherArmyLogEntry = logEntry as GatherArmyLogEntry;

            return ShouldPlayerCare(IDontCareMenu.Instance.GatherArmyFilterMode.SelectedIndex,
                                    gatherArmyLogEntry?.ArmyMapFaction);
        }
    }
}
