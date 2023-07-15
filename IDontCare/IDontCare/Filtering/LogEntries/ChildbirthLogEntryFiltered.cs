using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class ChildbirthLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var childbirthLogEntry = logEntry as ChildbirthLogEntry;

            var heroesInvolved = new Hero[2];
            heroesInvolved[0] = childbirthLogEntry?.Mother;
            heroesInvolved[1] = childbirthLogEntry?.NewbornHero;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.ChildbirthFilterMode.GetFilterMode(),
                                                     heroesInvolved);
        }
    }
}
