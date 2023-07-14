using Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class TournamentWonLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var tournamentWonLogEntry = logEntry as TournamentWonLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = tournamentWonLogEntry?.Town?.MapFaction;
            factionsInvolved[1] = tournamentWonLogEntry?.Winner?.MapFaction;

            return ShouldPlayerCare(IDontCareMenu.Instance.TournamentWonFilterMode.SelectedIndex,
                                    factionsInvolved);
        }
    }
}
