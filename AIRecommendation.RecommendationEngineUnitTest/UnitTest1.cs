using AIRecommendation.DataLoader;
using AIRecommendation.Engine;
using AIRecommendation.RatingsAggregation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace AIRecommendation.RecommendationEngineUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Preference preference = new Preference() { Age=50,State="new york",ISBN = "0155061224" };
            RecommendationEngine engine = new RecommendationEngine();
            List<Book> books = engine.Recommend(preference, 10);
            Assert.AreEqual(10, books.Count);
        }
    }
}
