using System;
using System.Configuration;
using System.Reflection;
using AIRecommendation.DataLoader;

namespace AIRecommendation.DataService
{
    public class DataLoaderFactory
    {
        public static readonly DataLoaderFactory GetInstance = new DataLoaderFactory();

        DataLoaderFactory() { }

        public IDataLoader GetDataLoader()
        {   
            string classname = ConfigurationManager.AppSettings["DATA"];
            Assembly a = Assembly.Load("AIRecommendation.DataLoader");
            Type type = a.GetType(classname);
            return Activator.CreateInstance(type) as IDataLoader;
        }
    }
}
