namespace ParseTheParcel.Models
{
    public class ParcelSize
    {
        public Dimensions Dimensions { get; }
        public decimal Cost { get; }
 
        public ParcelSize(Dimensions dimensions, decimal cost)
        {
            Dimensions = dimensions;
            Cost = cost;
        }
    }
}