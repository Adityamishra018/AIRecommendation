namespace AIRecommendation.RatingsAggregation
{
    public class AgeGroup
    {
        public static (int,int) GetGroup(int age)
        {
            if (age >= 1 && age <= 16)
                return (1, 16);
            else if (age >= 17 && age <= 30)
                return (17, 30);
            else if (age >= 31 && age <= 50)
                return (31, 50);
            else if (age >= 51 && age <= 60)
                return (51, 60);
            else
                return (60, 100);

        }
    }
}
