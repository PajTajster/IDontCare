using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class CharacterInsultedLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var characterInsultedLogEntry = logEntry as CharacterInsultedLogEntry;

            var heroesInvolved = new Hero[2];
            heroesInvolved[0] = characterInsultedLogEntry?.Insultee;
            heroesInvolved[1] = characterInsultedLogEntry?.Insulter;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.CharacterInsultedFilterMode.GetFilterMode(),
                                                     heroesInvolved);
        }
    }
}
