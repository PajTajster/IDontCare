using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;

namespace IDontCare.Menu
{
    internal partial class IDontCareMenu
    {
        [SettingProperty("{=IDC.026}Debug Logger", HintText = "{=IDC.026Hint}Enable or Disable debug messages", RequireRestart = false, Order = 0)]
        [SettingPropertyGroup(DebugGroupName, GroupOrder = DebugGroupOrder)]
        public bool IsDebugMode { get; set; } = false;

        [SettingProperty("{=IDC.027}Debug Filter Out Everything", HintText = "{=IDC.027Hint}Enable or Disable filtering out every log", RequireRestart = false, Order = 1)]
        [SettingPropertyGroup(DebugGroupName, GroupOrder = DebugGroupOrder)]
        public bool IsBlockEverythingMode { get; set; } = false;
    }
}
