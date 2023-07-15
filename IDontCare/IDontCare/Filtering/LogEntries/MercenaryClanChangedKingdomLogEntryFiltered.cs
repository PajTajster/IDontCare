using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class MercenaryClanChangedKingdomLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var mercenaryClanChangedKingdomLogEntry = logEntry as MercenaryClanChangedKingdomLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = mercenaryClanChangedKingdomLogEntry?.OldKingdom;
            factionsInvolved[1] = mercenaryClanChangedKingdomLogEntry?.NewKingdom;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.MercenaryClanChangedKingdomFilterMode.GetFilterMode(),
                                                     factionsInvolved);
        }
    }
}
