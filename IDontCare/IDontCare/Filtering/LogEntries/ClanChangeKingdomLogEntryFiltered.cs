using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class ClanChangeKingdomLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var clanChangeKingdomLogEntry = logEntry as ClanChangeKingdomLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = clanChangeKingdomLogEntry?.OldKingdom;
            factionsInvolved[1] = clanChangeKingdomLogEntry?.NewKingdom;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.ClanChangeKingdomFilterMode.GetFilterMode(),
                                                     factionsInvolved);
        }
    }
}
