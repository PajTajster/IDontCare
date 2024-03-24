using IDontCare.Menu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IDontCare.Filtering
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
            HandleModCompatibilityFlag(ref filteringStrings, menu.FilterServeAsSoldierHeroAdoptedChild, "{=FLT0000179}");
            HandleModCompatibilityFlag(ref filteringStrings, menu.FilterServeAsSoldierHeroPromoted, "{=FLT0000000}");
            HandleModCompatibilityFlag(ref filteringStrings, menu.FilterServeAsSoldierHeroRecruited, "{=FLT0000229}");
            HandleModCompatibilityFlag(ref filteringStrings, menu.FilterServeAsSoldierHeroUnemployed, "{=FLT0000230}");

            HandleModCompatibilityFlag(ref filteringStrings, menu.FilterNewPartUnlocked, "{=p9F90bc0}");
            HandleModCompatibilityFlag(ref filteringStrings, menu.FilterRelationIncreased, "{=o0qwDa0q}");

            filteringStrings = filteringStrings.Distinct().ToHashSet();
        }

        private static void HandleModCompatibilityFlag(ref HashSet<string> filteringStrings, bool shouldFilter, string filteredString)
        {
            if (shouldFilter)
                filteringStrings.Add(filteredString);
            else
                filteringStrings.Remove(filteredString);
        }
    }
}
