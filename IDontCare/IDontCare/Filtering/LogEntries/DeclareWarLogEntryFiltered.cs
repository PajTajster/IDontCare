using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class DeclareWarLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var declareWarLogEntry = logEntry as DeclareWarLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = declareWarLogEntry?.Faction1;
            factionsInvolved[1] = declareWarLogEntry?.Faction2;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.DeclareWarFilterMode.GetFilterMode(),
                                                     factionsInvolved);
        }
    }
}
