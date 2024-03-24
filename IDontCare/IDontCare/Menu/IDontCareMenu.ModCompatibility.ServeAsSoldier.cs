using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace IDontCare.Menu
{
    internal partial class IDontCareMenu
    {
        private const string ServeAsSoldierGroupName = ModCompatibilityGroupName + "\\" + "{=IDC.GS01}Serve As Soldier";
        private const int ServeAsSoldierGroupOrder = ModCompatibilityGroupOrder + 1;

        [SettingPropertyBool("{=IDC.031}Filter Hero adopting child", Order = 1, RequireRestart = false, HintText = "{=IDC.031Hint}Text like '[Hero] adopted a child [Child]'")]
        [SettingPropertyGroup(ServeAsSoldierGroupName, GroupOrder = ServeAsSoldierGroupOrder)]
        public bool FilterServeAsSoldierHeroAdoptedChild { get; set; } = true;

        [SettingPropertyBool("{=IDC.032}Filter Hero promoted", Order = 2, RequireRestart = false, HintText = "{=IDC.032Hint}Text like '[Hero] has been promoted to tier [Tier]'")]
        [SettingPropertyGroup(ServeAsSoldierGroupName, GroupOrder = ServeAsSoldierGroupOrder)]
        public bool FilterServeAsSoldierHeroPromoted { get; set; } = true;

        [SettingPropertyBool("{=IDC.033}Filter Hero recruited by lord", Order = 3, RequireRestart = false, HintText = "{=IDC.033Hint}Text like '[Lord] recruited [Hero]'")]
        [SettingPropertyGroup(ServeAsSoldierGroupName, GroupOrder = ServeAsSoldierGroupOrder)]
        public bool FilterServeAsSoldierHeroRecruited { get; set; } = true;

        [SettingPropertyBool("{=IDC.034}Filter Hero no longer employeed", Order = 4, RequireRestart = false, HintText = "{=IDC.034Hint}Text like '[Hero] is no longer employeed by [Lord]'")]
        [SettingPropertyGroup(ServeAsSoldierGroupName, GroupOrder = ServeAsSoldierGroupOrder)]
        public bool FilterServeAsSoldierHeroUnemployed { get; set; } = true;
    }
}
