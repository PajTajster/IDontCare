using IDontCare;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class EndCaptivityLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var endCaptivityLogEntry = logEntry as EndCaptivityLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = endCaptivityLogEntry?.CapturerMapFaction;
            factionsInvolved[1] = endCaptivityLogEntry?.Prisoner?.MapFaction;

            return ShouldPlayerCare(IDontCareMenu.Instance.EndCaptivityFilterMode.SelectedIndex,
                                    factionsInvolved);
        }
    }
}
