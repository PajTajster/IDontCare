using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class GatherArmyLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var gatherArmyLogEntry = logEntry as GatherArmyLogEntry;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.GatherArmyFilterMode.GetFilterMode(),
                                                     gatherArmyLogEntry?.ArmyMapFaction);
        }
    }
}
