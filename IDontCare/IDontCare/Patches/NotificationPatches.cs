using System;
using IDontCare.Filtering;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using IDontCare.Menu;
using IDontCare.Extensions;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Library;

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
                IDontCare.Filtering.Debug.Log(shouldNotify, "OnHeroLevelledUp", Constants.InformationType.Notification);

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
                IDontCare.Filtering.Debug.Log(shouldNotify, "OnHeroGainedSkill", Constants.InformationType.Notification);

            return true;
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(CampaignEvents.OnHeroRelationChanged))]
        public static bool OnHeroRelationChangedPrefix(Hero effectiveHero,
                                                       Hero effectiveHeroGainedRelationWith,
                                                       int relationChange,
                                                       ref bool showNotification,
                                                       ChangeRelationAction.ChangeRelationDetail detail,
                                                       Hero originalHero,
                                                       Hero originalGainedRelationWith)
        {
            if (!showNotification || !ShouldNotifyByModSettings()
                || (IDontCareMenu.Instance.OnHeroRelationChangedFilterNegativeRelation == 0
                    && IDontCareMenu.Instance.OnHeroRelationChangedFilterPositiveRelation == -1)
                || (effectiveHero.Id != Hero.MainHero.Id 
                    && effectiveHeroGainedRelationWith.Id != Hero.MainHero.Id))
                return true;

            if (IDontCareMenu.Instance.IsBlockEverythingMode)
            {
                showNotification = false;
                return true;
            }

            int currentRelation = CharacterRelationManager.GetHeroRelation(effectiveHero, effectiveHeroGainedRelationWith);
            if (currentRelation < 0)
                showNotification = currentRelation >= IDontCareMenu.Instance.OnHeroRelationChangedFilterNegativeRelation;
            else
                showNotification = currentRelation <= IDontCareMenu.Instance.OnHeroRelationChangedFilterPositiveRelation;

            if (IDontCareMenu.Instance.IsDebugMode)
                IDontCare.Filtering.Debug.Log(showNotification, "HeroRelationChanged", Constants.InformationType.Notification);

            return true;
        }

        private static bool ShouldNotifyByModSettings()
            => IDontCareMenu.Instance.IsFilterEnabled && !IDontCareMenu.Instance.IsBlockEverythingMode;
    }
}
