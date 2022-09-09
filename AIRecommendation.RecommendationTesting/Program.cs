using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIRecommendation.Recommendation;

namespace AIRecommendation.RecommenderTesting
{
    internal class Test
    {
        public static void Main(string[] args)
        {
            Recommender rec = new Recommender();

            int[] arr1 = new int[] { 1, 3, 5, 6, 7 };
            int[] arr2 = new int[] { 4, 5, 7, 8, 2 };

            Console.WriteLine(rec.GetCoefficient(arr1, arr2));

        }
    }
}
