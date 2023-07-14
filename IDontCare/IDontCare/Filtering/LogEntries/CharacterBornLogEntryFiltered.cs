using IDontCare;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
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
