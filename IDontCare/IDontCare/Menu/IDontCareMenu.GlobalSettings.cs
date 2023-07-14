using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Common;

namespace Menu
{
    internal partial class IDontCareMenu
    {
        [SettingPropertyBool("{=IDC.001}Enable mod", HintText = "{=IDC.001Hint}Enable [ticked] or Disable [unticked]", RequireRestart = false, Order = 0)]
        [SettingPropertyGroup(GlobalGroupName, GroupOrder = GlobalGroupOrder)]
        public bool IsFilterEnabled { get; set; } = true;

        [SettingPropertyBool("{=IDC.028}Enable mod", HintText = "{=IDC.028Hint}Enable [ticked] or Disable [unticked]", RequireRestart = false, Order = 0)]
        [SettingPropertyGroup(GlobalGroupName, GroupOrder = GlobalGroupOrder)]
        public bool AreGlobalSettingsEnabled { get; set; } = true;

        [SettingPropertyBool("{=IDC.029}Enable mod", HintText = "{=IDC.029Hint}Enable [ticked] or Disable [unticked]", RequireRestart = false, Order = 0)]
        [SettingPropertyGroup(GlobalGroupName, GroupOrder = GlobalGroupOrder)]
        public Dropdown<string> GlobalFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);
    }
}
