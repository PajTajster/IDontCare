using IDontCare.Constants;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

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

        public static bool IsAnyFactionAllyOrEnemyOfPlayer(IList<IFaction> factions)
        {
            var playerFaction = Hero.MainHero.MapFaction;
            foreach (var faction in factions)
            {
                if (faction is null)
                {
                    continue;
                }

                // Faction is treated as neutral to itself, e.g.: Vlandia to Vlandia stance is Neutral
                if (playerFaction?.Name == faction?.Name)
                {
                    return true;
                }
                else
                {
                    var factionsStance = playerFaction.GetStanceWith(faction);
                    if (factionsStance.IsAllied || factionsStance.IsAtWar)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static void DebugLog(string typeName, InformationType informationType)
        {
            InformationManager.DisplayMessage(new InformationMessage($"[I Don't Care DEBUG] Blocked message! Object name: {typeName}, type: {informationType}"));
        }
    }
}
