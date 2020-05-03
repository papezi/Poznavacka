using Poznavacka.Data.DbSystem.Learning;
using Poznavacka.Data.Enums;

namespace Poznavacka.Areas.ContentLearn.Models.Strategies
{
    public static class ItemValidator
    {
        public static bool Validate(LearningSet set, LearningSetItem item)
        {
            if (item.Class > set.Class)
            {
                return false;
            }
            if (set.OccurenceCR != OccurenceCREnum.neuvedeno && item.OccurenceCR != set.OccurenceCR)
            {
                return false;
            }
            return true;
        }
    }
}
