using System;
using HarmonyLib;
using IDontCare.Constants;
using IDontCare.Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

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

            shouldNotify = ShouldPlayerCare(hero,
                                            filterModeIndex,
                                            "OnHeroLevelledUp");
            return true;
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(CampaignEvents.OnHeroGainedSkill))]
        [HarmonyPatch(new Type[] { typeof(Hero), typeof(SkillObject), typeof(int), typeof(bool) })]
        public static bool OnHeroGainedSkillPrefix(Hero hero, SkillObject skill, int change, ref bool shouldNotify)
        {
            if (!shouldNotify)
            {
                return true;
            }

            var filterModeIndex = IDontCareMenu.Instance.OnHeroGainedSkillFilterMode.SelectedIndex;

            shouldNotify = ShouldPlayerCare(hero,
                                            filterModeIndex,
                                            "OnHeroGainedSkill");
            return true;
        }

        private static bool ShouldPlayerCare(Hero hero, int filterModeIndex, string debugMethodName)
        {
            if (!IDontCareMenu.Instance.IsFilterEnabled)
            {
                return true;
            }

            var filterMode = (FilterMode)filterModeIndex;

            bool shouldPlayerCare;

            switch (filterMode)
            {
                case FilterMode.FilterAll:
                    shouldPlayerCare = false;
                    break;
                case FilterMode.FilterNothing:
                    shouldPlayerCare = true;
                    break;
                case FilterMode.OnlyMe:
                    shouldPlayerCare = hero == Hero.MainHero;
                    break;
                case FilterMode.Default:
                default:
                    shouldPlayerCare = FilteringHelper.IsFactionEnemyOrAllyOfPlayer(hero?.MapFaction);
                    break;
            }

            if (IDontCareMenu.Instance.IsDebugMode && !shouldPlayerCare)
            {
                FilteringHelper.DebugLog(debugMethodName, InformationType.Notification);
            }

            return shouldPlayerCare;
        }
    }
}
