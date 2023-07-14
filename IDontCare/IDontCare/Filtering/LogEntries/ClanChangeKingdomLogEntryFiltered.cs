using IDontCare;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class ClanChangeKingdomLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var clanChangeKingdomLogEntry = logEntry as ClanChangeKingdomLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = clanChangeKingdomLogEntry?.OldKingdom;
            factionsInvolved[1] = clanChangeKingdomLogEntry?.NewKingdom;

            return ShouldPlayerCare(IDontCareMenu.Instance.ClanChangeKingdomFilterMode.SelectedIndex,
                                    factionsInvolved);
        }
    }
}
