using Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class CharacterInsultedLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var characterInsultedLogEntry = logEntry as CharacterInsultedLogEntry;

            var heroesInvolved = new Hero[2];
            heroesInvolved[0] = characterInsultedLogEntry?.Insultee;
            heroesInvolved[1] = characterInsultedLogEntry?.Insulter;

            return ShouldPlayerCare(IDontCareMenu.Instance.CharacterInsultedFilterMode.SelectedIndex,
                                    heroesInvolved);
        }
    }
}
