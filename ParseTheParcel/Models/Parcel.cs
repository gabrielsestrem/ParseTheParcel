namespace ParseTheParcel.Models
{
    public class Parcel
    {
        public Dimensions Dimensions { get; }
        public double Weight { get; }

        public Parcel(Dimensions dimensions, double weight)
        {
            Dimensions = dimensions;
            Weight = weight;
        }
    }
}