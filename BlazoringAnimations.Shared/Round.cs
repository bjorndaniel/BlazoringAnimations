namespace BlazoringAnimations.Shared
{
    public class Round
    {
        public int Score { get; set; }
        public int Slope { get; set; }
        public double Rating { get; set; }
        public string RatingString
        {
            get
            {
                return Rating.ToString();
            }
            set
            {
                if(double.TryParse(value, out double rating))
                {
                    Rating = rating;
                }
            }
        }
        public int Par { get; set; }
    }
}
