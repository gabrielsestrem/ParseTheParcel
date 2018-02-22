using ParseTheParcel.Models;

namespace ParseTheParcel.Services
{
    public interface IPricingService
    {
        decimal CalculateShippingCost(Parcel parcel);

        bool IsOverMaxSize(Parcel parcel);

        Dimensions GetMaxDimensions();
    }
}