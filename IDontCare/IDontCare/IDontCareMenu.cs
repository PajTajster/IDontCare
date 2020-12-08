using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Dropdown;
using MCM.Abstractions.Settings.Base.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDontCare
{
    public class IDontCareMenu : AttributeGlobalSettings<IDontCareMenu>
    {
        public override string Id => "pajtajster.idontcare.campaignlogfilter.menu";
        public override string DisplayName => "I Don't Care";
        public override string FolderName => "IDontCareCampaignLogFilter";
        
        public static readonly int FILTERMODE_DEFAULT = 0;
        public static readonly int FILTERMODE_FILTER_ALL = 1;
        public static readonly int FILTERMODE_FILTER_NOTHING = 2;

        private static readonly DropdownDefault<string> FilterOptionsDefaultDropdown = new DropdownDefault<string>(
            new List<string> { "Default", "Filter all", "Filter Nothing" }, 0);

        [SettingProperty("Enable mod", RequireRestart = false, HintText = "Enable [ticked] or Disable [unticked]")]
        [SettingPropertyGroup("FilterEnabling", GroupOrder = 1)]
        public bool IsFilterEnabled { get; set; } = true;

        [SettingPropertyDropdown("Army Dispersion Entries", HintText = "Texts like '[some army] has been disbanded'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> ArmyDispersionFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Raiding Entries", HintText = "Texts like '[some army] is raiding [some settlement]'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> BattleStartedFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Settlements Siege Entries", HintText = "Texts like '[some town/castle] is besieged'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> BesiegedSettlementFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Area Owner Change Entries", HintText = "It's related to changing in ownership of alleys in towns, dunno if it actually is used", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> ChangeCommonAreaOwnerFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Character Born Entries", HintText = "Texts like '[child] was born to [some lord]'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> CharacterBornFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Lord's quarrel Entries", HintText = "Something with lords insulting each other", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> CharacterInsultedFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);
        
        [SettingPropertyDropdown("Death Entries", HintText = "Texts like '[some guy] died of old age.' or '[some lord] was executed by [some other lord]'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> CharacterKilledFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Marriage Entries", HintText = "Texts like '[some character] married [some other character]'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> CharacterMarriedFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Child Birth Entries", HintText = "Those texts are related to player's babies", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> ChildbirthFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Clan Changing Kingdom Entries", HintText = "Texts regarding Clans switching kingdoms", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> ClanChangeKingdomFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("War Declaration Entries", HintText = "Texts like '[some kingdom] declared war on [some other kingdom]'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> DeclareWarFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("End Captivity Entries", HintText = "Any text regarding end of captivity, like paid ransom or escape", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> EndCaptivityFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Army Gathering Entries", HintText = "Texts like '[some lord] gathers army at [somewhere]'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> GatherArmyFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Kingdom Concluded Decision Entries", HintText = "Texts like '[faction] [has done something] with e.g.: major support'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> KingdomDecisionConcludedFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Kingdom Peace Entries", HintText = "Texts like '[some kingdom] made peace with [some other kingdom]'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> MakePeaceFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Mercenary Clan Changed Kingdom Entries", HintText = "Texts like '[some mercenaries] joined/left [some kingdom]'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> MercenaryClanChangedKingdomFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Pregnacy Entries", HintText = "Texts like '[some woman] is pregnant'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> PregnancyFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Rebellion Entries", HintText = "It's for rebellions in settlement. It's not yet in the game", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> RebellionStartedFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Settlement Taken Entries", HintText = "Texts like '[somebody] has claimed [some settlement} currently held by the [some faction]'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> SettlementClaimedFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);

        [SettingPropertyDropdown("Taken Prisoner Entries", HintText = "Texts like '[somebody] has been taken prisoner by [someone else]'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> TakePrisonerFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);
        
        [SettingPropertyDropdown("Tournament Won Entries", HintText = "Texts like '[somebody] has won the tournament at [some town]'", RequireRestart = false)]
        [SettingPropertyGroup("Filter Modes", GroupOrder = 0)]
        public DropdownDefault<string> TournamentWonFilterMode { get; set; } = new DropdownDefault<string>(FilterOptionsDefaultDropdown, 0);
        
        [SettingProperty("Debug Logger", RequireRestart = false, HintText = "Enable or Disable debug messages")]
        [SettingPropertyGroup("Debug", GroupOrder = 2)]
        public bool IsDebugMode { get; set; } = false;

        [SettingProperty("Debug Filter Out Everything", RequireRestart = false, HintText = "Enable or Disable filtering out every log")]
        [SettingPropertyGroup("Debug", GroupOrder = 2)]
        public bool IsBlockEverythingMode { get; set; } = false;
    }
}
