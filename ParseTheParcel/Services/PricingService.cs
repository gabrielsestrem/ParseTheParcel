using System.Linq;
using ParseTheParcel.Models;

namespace ParseTheParcel.Services
{
    public class PricingService : IPricingService
    {
        public decimal? CalculateShippingCost(Parcel parcel)
        {
            var sizesInAscendingOrder = ParcelSizes.GetParcelSizesInAscendingOrder();
            var parcelSize = sizesInAscendingOrder.FirstOrDefault(ps => ps.Dimensions.IsLargerOrEqualToInEveryDimensionThan(parcel.Dimensions));

            return parcelSize?.Cost;
        }

        public bool IsOverMaxSize(Parcel parcel)
        {
            return !GetMaxDimensions().IsLargerOrEqualToInEveryDimensionThan(parcel.Dimensions);
        }

        public Dimensions GetMaxDimensions()
        {
            return ParcelSizes.GetParcelSizesInAscendingOrder().Last().Dimensions;
        }
    }
}