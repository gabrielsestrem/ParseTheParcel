namespace ParseTheParcel.Models
{
    public class ParcelSize
    {
        public string Size { get; }
        public Dimensions Dimensions { get; }
        public decimal Cost { get; }
 
        public ParcelSize(string size, Dimensions dimensions, decimal cost)
        {
            Size = size;
            Dimensions = dimensions;
            Cost = cost;
        }
    }
}