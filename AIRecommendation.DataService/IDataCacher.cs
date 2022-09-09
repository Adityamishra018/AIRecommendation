using AIRecommendation.DataLoader;

namespace AIRecommendation.DataService
{
    public interface IDataCacher
    {
        BookDetails GetData();
        void SetData(BookDetails data);
    }
}
