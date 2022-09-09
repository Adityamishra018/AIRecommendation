using System;
using System.Linq;

namespace AIRecommendation.Recommendation
{
    public class Recommender : IRecommend
    {
        void _preprocess(ref int[] a,ref int[] b)
        {
            if(a.Length != b.Length)
                Array.Resize(ref b,a.Length);
                
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] == 0 || b[i] == 0)
                {
                    if (a[i]<10)
                        a[i] += 1;
                    if (b[i]<10)
                        b[i] += 1;
                }
            }
        }
        public double GetCoefficient(int[] baseArray, int[] other)
        {
            _preprocess(ref baseArray, ref other);

            int sigmaxy = 0,sigmay = 0,sigmax=0,sigmaxx=0,sigmayy=0;
            
            foreach(int i in Enumerable.Range(0, baseArray.Length))
            {
                sigmaxy += baseArray[i]* other[i];
            }

            for (int i = 0; i < baseArray.Length; i++)
            {
                sigmax += baseArray[i];
                sigmaxx += baseArray[i] * baseArray[i];
            }

            for (int i = 0; i < other.Length; i++)
            {
                sigmay += other[i];
                sigmayy += other[i] * other[i];
            }

            double val = ((baseArray.Length * sigmaxy) - (sigmax) * (sigmay)) / Math.Sqrt((baseArray.Length * sigmaxx - sigmax * sigmax) * (baseArray.Length * sigmayy - sigmay * sigmay));

            if (double.IsNaN(val))
            {
                return -1;
            }
            return val;

        }
    }
}
