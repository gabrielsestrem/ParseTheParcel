using ParseTheParcel.Models;

namespace ParseTheParcel.Services
{
    public class PricingService : IPricingService
    {
        public decimal CalculateShippingCost(Parcel parcel)
        {
            var smallParcelPricer = new ParcelPricer(ParcelSizes.Small);
            var mediumParcelPricer = new ParcelPricer(ParcelSizes.Medium);
            var largeParcelPricer = new ParcelPricer(ParcelSizes.Large);

            smallParcelPricer.SetNextSizeUpPricer(mediumParcelPricer);
            mediumParcelPricer.SetNextSizeUpPricer(largeParcelPricer);

            // Relying on IsOverMaxSize being called first to avoid throwing an exception,
            // perhaps could be a neater way.
            return smallParcelPricer.GetCostFromSize(parcel).Value;
        }

        public bool IsOverMaxSize(Parcel parcel)
        {
            var largeParcelPricer = new ParcelPricer(ParcelSizes.Large);
            return !largeParcelPricer.GetCostFromSize(parcel).HasValue;
        }

        public Dimensions GetMaxDimensions()
        {
            return ParcelSizes.Large.Dimensions;
        }
    }
}