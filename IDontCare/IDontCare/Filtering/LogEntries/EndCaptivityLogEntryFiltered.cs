using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class EndCaptivityLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var endCaptivityLogEntry = logEntry as EndCaptivityLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = endCaptivityLogEntry?.CapturerMapFaction;
            factionsInvolved[1] = endCaptivityLogEntry?.Prisoner?.MapFaction;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.EndCaptivityFilterMode.GetFilterMode(),
                                                     factionsInvolved);
        }
    }
}
