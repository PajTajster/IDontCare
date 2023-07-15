using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class SettlementClaimedLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var settlementClaimedLogEntry = logEntry as SettlementClaimedLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = settlementClaimedLogEntry?.Claimant?.MapFaction;
            factionsInvolved[1] = settlementClaimedLogEntry?.Settlement?.MapFaction;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.SettlementClaimedFilterMode.GetFilterMode(),
                                                     factionsInvolved);
        }
    }
}
