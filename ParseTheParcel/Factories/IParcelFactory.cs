using ParseTheParcel.Models;

namespace ParseTheParcel.Factories
{
    public interface IParcelFactory
    {
        Parcel CreateParcel(string[] dimensionsAndWeight);
    }
}