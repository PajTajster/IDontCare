using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace IDontCare
{
    public class SubModule : MBSubModuleBase
    {
        private const string IDC_PATCH_NAME = "pajtajster.idontcare.patch";

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            var harmony = new Harmony(IDC_PATCH_NAME);
            harmony.PatchAll();
        }

        public override void OnCampaignStart(Game game, object starterObject)
        {
            base.OnCampaignStart(game, starterObject);
        }
    }
}
