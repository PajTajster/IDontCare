using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class PlayerBattleEndedLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var playerBattleEndedLogEntry = logEntry as PlayerBattleEndedLogEntry;

            var winningSideHero = FilteringMethods.GetLogEntryPrivateField(playerBattleEndedLogEntry, "_winnerSideHero") as Hero;
            var defeatedSideHero = FilteringMethods.GetLogEntryPrivateField(playerBattleEndedLogEntry, "_defeatedSideHero") as Hero;

            var heroesInvolved = new Hero[2];
            heroesInvolved[0] = winningSideHero;
            heroesInvolved[1] = defeatedSideHero;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.PlayerBattleEndedFilterMode.GetFilterMode(),
                                                     heroesInvolved);
        }
    }
}
