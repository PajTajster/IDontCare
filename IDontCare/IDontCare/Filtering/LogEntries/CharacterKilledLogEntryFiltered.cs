using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class CharacterKilledLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var characterKilledLogEntry = logEntry as CharacterKilledLogEntry;

            var heroesInvolved = new Hero[2];
            heroesInvolved[0] = characterKilledLogEntry?.Killer;
            heroesInvolved[1] = characterKilledLogEntry?.Victim;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.CharacterKilledFilterMode.GetFilterMode(),
                                                     heroesInvolved);
        }
    }
}
