using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class CharacterMarriedLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var characterMarriedLogEntry = logEntry as CharacterMarriedLogEntry;

            var heroesInvolved = new Hero[2];
            heroesInvolved[0] = characterMarriedLogEntry?.MarriedHero;
            heroesInvolved[1] = characterMarriedLogEntry?.MarriedTo;

            return ShouldPlayerCare(IDontCareMenu.Instance.CharacterMarriedFilterMode.SelectedIndex,
                                    heroesInvolved);
        }
    }
}
