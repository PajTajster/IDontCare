using IDontCare.Menu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IDontCare.Filtering
{
    internal static class AdvancedFiltering
    {
        private static readonly object _configurationLock = new object();
        private static bool _isInitialized = false;
        private static readonly HashSet<string> YetToBeInitializedStrings = new HashSet<string>(StringComparer.Ordinal);

        public static HashSet<string> StringsToSearch = new HashSet<string>(StringComparer.Ordinal);

        public static void Initialize()
        {
            lock (_configurationLock)
            {
                _isInitialized = true;
                YetToBeInitializedStrings.UnionWith(BuildFilteringStrings());
                IDontCareMenu.Instance.AdvancedFilteringStringsToFilter = string.Join(";", YetToBeInitializedStrings);

                StringsToSearch = new HashSet<string>(YetToBeInitializedStrings, StringComparer.Ordinal);
                YetToBeInitializedStrings.Clear();
            }
        }

        public static void RefreshStringsToSearch() => StringsToSearch = BuildFilteringStrings();

        public static void HandleGenericStringSearchingFlag(bool shouldFilter, string filteredString)
        {
            lock (_configurationLock)
            {
                bool isSuccess;
                if (shouldFilter)
                    isSuccess = _isInitialized
                        ? StringsToSearch.Add(filteredString)
                        : YetToBeInitializedStrings.Add(filteredString);
                else
                    isSuccess = _isInitialized
                        ? StringsToSearch.Remove(filteredString)
                        : YetToBeInitializedStrings.Remove(filteredString);

                if (isSuccess && _isInitialized && IDontCareMenu.Instance != null)
                    IDontCareMenu.Instance.AdvancedFilteringStringsToFilter = string.Join(";", StringsToSearch);
            }
        }

        private static HashSet<string> BuildFilteringStrings()
            => IDontCareMenu.Instance? // how the fuck it manages to go null is beyond me 
                            .AdvancedFilteringStringsToFilter
                            .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToHashSet()
                ?? new HashSet<string>();
    }
}
