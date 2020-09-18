using HarmonyLib;
using System;
using System.Text;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace IDontCare
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            var harmony = new Harmony("pajtajster.idontcare.patch");
            harmony.PatchAll();

            Module.CurrentModule.AddInitialStateOption(new InitialStateOption("Change Importance",
                new TextObject("Change Importance", null),
                9990,
                () => {
                    var currentImportance = (int)IDontCarePatch.PlayerCareImportanceLevel;
                    var newImportance = (ImportanceEnum)(++currentImportance);
                    if (!Enum.IsDefined(typeof(ImportanceEnum), newImportance))
                        IDontCarePatch.PlayerCareImportanceLevel = default(ImportanceEnum);
                    else
                        IDontCarePatch.PlayerCareImportanceLevel = newImportance;
                    InformationManager.DisplayMessage(new InformationMessage($"Current importance: {IDontCarePatch.PlayerCareImportanceLevel}"));
                },
                false));
        }

        public override void OnCampaignStart(Game game, object starterObject)
        {
            base.OnCampaignStart(game, starterObject);
        }
    }
}
