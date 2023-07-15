using TaleWorlds.CampaignSystem.LogEntries;

namespace IDontCare.Filtering.LogEntries
{
    internal interface ILogEntryFilter
    {
        bool ShouldPlayerCare(LogEntry logEntry);
    }
}