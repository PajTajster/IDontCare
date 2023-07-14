using IDontCare;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal class ArmyDispersionLogEntryFiltered : FilteredLogBase
    {
        public override bool ShouldPlayerCare(LogEntry logEntry)
        {
            var armyDispersionLogEntry = logEntry as ArmyDispersionLogEntry;
            
            var armyLeader = GetLogEntryPrivateField(armyDispersionLogEntry, "_armyLeader") as CharacterObject;

            return ShouldPlayerCare(IDontCareMenu.Instance.ArmyDispersionFilterMode.SelectedIndex, armyLeader?.HeroObject);
        }
    }
}
