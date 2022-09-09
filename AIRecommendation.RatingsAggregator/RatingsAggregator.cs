using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIRecommendation.DataLoader;

namespace AIRecommendation.RatingsAggregation
{
    public class RatingsAggregator : IRatingsAggregator
    {
        public Dictionary<string, List<int>> Aggregate(BookDetails details, Preference preference)
        {
            Dictionary<string, List<int>> result = new Dictionary<string, List<int>>();
            List<int> userids = new List<int>();

            Parallel.ForEach(details.Users, (user) =>
            {
                (int lower, int upper) group = AgeGroup.GetGroup(preference.Age);
                if (user.Age >= group.lower && user.Age <= group.upper && user.State == preference.State)
                {
                    lock (result)
                    {
                        userids.Add(user.UserID);
                    }
                }
            });

            Parallel.ForEach(details.Ratings, (rating) =>
            {
                if (userids.Contains(rating.UserID) || rating.ISBN == preference.ISBN)
                {
                    if (!result.ContainsKey(rating.ISBN))
                    {
                        lock (preference)
                        {
                            result.Add(rating.ISBN, new List<int>());
                            result[rating.ISBN].Add(rating.Rating);
                        }
                    }
                    else
                    {
                        lock (preference)
                        {
                            result[rating.ISBN].Add(rating.Rating);
                        }
                    }
                }
            });
            return result;
        }
    }
}
