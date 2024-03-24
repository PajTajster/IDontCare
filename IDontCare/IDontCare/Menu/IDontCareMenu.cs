using MCM.Abstractions.Base.Global;

namespace IDontCare.Menu
{
    internal partial class IDontCareMenu : AttributeGlobalSettings<IDontCareMenu>
    {
        public override string Id => "pajtajster.idontcare.campaignlogfilter.menu";
        public override string DisplayName => "I Don't Care";
        public override string FolderName => "IDontCareCampaignLogFilter";
        public override string FormatType => "json";

        private const string GlobalGroupName = "{=IDC.G000}Global Settings";
        private const int GlobalGroupOrder = 0;

        private const string LogEntriesGroupName = "{=IDC.G000}Log Entries Filter Modes";
        private const int LogEntriesGroupOrder = 1;

        private const string NotificationGroupName = "{=IDC.G001}Notifications Filter Modes";
        private const int NotificationsGroupOrder = 2;

        private const string ModCompatibilityGroupName = "{=IDC.G004}Compatibility Mode";
        private const int ModCompatibilityGroupOrder = 3;

        private const string DebugGroupName = "{=IDC.G002}Debug";
        private const int DebugGroupOrder = 100;

        private const string TextDefaultFilter = "{=IDC.V000}Default";
        private const string TextFilterAll = "{=IDC.V001}Filter All";
        private const string TextFilterNothing = "{=IDC.V002}Filter Nothing";
        private const string TextFilterOnlyMe = "{=IDC.V003}Log entries only for my character";
        private const string TextFilterMyClan = "{=IDC.V004}Log entries only for my clan";
        private const string TextFilterOnlyMyKingdom = "{=IDC.V005}Log entries only for my kingdom";

        private static readonly string[] FilteringDefaultDropdownValues = 
            new string[] { TextDefaultFilter, TextFilterAll, TextFilterNothing, TextFilterOnlyMe, TextFilterMyClan, TextFilterOnlyMyKingdom };
    }
}
