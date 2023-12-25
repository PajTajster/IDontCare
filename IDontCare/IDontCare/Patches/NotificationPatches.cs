using System;
using IDontCare.Filtering;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using IDontCare.Menu;
using IDontCare.Extensions;

namespace IDontCare.Patches
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(CampaignEvents))]
    public static class NotificationPatches
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(CampaignEvents.OnHeroLevelledUp))]
        [HarmonyPatch(new Type[] { typeof(Hero), typeof(bool) })]
        public static bool OnHeroLevelledUpPrefix(Hero hero, ref bool shouldNotify)
        {
            if (!shouldNotify || !ShouldNotifyByModSettings())
                return true;

            var filterModeIndex = IDontCareMenu.Instance.OnHeroLevelledUpFilterMode.GetFilterMode();

            shouldNotify = FilteringMethods.ShouldPlayerCare(filterModeIndex, hero);

            if (IDontCareMenu.Instance.IsDebugMode)
                Debug.Log(shouldNotify, "OnHeroLevelledUp", Constants.InformationType.Notification);

            return true;
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(CampaignEvents.OnHeroGainedSkill))]
        [HarmonyPatch(new Type[] { typeof(Hero), typeof(SkillObject), typeof(int), typeof(bool) })]
        public static bool OnHeroGainedSkillPrefix(Hero hero, SkillObject skill, int change, ref bool shouldNotify)
        {
            if (!shouldNotify || !ShouldNotifyByModSettings())
                return true;

            var filterModeIndex = IDontCareMenu.Instance.OnHeroGainedSkillFilterMode.GetFilterMode();

            shouldNotify = FilteringMethods.ShouldPlayerCare(filterModeIndex, hero);

            if (IDontCareMenu.Instance.IsDebugMode)
                Debug.Log(shouldNotify, "OnHeroGainedSkill", Constants.InformationType.Notification);

            return true;
        }

        private static bool ShouldNotifyByModSettings()
            => IDontCareMenu.Instance.IsFilterEnabled && !IDontCareMenu.Instance.IsBlockEverythingMode;
    }
}
