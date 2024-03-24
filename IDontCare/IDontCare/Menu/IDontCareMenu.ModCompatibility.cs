using IDontCare.Filtering;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using System;

namespace IDontCare.Menu
{
    internal partial class IDontCareMenu
    {
        [SettingPropertyButton("{=IDC.030}Refresh compatibility mode settings", Content = "{=IDC.Gen1}Refresh", Order = 0, 
                                RequireRestart = false, 
                                HintText = "{=IDC.030Hint}Those settings refresh at game start - you can click this to force refresh. "
                                            + "Changes do not refresh UI-wise, you need to leave and enter to see them!")]
        [SettingPropertyGroup(ModCompatibilityGroupName, GroupOrder = ModCompatibilityGroupOrder)]
        public Action AdvancedFilteringRefreshSettings { get; set; } = () => { FilteredStrings.BuildFilteringStrings(); };

        [SettingPropertyText("{=IDC.035}Generic filter strings", Order = 1, RequireRestart = false, 
                             HintText = "{=IDC.035Hint}This is a list of localization Ids to be seeked out and filtered. "
                                        + "Warning, this will filter out ALL instances of given translation! " 
                                        + "Usage: Type out string to search for separated by `;` symbol.")]
        [SettingPropertyGroup(ModCompatibilityGroupName, GroupOrder = ModCompatibilityGroupOrder)]
        public string AdvancedFilteringFilteredStrings { get; set; } = string.Empty;
    }
}
