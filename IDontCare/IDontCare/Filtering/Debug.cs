using IDontCare.Constants;
using TaleWorlds.Library;

namespace IDontCare.Filtering
{
    internal static class Debug
    {
        public static void Log(bool wasBlocked, string eventName, InformationType informationType) 
            => InformationManager.DisplayMessage(new InformationMessage($"[I Don't Care DEBUG] Parsed message, {(wasBlocked ? "Blocked" : "Skipped")} event name: {eventName}, type: {informationType}"));
    }
}
