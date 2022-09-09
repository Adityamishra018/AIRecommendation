namespace AIRecommendation.DataLoader
{
    public class Book
    {
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public short YearOfPublication { get; set; }
        public string ImgUrlSmall { get; set; }
        public string ImgUrlMedium { get; set; }
        public string ImgUrlLarge { get; set; }
        public override string ToString()
        {
            return $"{ISBN} : {BookTitle} {BookAuthor} {YearOfPublication}";
        }

    }

}
