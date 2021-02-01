namespace Seismic.Clean.Domain.Common.ValueObjects
{
    public class Rating
    {
        public int RatingValue { get; private set; }

        public static Rating OneStar => new Rating(1);
        public static Rating TwoStars => new Rating(2);
        public static Rating ThreeStars => new Rating(3);
        public static Rating FourStars => new Rating(4);
        public static Rating FiveStars => new Rating(5);

        private Rating() { }

        private Rating(int rating)
        {
            if (rating < 0) rating = 0;
            if (rating > 5) rating = 5;

            RatingValue = rating;
        }

        public static Rating From(int rating)
        {
            return new Rating(rating);
        }

        public override bool Equals(object obj)
        {
            return obj is Rating rating &&
                   RatingValue == rating.RatingValue;
        }

        public override int GetHashCode()
        {
            return 842619888 + RatingValue.GetHashCode();
        }
    }
}