using Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class TakePrisonerLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var takePrisonerLogEntry = logEntry as TakePrisonerLogEntry;

            var heroesInvolved = new Hero[2];
            heroesInvolved[0] = takePrisonerLogEntry?.CapturerHero;
            heroesInvolved[1] = takePrisonerLogEntry?.Prisoner;

            return ShouldPlayerCare(IDontCareMenu.Instance.TakePrisonerFilterMode.SelectedIndex,
                                    heroesInvolved);
        }
    }
}
