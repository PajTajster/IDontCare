using HarmonyLib;
using IDontCare.Filtering;
using System.Reflection;
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
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            AdvancedFiltering.Initialize();
        }
    }
}
