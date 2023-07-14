using IDontCare.Menu;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class CharacterBornLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var characterBornLogEntry = logEntry as CharacterBornLogEntry;

            return ShouldPlayerCare(IDontCareMenu.Instance.CharacterBornFilterMode.SelectedIndex,
                                    characterBornLogEntry?.BornCharacter);
        }
    }
}
