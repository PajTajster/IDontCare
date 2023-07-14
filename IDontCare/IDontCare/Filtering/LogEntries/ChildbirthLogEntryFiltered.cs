using IDontCare;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class ChildbirthLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var childbirthLogEntry = logEntry as ChildbirthLogEntry;

            var heroesInvolved = new Hero[2];
            heroesInvolved[0] = childbirthLogEntry?.Mother;
            heroesInvolved[1] = childbirthLogEntry?.NewbornHero;

            return ShouldPlayerCare(IDontCareMenu.Instance.ChildbirthFilterMode.SelectedIndex,
                                    heroesInvolved);
        }
    }
}
