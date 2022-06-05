using System;
using System.Collections.Generic;
using HarmonyLib;
using IDontCare.Constants;
using IDontCare.Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace IDontCare.Patches
{
    [HarmonyPatch(typeof(CampaignEventReceiver))]
    public static class NotificationsPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("OnHeroLevelledUp")]
        [HarmonyPatch(new Type[] { typeof(Hero), typeof(bool) })]
        public static bool OnHeroLevelledUpPrefix(Hero hero, ref bool shouldNotify)
        {
            if (!shouldNotify || !IDontCareMenu.Instance.IsFilterEnabled)
            {
                return true;
            }

            var filterModeIndex = IDontCareMenu.Instance.OnHeroLevelledUpFilterMode.SelectedIndex;

            bool shouldPlayerCare;
            if (filterModeIndex == (int)FilterMode.OnlyMe)
            {
                shouldPlayerCare = hero == Hero.MainHero;
            }
            else
            {
                shouldPlayerCare = ShouldPlayerCare(IDontCareMenu.Instance.OnHeroLevelledUpFilterMode.SelectedIndex,
                    new List<IFaction>() { hero?.MapFaction });
            }

            if (!shouldPlayerCare)
            {
                DebugLogNotificationIfEnabled("OnHeroLevelledUp");
            }

            shouldNotify = shouldPlayerCare;
            return true;
        }

        [HarmonyPrefix]
        [HarmonyPatch("OnHeroGainedSkill")]
        [HarmonyPatch(new Type[] { typeof(Hero), typeof(SkillObject), typeof(bool), typeof(int), typeof(bool) })]
        public static bool OnHeroGainedSkillPrefix(Hero hero, SkillObject skill, bool hasNewPerk, int change, ref bool shouldNotify)
        {
            if (!shouldNotify || !IDontCareMenu.Instance.IsFilterEnabled)
            {
                return true;
            }

            var filterModeIndex = IDontCareMenu.Instance.OnHeroGainedSkillFilterMode.SelectedIndex;

            bool shouldPlayerCare;
            if (filterModeIndex == (int)FilterMode.OnlyMe)
            {
                shouldPlayerCare = hero == Hero.MainHero;
            }
            else
            {
                shouldPlayerCare = ShouldPlayerCare(IDontCareMenu.Instance.OnHeroGainedSkillFilterMode.SelectedIndex,
                    new List<IFaction>() { hero?.MapFaction });
            }

            if (!shouldPlayerCare)
            {
                DebugLogNotificationIfEnabled("OnHeroLevelledUp");
            }

            shouldNotify = shouldPlayerCare;
            return true;
        }

        private static bool ShouldPlayerCare(int filterModeIndex, List<IFaction> factionsInvolved)
        {
            bool shouldPlayerCare = false;

            if (filterModeIndex == (int)FilterMode.Default)
            {
                shouldPlayerCare = FilteringHelper.IsAnyFactionAllyOrEnemyOfPlayer(factionsInvolved);
            }
            else
            {
                shouldPlayerCare = FilteringHelper.SwitchShouldPlayerCareDependingOnFilterMode(filterModeIndex);
            }

            return shouldPlayerCare;
        }

        private static void DebugLogNotificationIfEnabled(string notificationTypeName)
        {
            if (IDontCareMenu.Instance.IsDebugMode)
            {
                FilteringHelper.DebugLog(notificationTypeName, InformationType.Notification);
            }
        }
    }
}
