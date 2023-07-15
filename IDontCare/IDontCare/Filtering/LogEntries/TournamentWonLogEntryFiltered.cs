using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class TournamentWonLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var tournamentWonLogEntry = logEntry as TournamentWonLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = tournamentWonLogEntry?.Town?.MapFaction;
            factionsInvolved[1] = tournamentWonLogEntry?.Winner?.MapFaction;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.TournamentWonFilterMode.GetFilterMode(),
                                                     factionsInvolved);
        }
    }
}
