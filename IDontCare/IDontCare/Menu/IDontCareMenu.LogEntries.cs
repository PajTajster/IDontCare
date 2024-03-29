﻿using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Common;

namespace IDontCare.Menu
{
    internal partial class IDontCareMenu
    {
        [SettingPropertyDropdown("{=IDC.002}Army Dispersion Entries", HintText = "{=IDC.002Hint}Texts like '[some army] has been disbanded'", RequireRestart = false, Order = 2)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> ArmyDispersionFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.003}Raiding Entries", HintText = "{=IDC.003Hint}Texts like '[some army] is raiding [some settlement]'", RequireRestart = false, Order = 3)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> BattleStartedFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.004}Settlements Siege Entries", HintText = "{=IDC.004Hint}Texts like '[some town/castle] is besieged'", RequireRestart = false, Order = 4)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> BesiegedSettlementFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.005}Character Born Entries", HintText = "{=IDC.005Hint}Texts like '[child] was born to [some lord]'", RequireRestart = false, Order = 5)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> CharacterBornFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.006}Lord's quarrel Entries", HintText = "{=IDC.006Hint}Something with lords insulting each other", RequireRestart = false, Order = 6)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> CharacterInsultedFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.007}Death Entries", HintText = "{=IDC.007Hint}Texts like '[some guy] died of old age.' or '[some lord] was executed by [some other lord]'", RequireRestart = false)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> CharacterKilledFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.008}Marriage Entries", HintText = "{=IDC.008Hint}Texts like '[some character] married [some other character]'", RequireRestart = false, Order = 8)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> CharacterMarriedFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.009}Child Birth Entries", HintText = "{=IDC.009Hint}Those texts are related to player's babies", RequireRestart = false, Order = 9)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> ChildbirthFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.010}Clan Changing Kingdom Entries", HintText = "{=IDC.010Hint}Texts regarding Clans switching kingdoms", RequireRestart = false, Order = 10)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> ClanChangeKingdomFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.011}War Declaration Entries", HintText = "{=IDC.011Hint}Texts like '[some kingdom] declared war on [some other kingdom]'", RequireRestart = false, Order = 11)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> DeclareWarFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.012}End Captivity Entries", HintText = "{=IDC.012Hint}Any text regarding end of captivity, like paid ransom or escape", RequireRestart = false, Order = 12)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> EndCaptivityFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.013}Army Gathering Entries", HintText = "{=IDC.013Hint}Texts like '[some lord] gathers army at [somewhere]'", RequireRestart = false, Order = 13)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> GatherArmyFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.014}Kingdom Concluded Decision Entries", HintText = "{=IDC.014Hint}Texts like '[faction] [has done something] with e.g.: major support'", RequireRestart = false, Order = 14)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> KingdomDecisionConcludedFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.015}Kingdom Destroyed Entries", HintText = "{=IDC.015Hint}Texts like '[kingdom] has been destroyed'", RequireRestart = false, Order = 15)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> KingdomDestroyedFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.016}Kingdom Peace Entries", HintText = "{=IDC.016Hint}Texts like '[some kingdom] made peace with [some other kingdom]'", RequireRestart = false, Order = 16)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> MakePeaceFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.017}Mercenary Clan Changed Kingdom Entries", HintText = "{=IDC.017Hint}Texts like '[some mercenaries] joined/left [some kingdom]'", RequireRestart = false, Order = 17)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> MercenaryClanChangedKingdomFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.018}Battle End Entries", HintText = "{=IDC.018Hint}Texts like '[some hero] has defeated [some other hero]'", RequireRestart = false, Order = 18)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> PlayerBattleEndedFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.019}Pregnancy Entries", HintText = "{=IDC.019Hint}Texts like '[some woman] is pregnant'", RequireRestart = false, Order = 19)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> PregnancyFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.020}Rebellion Entries", HintText = "{=IDC.020Hint}Texts like 'Rebels in [Settlement] have taken the ownership of the settlement.'", RequireRestart = false, Order = 20)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> RebellionStartedFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.021}Settlement Taken Entries", HintText = "{=IDC.021Hint}Texts like '[somebody] has claimed [some settlement} currently held by the [some faction]'", RequireRestart = false, Order = 21)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> SettlementClaimedFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.022}Taken Prisoner Entries", HintText = "{=IDC.022Hint}Texts like '[somebody] has been taken prisoner by [someone else]'", RequireRestart = false, Order = 22)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> TakePrisonerFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);

        [SettingPropertyDropdown("{=IDC.023}Tournament Won Entries", HintText = "{=IDC.023Hint}Texts like '[somebody] has won the tournament at [some town]'", RequireRestart = false, Order = 23)]
        [SettingPropertyGroup(LogEntriesGroupName, GroupOrder = LogEntriesGroupOrder)]
        public Dropdown<string> TournamentWonFilterMode { get; set; } = new Dropdown<string>(FilteringDefaultDropdownValues, 0);
    }
}
