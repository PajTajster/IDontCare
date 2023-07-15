using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class TakePrisonerLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var takePrisonerLogEntry = logEntry as TakePrisonerLogEntry;

            var heroesInvolved = new Hero[2];
            heroesInvolved[0] = takePrisonerLogEntry?.CapturerHero;
            heroesInvolved[1] = takePrisonerLogEntry?.Prisoner;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.TakePrisonerFilterMode.GetFilterMode(),
                                                     heroesInvolved);
        }
    }
}
