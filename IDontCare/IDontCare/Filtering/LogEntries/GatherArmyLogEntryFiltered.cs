using IDontCare.Menu;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
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
