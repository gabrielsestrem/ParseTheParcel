namespace ParseTheParcel.Models
{
    public static class ParcelSizes
    {
        public static readonly ParcelSize Small = new ParcelSize(new Dimensions(150.0, 200.0, 300.0), 5.0m);
        public static readonly ParcelSize Medium = new ParcelSize(new Dimensions(200.0, 300.0, 400.0), 7.5m);
        public static readonly ParcelSize Large = new ParcelSize(new Dimensions(250.0, 400.0, 600.0), 8.5m);
    }
}