using IDontCare.Constants;
using IDontCare.Menu;
using MCM.Common;

namespace IDontCare.Extensions
{
    internal static class DropdownExtensions
    {
        public static FilterMode GetFilterMode(this Dropdown<string> filterModeSettingDropdown, bool useGlobalSettingsIfEnabled = true)
        {
            if (useGlobalSettingsIfEnabled && IDontCareMenu.Instance.AreGlobalSettingsEnabled)
                return (FilterMode)IDontCareMenu.Instance.GlobalFilterMode.SelectedIndex;

            return (FilterMode)filterModeSettingDropdown.SelectedIndex;
        }
    }
}
