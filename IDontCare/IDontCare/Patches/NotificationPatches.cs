using System;
using IDontCare.Filtering;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using IDontCare.Menu;

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
            if (!shouldNotify || !IDontCareMenu.Instance.IsFilterEnabled)
            {
                return true;
            }

            var filterModeIndex = IDontCareMenu.Instance.OnHeroLevelledUpFilterMode.SelectedIndex; ;

            shouldNotify = FilteringMethods.ShouldPlayerCare(filterModeIndex, hero);

            return true;
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(CampaignEvents.OnHeroGainedSkill))]
        [HarmonyPatch(new Type[] { typeof(Hero), typeof(SkillObject), typeof(int), typeof(bool) })]
        public static bool OnHeroGainedSkillPrefix(Hero hero, SkillObject skill, int change, ref bool shouldNotify)
        {
            if (!shouldNotify || !IDontCareMenu.Instance.IsFilterEnabled)
            {
                return true;
            }

            var filterModeIndex = IDontCareMenu.Instance.OnHeroGainedSkillFilterMode.SelectedIndex;

            shouldNotify = FilteringMethods.ShouldPlayerCare(filterModeIndex, hero);

            return true;
        }
    }
}
