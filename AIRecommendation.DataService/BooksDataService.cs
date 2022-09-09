using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIRecommendation.DataLoader;

namespace AIRecommendation.DataService
{
    public class BooksDataService
    {
        IDataCacher dataCacher = new MemDataCacher();
        public BookDetails GetBookDetails()
        {
            if(dataCacher.GetData() != null)
                return dataCacher.GetData();

            DataLoaderFactory factory = DataLoaderFactory.GetInstance;
            IDataLoader loader =  factory.GetDataLoader();

            dataCacher.SetData(loader.Load());
            return dataCacher.GetData();
        }

    }
}
