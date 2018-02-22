using ParseTheParcel.Models;

namespace ParseTheParcel.Services
{
    // Arguably not necessary to be its own service but seems like a reasonable 
    // place this information to live as it's abstracted and extensible.
    public class WeighingService : IWeighingService
    {
        private const double MaxWeight = 25.0;

        public bool IsOverMaxWeight(Parcel parcel)
        {
            return parcel.Weight > MaxWeight;
        }

        public double GetMaxWeight()
        {
            return MaxWeight;
        }
    }
}