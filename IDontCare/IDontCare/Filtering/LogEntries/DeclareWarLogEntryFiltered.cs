using IDontCare;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class DeclareWarLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var declareWarLogEntry = logEntry as DeclareWarLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = declareWarLogEntry?.Faction1;
            factionsInvolved[1] = declareWarLogEntry?.Faction2;

            return ShouldPlayerCare(IDontCareMenu.Instance.DeclareWarFilterMode.SelectedIndex,
                                    factionsInvolved);
        }
    }
}
