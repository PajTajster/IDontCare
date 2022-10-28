using IDontCare.Constants;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using MCM.Common;
using System.Collections.Generic;

namespace IDontCare
{
    public class IDontCareMenu : AttributeGlobalSettings<IDontCareMenu>
    {
        public override string Id => "pajtajster.idontcare.campaignlogfilter.menu";
        public override string DisplayName => "I Don't Care";
        public override string FolderName => "IDontCareCampaignLogFilter";
        public override string FormatType => "json";

        public const string LogEntriesGroupName = "Log Entries Filter Modes";
        public const int FilterGroupsGroupOrder = 0;
        public const string NotificationGroupName = "Notifications Filter Modes";
        public const string DebugGroupName = "Debug";

        private static readonly Dropdown<string> LogEntriesDefaultDropdownValues = new Dropdown<string>(
            new List<string> { FilterMode.Default.ToString(), FilterMode.FilterAll.ToString(), FilterMode.FilterNothing.ToString()}, 0);

        private static readonly Dropdown<string> NotificationsDefaultDropdownValues = new Dropdown<string>(
            new List<string> {
                FilterMode.Default.ToString(), FilterMode.FilterAll.ToString(), FilterMode.FilterNothing.ToString(), FilterMode.OnlyMe.ToString() },
            0);

        [SettingProperty("Enable mod", RequireRestart = false, HintText = "Enable [ticked] or Disable [unticked]")]
        [SettingPropertyGroup("FilterEnabling", GroupOrder = 1)]
        public bool IsFilterEnabled { get; set; } = true;

        #region LogEntries
        [SettingPropertyDropdown("Army Dispersion Entries", HintText = "Texts like '[some army] has been disbanded'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> ArmyDispersionFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Raiding Entries", HintText = "Texts like '[some army] is raiding [some settlement]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> BattleStartedFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Settlements Siege Entries", HintText = "Texts like '[some town/castle] is besieged'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> BesiegedSettlementFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Area Owner Change Entries", HintText = "It's related to changing in ownership of alleys in towns", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> ChangeCommonAreaOwnerFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Character Born Entries", HintText = "Texts like '[child] was born to [some lord]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> CharacterBornFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Lord's quarrel Entries", HintText = "Something with lords insulting each other", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> CharacterInsultedFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);
        
        [SettingPropertyDropdown("Death Entries", HintText = "Texts like '[some guy] died of old age.' or '[some lord] was executed by [some other lord]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> CharacterKilledFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Marriage Entries", HintText = "Texts like '[some character] married [some other character]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> CharacterMarriedFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Child Birth Entries", HintText = "Those texts are related to player's babies", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> ChildbirthFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Clan Changing Kingdom Entries", HintText = "Texts regarding Clans switching kingdoms", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> ClanChangeKingdomFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("War Declaration Entries", HintText = "Texts like '[some kingdom] declared war on [some other kingdom]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> DeclareWarFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("End Captivity Entries", HintText = "Any text regarding end of captivity, like paid ransom or escape", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> EndCaptivityFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Army Gathering Entries", HintText = "Texts like '[some lord] gathers army at [somewhere]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> GatherArmyFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Kingdom Concluded Decision Entries", HintText = "Texts like '[faction] [has done something] with e.g.: major support'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> KingdomDecisionConcludedFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Kingdom Destroyed Entries", HintText = "Texts like '[kingdom] has been destroyed'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> KingdomDestroyedFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Kingdom Peace Entries", HintText = "Texts like '[some kingdom] made peace with [some other kingdom]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> MakePeaceFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Mercenary Clan Changed Kingdom Entries", HintText = "Texts like '[some mercenaries] joined/left [some kingdom]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> MercenaryClanChangedKingdomFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Battle End Entries", HintText = "Texts like '[some hero] has defeated [some other hero]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> PlayerBattleEndedFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Pregnacy Entries", HintText = "Texts like '[some woman] is pregnant'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> PregnancyFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Rebellion Entries", HintText = "Texts like 'Rebels in [Settlement] have taken the ownership of the settlement.'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> RebellionStartedFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Settlement Taken Entries", HintText = "Texts like '[somebody] has claimed [some settlement} currently held by the [some faction]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> SettlementClaimedFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Taken Prisoner Entries", HintText = "Texts like '[somebody] has been taken prisoner by [someone else]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> TakePrisonerFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);
        
        [SettingPropertyDropdown("Tournament Won Entries", HintText = "Texts like '[somebody] has won the tournament at [some town]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> TournamentWonFilterMode { get; set; } = new Dropdown<string>(LogEntriesDefaultDropdownValues, 0);
        #endregion

        #region Notifications

        [SettingPropertyDropdown("Hero Levelled Up", HintText = "Texts like '[hero] gained a level'", RequireRestart = false)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> OnHeroLevelledUpFilterMode { get; set; } = new Dropdown<string>(NotificationsDefaultDropdownValues, 0);

        [SettingPropertyDropdown("Hero Gained Skill", HintText = "Texts like '[hero] gained [some] skill points etc..'", RequireRestart = false)]
        [SettingPropertyGroup(NotificationGroupName, GroupOrder = FilterGroupsGroupOrder)]
        public Dropdown<string> OnHeroGainedSkillFilterMode { get; set; } = new Dropdown<string>(NotificationsDefaultDropdownValues, 0);

        #endregion

        [SettingProperty("Debug Logger", RequireRestart = false, HintText = "Enable or Disable debug messages")]
        [SettingPropertyGroup(DebugGroupName, GroupOrder = 2)]
        public bool IsDebugMode { get; set; } = false;

        [SettingProperty("Debug Filter Out Everything", RequireRestart = false, HintText = "Enable or Disable filtering out every log")]
        [SettingPropertyGroup(DebugGroupName, GroupOrder = 2)]
        public bool IsBlockEverythingMode { get; set; } = false;
    }
}
