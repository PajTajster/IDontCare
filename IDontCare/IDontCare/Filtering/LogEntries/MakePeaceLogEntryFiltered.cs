using IDontCare;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class MakePeaceLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var makePeaceLogEntry = logEntry as MakePeaceLogEntry;

            var factionsInvolved = new IFaction[2];
            factionsInvolved[0] = makePeaceLogEntry?.Faction1;
            factionsInvolved[1] = makePeaceLogEntry?.Faction2;

            return ShouldPlayerCare(IDontCareMenu.Instance.MakePeaceFilterMode.SelectedIndex,
                                    factionsInvolved);
        }
    }
}
