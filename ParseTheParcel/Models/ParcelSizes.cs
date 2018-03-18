using System.Collections.Generic;

namespace ParseTheParcel.Models
{
    public static class ParcelSizes
    {
        public static List<ParcelSize> GetParcelSizesInAscendingOrder()
        {
            return new List<ParcelSize>
            {
                new ParcelSize("Small", new Dimensions(150.0, 200.0, 300.0), 5.0m),
                new ParcelSize("Medium", new Dimensions(200.0, 300.0, 400.0), 7.5m),
                new ParcelSize("Large", new Dimensions(250.0, 400.0, 600.0), 8.5m)
            };
        }
    }
}