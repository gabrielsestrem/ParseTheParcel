namespace ParseTheParcel.Models
{
    public class ParcelPricer
    {
        private readonly ParcelSize parcelSize;
        private ParcelPricer nextSizeUpPricer;

        public ParcelPricer(ParcelSize parcelSize)
        {
            this.parcelSize = parcelSize;
        }

        public void SetNextSizeUpPricer(ParcelPricer nextSizeUpPricer)
        {
            this.nextSizeUpPricer = nextSizeUpPricer;
        }

        public decimal? GetCostFromSize(Parcel parcel)
        {
            if (parcelSize.Dimensions.IsLargerOrEqualToInEveryDimensionThan(parcel.Dimensions))
            {
                return parcelSize.Cost;
            }

            if (nextSizeUpPricer != null)
            {
                return nextSizeUpPricer.GetCostFromSize(parcel);
            }

            return null;
        }
    }
}