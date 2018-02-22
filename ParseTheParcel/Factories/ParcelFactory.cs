using System;
using System.Linq;
using ParseTheParcel.Exceptions;
using ParseTheParcel.Models;

namespace ParseTheParcel.Factories
{
    public class ParcelFactory : IParcelFactory
    {
        private const int NumberOfDimensions = 3;
        private const int WeightArgPosition = NumberOfDimensions;

        public Parcel CreateParcel(string[] dimensionsAndWeight)
        {
            if (dimensionsAndWeight.Length != NumberOfDimensions + 1)
            {
                throw new InvalidNumberOfArgumentsException("A dimension or weight argument has not been given.");
            }

            var parsedDimensionsAndWeight = dimensionsAndWeight.Select(dow => ParseDimensionOrWeight(dow)).ToArray();

            // So that the order a user enters dimensions doesn't result in an incorrect cost.
            var orderedDimensions = parsedDimensionsAndWeight.Take(NumberOfDimensions).OrderBy(d => d).ToArray();
            var dimensions = new Dimensions(
                orderedDimensions[0],
                orderedDimensions[1],
                orderedDimensions[2]
            );

            return new Parcel(
                dimensions,
                parsedDimensionsAndWeight[WeightArgPosition]
            );
        }

        private static double ParseDimensionOrWeight(string dimensionOrWeight)
        {
            // Perhaps should instead require dimensions to be ints as in mm?
            double parsedValue;
            if (!Double.TryParse(dimensionOrWeight, out parsedValue))
            {
                throw new InvalidArgumentTypeException("A non numeric value has been given.");
            }

            // Using !> rather than <= to avoid floating point number comparison errors,
            // although shouldn't be necessary as not expecting super high precision input!
            if (!(parsedValue > 0.0))
            {
                throw new InvalidArgumentValueException("A value equal to or less than 0 has been given.");
            }

            return parsedValue;
        }
    }
}