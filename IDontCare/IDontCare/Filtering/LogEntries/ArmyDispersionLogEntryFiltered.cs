using IDontCare.Extensions;
using IDontCare.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal class ArmyDispersionLogEntryFiltered : ILogEntryFilter
    {
        public bool ShouldPlayerCare(LogEntry logEntry)
        {
            var armyDispersionLogEntry = logEntry as ArmyDispersionLogEntry;
            
            var armyLeader = FilteringMethods.GetLogEntryPrivateField(armyDispersionLogEntry, "_armyLeader") as CharacterObject;

            return FilteringMethods.ShouldPlayerCare(IDontCareMenu.Instance.ArmyDispersionFilterMode.GetFilterMode(),
                                                     armyLeader?.HeroObject);
        }
    }
}
