using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AIRecommendation.Recommendation;

namespace AIRecommendation.AIRecommenderUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //[TestInitialize]
        //public void init()
        //{
            //initialze fields used in all test cases
        //}

        //[TestCleanup]
        //public void CleanUp()
        //{
            //cleanup after running all test cases
        //}
        [TestMethod]    
        public void TestMethod1()
        {
            Recommender rec = new Recommender();

            int[] arr1 = new int[] { 1, 3, 5, 6, 7 };
            int[] arr2 = new int[] { 4, 5, 7, 8, 2 };

            Assert.AreEqual(0.06956, rec.GetCoefficient(arr1, arr2), 0.01);

        }

        [TestMethod]
        public void TestMethod2()
        {
            Recommender rec = new Recommender();

            int[] arr1 = new int[] { 1, 3, 5, 6, 7 };
            int[] arr2 = new int[] { 4, 5, 7 };

        }


        [TestMethod]
        public void TestMethod3()
        {
            Recommender rec = new Recommender();

            int[] arr1 = new int[] { 1, 3, 5 };
            int[] arr2 = new int[] { 4, 5, 7, 8, 2 };

            Assert.AreEqual(0.9819, rec.GetCoefficient(arr1, arr2), 0.01);

        }


        [TestMethod]
        public void TestMethod4()
        {
            Recommender rec = new Recommender();

            int[] arr1 = new int[] { 20,24,17 };
            int[] arr2 = new int[] { 30,20,27 };

            Assert.AreEqual(-0.7398, rec.GetCoefficient(arr1, arr2), 0.01);

        }

        [TestMethod]
        public void TestMethod5()
        {
            Recommender rec = new Recommender();

            int[] arr1 = new int[] { 5,0 };
            int[] arr2 = new int[] { 0 };

            Assert.AreEqual(-1, rec.GetCoefficient(arr1, arr2), 0.01);
        }
    }
}
