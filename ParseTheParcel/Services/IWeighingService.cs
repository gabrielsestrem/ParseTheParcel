using ParseTheParcel.Models;

namespace ParseTheParcel.Services
{
    public interface IWeighingService
    {
        bool IsOverMaxWeight(Parcel parcel);
        
        double GetMaxWeight();
    }
}