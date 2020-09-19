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
        }

        public override void OnCampaignStart(Game game, object starterObject)
        {
            base.OnCampaignStart(game, starterObject);
        }
    }
}
