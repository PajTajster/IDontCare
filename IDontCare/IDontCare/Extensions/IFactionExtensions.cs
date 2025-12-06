using TaleWorlds.CampaignSystem;

namespace IDontCare.Extensions
{
    internal static class IFactionExtensions
    {
        public static bool IsAtWarOrAlliedWithPlayer(this IFaction faction)
        {
            if (faction.Id == Hero.MainHero.MapFaction.Id || faction.Id == Hero.MainHero.Clan?.Kingdom?.Id)
                return true;

            var factionsStance = Hero.MainHero.MapFaction.GetStanceWith(faction);
            return factionsStance.IsAtWar;
        }
    }
}
