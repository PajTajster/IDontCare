using IDontCare;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class MercenaryClanChangedKingdomLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var mercenaryClanChangedKingdomLogEntry = logEntry as MercenaryClanChangedKingdomLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = mercenaryClanChangedKingdomLogEntry?.OldKingdom;
            factionsInvolved[1] = mercenaryClanChangedKingdomLogEntry?.NewKingdom;

            return ShouldPlayerCare(IDontCareMenu.Instance.MercenaryClanChangedKingdomFilterMode.SelectedIndex,
                                    factionsInvolved);
        }
    }
}
