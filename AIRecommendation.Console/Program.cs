using AIRecommendation.DataLoader;
using AIRecommendation.Engine;
using AIRecommendation.RatingsAggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendation.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RecommendationEngine engine = new RecommendationEngine();  //starts loading dataset in another thread
            System.Console.WriteLine("AI Recommendation Engine");
            System.Console.WriteLine("---------------------------------");

            System.Console.Write("Enter Your Age: ");
            byte age = byte.Parse(System.Console.ReadLine());
            System.Console.Write("Enter State: ");
            string state = System.Console.ReadLine();


            //ex : 0155061224 , 014062080X
            System.Console.Write("Enter ISBN: ");
            string isbn = System.Console.ReadLine();

            System.Console.Write("Enter limit: ");
            int limit = int.Parse(System.Console.ReadLine());


            Preference preference = new Preference() { Age=age,State=state.ToLower(),ISBN = isbn.ToUpper()};

            foreach (Book b in engine.Recommend(preference, limit))
            {
                System.Console.WriteLine(b);
            }
        }
    }
}
