using IDontCare.Filtering;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Common;

namespace IDontCare.Menu
{
    internal partial class IDontCareMenu
    {
        private bool _filterNewPartUnlocked = false;
        private bool _filterRelationIncreased = false;

        [SettingPropertyDropdown("{=IDC.024}Hero Levelled Up", HintText = "{=IDC.024Hint}Texts like '[hero] gained a level'", RequireRestart = false, Order = 1)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public Dropdown<string> OnHeroLevelledUpFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.025}Hero Gained Skill", HintText = "{=IDC.025Hint}Texts like '[hero] gained [some] skill points etc..'", RequireRestart = false, Order = 2)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public Dropdown<string> OnHeroGainedSkillFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyBool("{=IDC.036}Filter new part unlocked", HintText = "{=IDC.036Hint}Text like 'New Smiting Part Unlocked: [Part] for [Weapon]'", RequireRestart = false, Order = 3)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public bool FilterNewPartUnlocked
        {
            get => _filterNewPartUnlocked; 
            set
            {
                AdvancedFiltering.HandleGenericStringSearchingFlag(value, "{=o0qwDa0q}");
                _filterNewPartUnlocked = value;
            }
        }

        [SettingPropertyBool("{=IDC.037}Filter notables relations", HintText = "{=IDC.037Hint}Text like 'Your relation increased by [relation] with nearby notables'", RequireRestart = false, Order = 4)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public bool FilterRelationIncreased
        {
            get => _filterRelationIncreased; 
            set
            {
                AdvancedFiltering.HandleGenericStringSearchingFlag(value, "{=p9F90bc0}");
                _filterRelationIncreased = value;
            }
        }
    }
}
