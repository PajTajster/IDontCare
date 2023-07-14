using TaleWorlds.CampaignSystem;

namespace Extensions
{
    internal static class IFactionExtensions
    {
        public static bool IsAtWarOrAlliedWithPlayer(this IFaction faction)
        {
            var factionsStance = Hero.MainHero.MapFaction.GetStanceWith(faction);

            return factionsStance.IsAllied || factionsStance.IsAtWar;
        }
    }
}
