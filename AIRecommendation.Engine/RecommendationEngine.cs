using AIRecommendation.DataService;
using AIRecommendation.DataLoader;
using AIRecommendation.RatingsAggregation;
using AIRecommendation.Recommendation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendation.Engine
{
    public class RecommendationEngine
    {
        BooksDataService dataService = new BooksDataService();
        BookDetails details;
        Task t1;

        public RecommendationEngine()
        {
            t1 = Task.Run(() =>
            {
                details = dataService.GetBookDetails();
            });
        }

        public List<Book> Recommend(Preference preference,int limit)
        {
            List<Book> result = new List<Book>();

            RatingsAggregator aggregator = new RatingsAggregator();
            t1.Wait();

            Recommender recommender = new Recommender();
            List<(double, string)> Isbns = new List<(double, string)>(); 

            var dict = aggregator.Aggregate(details, preference);
            int[] baseArray = dict[preference.ISBN].ToArray();

            dict.Remove(preference.ISBN);

            foreach(var item in dict)
            {
                int[] other = item.Value.ToArray();
                Isbns.Add((recommender.GetCoefficient(baseArray, item.Value.ToArray()),item.Key));
            }

            Isbns.Sort((a, b) =>
            {
                if(a.Item1 > b.Item1)
                    return -1;
                return 0;
            });
            
            foreach(var isbn in Isbns)
            {
                foreach(var book in details.Books)
                {
                    if(book.ISBN == isbn.Item2)
                    {
                        //Console.WriteLine($"{isbn.Item1} for {isbn.Item2}");
                        result.Add(book);
                        if (result.Count == limit)
                            return result;
                    }
                }

            }
            return result;
        }
    }
}
