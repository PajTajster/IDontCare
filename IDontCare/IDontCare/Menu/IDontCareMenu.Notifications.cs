using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Common;

namespace Menu
{
    internal partial class IDontCareMenu
    {
        [SettingPropertyDropdown("{=IDC.024}Hero Levelled Up", HintText = "{=IDC.024Hint}Texts like '[hero] gained a level'", RequireRestart = false, Order = 24)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public Dropdown<string> OnHeroLevelledUpFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.025}Hero Gained Skill", HintText = "{=IDC.025Hint}Texts like '[hero] gained [some] skill points etc..'", RequireRestart = false, Order = 25)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public Dropdown<string> OnHeroGainedSkillFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);
    }
}
