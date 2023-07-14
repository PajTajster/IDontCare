using IDontCare;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class SettlementClaimedLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var settlementClaimedLogEntry = logEntry as SettlementClaimedLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = settlementClaimedLogEntry?.Claimant?.MapFaction;
            factionsInvolved[1] = settlementClaimedLogEntry?.Settlement?.MapFaction;

            return ShouldPlayerCare(IDontCareMenu.Instance.SettlementClaimedFilterMode.SelectedIndex,
                                    factionsInvolved);
        }
    }
}
