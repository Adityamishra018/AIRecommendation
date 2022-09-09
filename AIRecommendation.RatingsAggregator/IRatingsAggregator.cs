using System.Collections.Generic;
using AIRecommendation.DataLoader;

namespace AIRecommendation.RatingsAggregation
{
    interface IRatingsAggregator
    {
        Dictionary<string, List<int>> Aggregate(BookDetails details, Preference preference);
    }
}
