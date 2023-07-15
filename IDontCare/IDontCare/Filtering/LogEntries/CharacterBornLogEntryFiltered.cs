using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class CharacterBornLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var characterBornLogEntry = logEntry as CharacterBornLogEntry;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.CharacterBornFilterMode.GetFilterMode(),
                                                     characterBornLogEntry?.BornCharacter);
        }
    }
}
