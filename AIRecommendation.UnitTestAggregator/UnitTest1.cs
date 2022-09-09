using AIRecommendation.DataLoader;
using AIRecommendation.RatingsAggregation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using Moq;

namespace AIRecommendation.UnitTestAggregator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /* This is integration testing , use mock loader and inject it to ratingsAggregator for proper unit testing.
             * or use mockingFramework to generate mock loader ex Moq framework
             * 
             * Mock<IDataLoader> mockLoader = new Mock<IDataLoader>();
             * mockLoader.Load(()=>{}).Returns(new Book());
             * 
             * you can check if mock invokes a method or not
             */

            CSVDataLoader loader = new CSVDataLoader();
            BookDetails details = loader.Load();

            Preference wish = new Preference() { Age = 20, State = "new york",ISBN = "0155061224" };

            RatingsAggregator aggregator = new RatingsAggregator();

            var result = aggregator.Aggregate(details, wish);
            
            Assert.AreEqual(5821, result.Count,20);
        }
    }
}
