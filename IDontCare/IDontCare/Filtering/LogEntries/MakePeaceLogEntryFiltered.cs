using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class MakePeaceLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var makePeaceLogEntry = logEntry as MakePeaceLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = makePeaceLogEntry?.Faction1;
            factionsInvolved[1] = makePeaceLogEntry?.Faction2;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.MakePeaceFilterMode.GetFilterMode(),
                                                     factionsInvolved);
        }
    }
}
