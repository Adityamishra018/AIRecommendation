using System;
using AIRecommendation.DataLoader;

namespace AIRecommendation.DataService
{
    public class MemDataCacher : IDataCacher
    {
        private BookDetails details;
        public BookDetails GetData()
        {
            return details;
        }

        public void SetData(BookDetails data)
        {
            details = data;
        }
    }
}
