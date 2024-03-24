using IDontCare.Menu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IDontCare.Filtering.ModCompatibilites
{
    internal static class FilteredStrings
    {
        public static HashSet<string> IdsToSearch = new HashSet<string>();

        public static void BuildFilteringStrings()
        {
            var menu = IDontCareMenu.Instance;

            var filteringStrings = menu.AdvancedFilteringFilteredStrings
                                       .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Distinct()
                                       .ToHashSet();

            UpdateFilteringStringsWithMenuFlags(ref filteringStrings, ref menu);
            menu.AdvancedFilteringFilteredStrings = string.Join(";", filteringStrings);

            IdsToSearch = filteringStrings;
        }

        private static void UpdateFilteringStringsWithMenuFlags(ref HashSet<string> filteringStrings, ref IDontCareMenu menu)
        {
            HandleModCompatibilityFlag(ref filteringStrings, menu.ServeAsSoldierLogHeroAdoptedChild, "{=FLT0000179}");
            HandleModCompatibilityFlag(ref filteringStrings, menu.ServeAsSoldierLogHeroPromoted, "{=FLT0000000}");
            HandleModCompatibilityFlag(ref filteringStrings, menu.ServeAsSoldierLogHeroRecruited, "{=FLT0000229}");
            HandleModCompatibilityFlag(ref filteringStrings, menu.ServeAsSoldierLogHeroUnemployed, "{=FLT0000230}");

            filteringStrings = filteringStrings.Distinct().ToHashSet();
        }

        private static void HandleModCompatibilityFlag(ref HashSet<string> filteringStrings, bool isEnabled, string filteredString)
        {
            if (isEnabled)
                filteringStrings.Remove(filteredString);
            else
                filteringStrings.Add(filteredString);
        }
    }
}
