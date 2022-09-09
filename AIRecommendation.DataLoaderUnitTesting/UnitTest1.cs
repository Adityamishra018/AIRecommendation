using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AIRecommendation.DataLoader;

namespace AIRecommendation.DataLoaderUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CSVDataLoader dataLoader = new CSVDataLoader();
            BookDetails details =  dataLoader.Load();

            Assert.AreEqual(271379, details.Books.Count,20);

            Assert.AreEqual(278855,details.Users.Count,20);

            Assert.AreEqual(1149780, details.Ratings.Count, 100);

        }
    }
}
