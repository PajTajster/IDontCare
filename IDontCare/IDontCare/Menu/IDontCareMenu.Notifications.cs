using IDontCare.Filtering;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Common;

namespace IDontCare.Menu
{
    internal partial class IDontCareMenu
    {
        [SettingPropertyDropdown("{=IDC.024}Hero Levelled Up", HintText = "{=IDC.024Hint}Texts like '[hero] gained a level'", RequireRestart = false, Order = 1)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public Dropdown<string> OnHeroLevelledUpFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.025}Hero Gained Skill", HintText = "{=IDC.025Hint}Texts like '[hero] gained [some] skill points etc..'", RequireRestart = false, Order = 2)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public Dropdown<string> OnHeroGainedSkillFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyBool("{=IDC.036}Filter new part unlocked", HintText = "{=IDC.036Hint}Text like 'New Smiting Part Unlocked: [Part] for [Weapon]'", RequireRestart = false, Order = 5)]
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
        private bool _filterNewPartUnlocked = false;

        [SettingPropertyBool("{=IDC.037}Filter notables relations", 
                             HintText = "{=IDC.037Hint}Text like 'Your relation increased by [relation] with nearby notables'", 
                             RequireRestart = false, Order = 6)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public bool FilterNotableRelationIncreased
        {
            get => _filterRelationIncreased;
            set
            {
                AdvancedFiltering.HandleGenericStringSearchingFlag(value, "{=p9F90bc0}");
                _filterRelationIncreased = value;
            }
        }
        private bool _filterRelationIncreased = false;

        [SettingPropertyInteger("{=IDC.038}On Relation Change Positive", -1, 100,
                                HintText = "{=IDC.038Hint}Relation changed notifications positive value. "
                                           + "If new relation is in positive (0, 100) and lower or equal this value, show notification. "
                                           + "Set to -1 to disable all positive relation notifications",
                                RequireRestart = false, Order = 3)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public int OnHeroRelationChangedFilterPositiveRelation { get; set; } = 100;

        [SettingPropertyInteger("{=IDC.039}On Relation Change Negative", -100, 0,
                                HintText = "{=IDC.039Hint}Relation changed notifications negative value. "
                                            + "If new relation is in negative (-100, -1) and higher or equal this value, show notification. "
                                            + "Set to 0 to disable all positive negative notifications'",
                                RequireRestart = false, Order = 4)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public int OnHeroRelationChangedFilterNegativeRelation { get; set; } = -100;

        [SettingPropertyBool("{=IDC.040}Filter high security relation change", HintText = "{=IDC.040Hint}Notification when relation increases due to high security", RequireRestart = false, Order = 6)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public bool FilterHighSecurityRelationChanged
        {
            get => _filterHighSecurityRelationChanged;
            set
            {
                AdvancedFiltering.HandleGenericStringSearchingFlag(value, "{=ME5hmllb}");
                _filterHighSecurityRelationChanged = value;
            }
        }
        private bool _filterHighSecurityRelationChanged = false;

        [SettingPropertyBool("{=IDC.041}Filter high loyalty relation change", HintText = "{=IDC.041Hint}Notification when relation increases due to high loyalty", RequireRestart = false, Order = 6)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = NotificationsGroupOrder)]
        public bool FilterHighLoyaltyRelationChanged
        {
            get => _filterHighLoyaltyRelationChanged;
            set
            {
                AdvancedFiltering.HandleGenericStringSearchingFlag(value, "{=0h5BrVdA}");
                _filterHighLoyaltyRelationChanged = value;
            }
        }
        private bool _filterHighLoyaltyRelationChanged = false;
    }
}
