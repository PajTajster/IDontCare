using IDontCare.Filtering;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Common;
using System;

namespace IDontCare.Menu
{
    internal partial class IDontCareMenu
    {
        [SettingPropertyBool("{=IDC.001}Enable mod", HintText = "{=IDC.001Hint}Enable [ticked] or Disable [unticked]", RequireRestart = false, Order = 0)]
        [SettingPropertyGroup(GlobalGroupName, GroupOrder = GlobalGroupOrder)]
        public bool IsFilterEnabled { get; set; } = true;

        [SettingPropertyBool("{=IDC.028}Enable global override setting", HintText = "{=IDC.028Hint}Enable [ticked] or Disable [unticked]", RequireRestart = false, Order = 1)]
        [SettingPropertyGroup(GlobalGroupName, GroupOrder = GlobalGroupOrder)]
        public bool AreGlobalSettingsEnabled { get; set; } = true;

        [SettingPropertyBool("{=IDC.029}Global filter mode", HintText = "{=IDC.029Hint}All the settings will use this if global override is active", RequireRestart = false, Order = 2)]
        [SettingPropertyGroup(GlobalGroupName, GroupOrder = GlobalGroupOrder)]
        public Dropdown<string> GlobalFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyButton("{=IDC.030}Refresh Toggle filter settings", Content = "{=IDC.Gen1}Refresh", Order = 3,
                                RequireRestart = false,
                                HintText = "{=IDC.030Hint}Those settings refresh at game start - you can click this to force refresh. "
                                            + "Changes do not refresh UI-wise, you need to leave and enter to see them!")]
        [SettingPropertyGroup(GlobalGroupName, GroupOrder = GlobalGroupOrder)]
        public Action AdvancedFilteringRefreshSettings { get; set; } = () => { FilteredStrings.BuildFilteringStrings(); };

        [SettingPropertyText("{=IDC.035}Generic filter strings", Order = 4, RequireRestart = false,
                             HintText = "{=IDC.035Hint}This is a list of localization Ids to be seeked out and filtered. "
                                        + "Warning, this will filter out ALL instances of given translation! "
                                        + "Usage: Type out string to search for separated by `;` symbol.")]
        [SettingPropertyGroup(GlobalGroupName, GroupOrder = GlobalGroupOrder)]
        public string AdvancedFilteringFilteredStrings { get; set; } = string.Empty;

    }
}
