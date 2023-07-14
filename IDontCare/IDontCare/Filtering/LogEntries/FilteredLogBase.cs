using Extensions;
using IDontCare.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;

namespace Filtering.LogEntries
{
    internal abstract class FilteredLogBase
    {
        public abstract bool ShouldPlayerCare(LogEntry logEntry);

        protected bool ShouldPlayerCare(int filterMode, IEnumerable<IFaction> factionsInvolved)
            => factionsInvolved.Any(faction => ShouldPlayerCare(filterMode, faction));

        protected bool ShouldPlayerCare(int filterMode, IFaction factionInvolved)
        {
            var shouldPlayerCare = false;

            switch ((FilterMode)filterMode)
            {
                case FilterMode.Default:
                    shouldPlayerCare = factionInvolved.IsAtWarOrAlliedWithPlayer();
                    break;
                case FilterMode.FilterAll:
                    shouldPlayerCare = false;
                    break;
                case FilterMode.FilterNothing:
                    shouldPlayerCare = true;
                    break;
                case FilterMode.OnlyMe:
                    shouldPlayerCare = true;
                    break;
                case FilterMode.OnlyMyClan:
                    shouldPlayerCare = factionInvolved.IsClan && factionInvolved.Id == Hero.MainHero.Clan?.Id;
                    break;
                case FilterMode.OnlyMyKingdom:
                    shouldPlayerCare = factionInvolved.Id == Hero.MainHero.Clan?.Kingdom?.Id;
                    break;
                default:
                    return false;
            }

            return shouldPlayerCare;
        }

        protected bool ShouldPlayerCare(int filterMode, IEnumerable<Hero> heroesInvolved)
            => heroesInvolved.Any(hero => ShouldPlayerCare(filterMode, hero));

        protected bool ShouldPlayerCare(int filterMode, Hero heroInvolved)
        {
            var shouldPlayerCare = false;

            switch ((FilterMode)filterMode)
            {
                case FilterMode.Default:
                    shouldPlayerCare = heroInvolved.MapFaction?.IsAtWarOrAlliedWithPlayer() ?? false;
                    break;
                case FilterMode.FilterAll:
                    shouldPlayerCare = false;
                    break;
                case FilterMode.FilterNothing:
                    shouldPlayerCare = true;
                    break;
                case FilterMode.OnlyMe:
                    shouldPlayerCare = heroInvolved.Id == Hero.MainHero.Id;
                    break;
                case FilterMode.OnlyMyClan:
                    shouldPlayerCare = heroInvolved.Clan?.Id == Hero.MainHero.Clan?.Id;
                    break;
                case FilterMode.OnlyMyKingdom:
                    shouldPlayerCare = heroInvolved.Clan?.Kingdom?.Id == Hero.MainHero.Clan?.Kingdom?.Id;
                    break;
                default:
                    return false;
            }

            return shouldPlayerCare;
        }

        internal static object GetLogEntryPrivateField(object instance, string fieldName)
        {
            var type = instance?.GetType();
            if (type is null)
            {
                return null;
            }

            var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var field = type.GetField(fieldName, bindFlags);
            return field?.GetValue(instance);
        }
    }
}