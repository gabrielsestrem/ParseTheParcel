using System;

namespace ParseTheParcel.Models
{
    public class Dimensions
    {
        public double ShortDimension { get; }
        public double MidDimension { get; }
        public double LongDimension { get; }

        public Dimensions(double shortDimension, double midDimension, double longDimension)
        {
            if (shortDimension > midDimension || midDimension > longDimension)
            {
                throw new ArgumentException("Dimensions must be created in ascending order of length.");
            }

            ShortDimension = shortDimension;
            MidDimension = midDimension;
            LongDimension = longDimension;
        }

        public bool IsLargerOrEqualToInEveryDimensionThan(Dimensions dimensions)
        {
            return !(ShortDimension < dimensions.ShortDimension ||
                MidDimension < dimensions.MidDimension ||
                LongDimension < dimensions.LongDimension);
        }
    }
}