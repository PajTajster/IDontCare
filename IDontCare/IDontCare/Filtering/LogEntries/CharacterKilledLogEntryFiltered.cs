using IDontCare;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class CharacterKilledLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var characterKilledLogEntry = logEntry as CharacterKilledLogEntry;

            var heroesInvolved = new Hero[2];
            heroesInvolved[0] = characterKilledLogEntry?.Killer;
            heroesInvolved[1] = characterKilledLogEntry?.Victim;

            return ShouldPlayerCare(IDontCareMenu.Instance.CharacterKilledFilterMode.SelectedIndex,
                                    heroesInvolved);
        }
    }
}
