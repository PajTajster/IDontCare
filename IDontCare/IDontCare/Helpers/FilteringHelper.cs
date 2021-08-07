using IDontCare.Constants;

namespace IDontCare.Helpers
{
    public static class FilteringHelper
    {
        public static bool SwitchShouldPlayerCareDependingOnFilterMode(int filterModeSelectedIndex)
        {
            if (filterModeSelectedIndex == (int)FilterMode.FilterAll)
            {
                return false;
            }
            if (filterModeSelectedIndex == (int)FilterMode.FilterNothing)
            {
                return true;
            }

            // Shouldn't happen
            return false;
        }
    }
}
