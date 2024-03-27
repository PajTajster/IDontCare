using HarmonyLib;
using IDontCare.Filtering;
using IDontCare.Menu;
using System;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace IDontCare.Patches
{
    [HarmonyPatch]
    public static class CustomLogsPatches
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(TextObject), nameof(TextObject.ToString))]
        public static bool TextObjectToStringPrefix(TextObject __instance, ref string __result)
        {
            if (TextObject.IsNullOrEmpty(__instance) || ShouldBeFilteredOut(__instance))
            {
                __result = string.Empty;
                return false;
            }

            return true;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(InformationManager), nameof(InformationManager.DisplayMessage))]
        public static bool InformationManagerDisplayMessagePrefix(InformationMessage message) 
            => !string.IsNullOrEmpty(message?.Information);

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MBInformationManager), nameof(MBInformationManager.AddQuickInformation))]
        public static bool MBInformationManagerAddQuickInformationPrefix(TextObject message, int extraTimeInMs = 0, BasicCharacterObject announcerCharacter = null, string soundEventPath = "")
        {
            if (TextObject.IsNullOrEmpty(message) || ShouldBeFilteredOut(message))
                return false;

            return true;
        }

        private static bool ShouldBeFilteredOut(TextObject message)
            => string.IsNullOrEmpty(message?.Value) || // Because for some reason TextObject.IsNullOrEmpty doesn't catch that
               ((IDontCareMenu.Instance?.IsFilterEnabled ?? false) &&
                AdvancedFiltering.StringsToSearch.Any(x => message.Value.StartsWith(x, StringComparison.Ordinal)));
    }
}
