using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;
using IDontCare.Menu;
using IDontCare.Filtering.LogEntries;

namespace IDontCare.Patches
{
    [HarmonyPatch(typeof(CampaignInformationManager))]
    [HarmonyPatch("NewLogEntryAdded")]
    [HarmonyPatch(new Type[] { typeof(LogEntry) })]
    public static class LogEntriesPatch
    {
        public static bool Prefix(ref LogEntry log)
        {
            // Only IChatNotification log entries are actually displayed to player. Rest are saved in history.
            if (!(log is IChatNotification) || !IDontCareMenu.Instance.IsFilterEnabled) 
            {
                return true;
            }

            if (IDontCareMenu.Instance.IsBlockEverythingMode)
            {
                return false;
            }

            return ShouldPlayerCare(log);
        }

        private static bool ShouldPlayerCare(LogEntry logEntry)
        {
            var logEntryTypeName = logEntry?.GetType()?.Name;

            if (string.IsNullOrWhiteSpace(logEntryTypeName) 
                || !LogFilteringAssignments.FilteringLogEntriesDict.TryGetValue(logEntryTypeName, out var logEntryFilter))
            {
                return true;
            }

            var shouldPlayerCare = logEntryFilter.ShouldPlayerCare(logEntry);

            return shouldPlayerCare;
        }
    }
}
