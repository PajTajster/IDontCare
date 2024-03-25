using IDontCare.Filtering;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace IDontCare.Menu
{
    internal partial class IDontCareMenu
    {
        private const string ServeAsSoldierGroupName = ModCompatibilityGroupName + "\\" + "{=IDC.GS01}Serve As Soldier";
        private const int ServeAsSoldierGroupOrder = ModCompatibilityGroupOrder + 1;

        private bool filterServeAsSoldierHeroAdoptedChild = true;
        private bool filterServeAsSoldierHeroPromoted = true;
        private bool filterServeAsSoldierHeroRecruited = true;
        private bool filterServeAsSoldierHeroUnemployed = true;

        [SettingPropertyBool("{=IDC.031}Filter Hero adopting child", Order = 1, RequireRestart = false, HintText = "{=IDC.031Hint}Text like '[Hero] adopted a child [Child]'")]
        [SettingPropertyGroup(ServeAsSoldierGroupName, GroupOrder = ServeAsSoldierGroupOrder)]
        public bool FilterServeAsSoldierHeroAdoptedChild
        {
            get => filterServeAsSoldierHeroAdoptedChild; 
            set
            {
                AdvancedFiltering.HandleGenericStringSearchingFlag(value, "{=FLT0000179}");
                filterServeAsSoldierHeroAdoptedChild = value;
            }
        }

        [SettingPropertyBool("{=IDC.032}Filter Hero promoted", Order = 2, RequireRestart = false, HintText = "{=IDC.032Hint}Text like '[Hero] has been promoted to tier [Tier]'")]
        [SettingPropertyGroup(ServeAsSoldierGroupName, GroupOrder = ServeAsSoldierGroupOrder)]
        public bool FilterServeAsSoldierHeroPromoted
        {
            get => filterServeAsSoldierHeroPromoted; 
            set
            {
                AdvancedFiltering.HandleGenericStringSearchingFlag(value, "{=FLT0000000}");
                filterServeAsSoldierHeroPromoted = value;
            }
        }

        [SettingPropertyBool("{=IDC.033}Filter Hero recruited by lord", Order = 3, RequireRestart = false, HintText = "{=IDC.033Hint}Text like '[Lord] recruited [Hero]'")]
        [SettingPropertyGroup(ServeAsSoldierGroupName, GroupOrder = ServeAsSoldierGroupOrder)]
        public bool FilterServeAsSoldierHeroRecruited
        {
            get => filterServeAsSoldierHeroRecruited; 
            set
            {
                AdvancedFiltering.HandleGenericStringSearchingFlag(value, "{=FLT0000229}");
                filterServeAsSoldierHeroRecruited = value;
            }
        }

        [SettingPropertyBool("{=IDC.034}Filter Hero no longer employeed", Order = 4, RequireRestart = false, HintText = "{=IDC.034Hint}Text like '[Hero] is no longer employeed by [Lord]'")]
        [SettingPropertyGroup(ServeAsSoldierGroupName, GroupOrder = ServeAsSoldierGroupOrder)]
        public bool FilterServeAsSoldierHeroUnemployed
        {
            get => filterServeAsSoldierHeroUnemployed; 
            set
            {
                AdvancedFiltering.HandleGenericStringSearchingFlag(value, "{=FLT0000230}");
                filterServeAsSoldierHeroUnemployed = value;
            }
        }
    }
}
