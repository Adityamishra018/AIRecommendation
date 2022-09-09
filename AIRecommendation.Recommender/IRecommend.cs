using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendation.Recommendation
{
    public interface IRecommend
    {
        double GetCoefficient(int[] baseArray, int[] other);
    }
}
