using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AIRecommendation.DataService;

namespace AIRecommendation.DataServiceUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BooksDataService dataService = new BooksDataService();
            var details = dataService.GetBookDetails();
            Assert.AreEqual(271379, details.Books.Count,20);
        }
    }
}
