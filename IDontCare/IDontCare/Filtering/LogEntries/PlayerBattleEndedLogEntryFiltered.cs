using Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class PlayerBattleEndedLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var playerBattleEndedLogEntry = logEntry as PlayerBattleEndedLogEntry;

            var winningSideHero = GetLogEntryPrivateField(playerBattleEndedLogEntry, "_winnerSideHero") as Hero;
            var defeatedSideHero = GetLogEntryPrivateField(playerBattleEndedLogEntry, "_defeatedSideHero") as Hero;

            var heroesInvolved = new Hero[2];
            heroesInvolved[0] = winningSideHero;
            heroesInvolved[1] = defeatedSideHero;

            return ShouldPlayerCare(IDontCareMenu.Instance.PlayerBattleEndedFilterMode.SelectedIndex,
                                    heroesInvolved);
        }
    }
}
