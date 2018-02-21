using System;

namespace ParseTheParcel.Services
{
    public class ParsingService : IParsingService
    {
        public string ParseParcel(string[] dimensionsAndWeight)
        {
            if (dimensionsAndWeight.Length != 4)
            {
                return "Please enter the dimensions and weight of the package in millimeters and kilograms, respectively.\n" +
                    "Usage: dotnet run <length> <breadth> <height> <weight>";
            }
            
            double length, breadth, height, weight;
            var isLengthParsed = Double.TryParse(dimensionsAndWeight[0], out length);
            var isBreadthParsed = Double.TryParse(dimensionsAndWeight[1], out breadth);
            var isHeightParsed = Double.TryParse(dimensionsAndWeight[2], out height);
            var isWeightParsed = Double.TryParse(dimensionsAndWeight[3], out weight);

            var areAllValuesParsed = isLengthParsed && isBreadthParsed && isHeightParsed && isWeightParsed;
            if (!areAllValuesParsed)
            {
                return "Please ensure all values are numeric.";
            }

            return $"{length}, {breadth}, {height}, {weight}";
        }
    }
}
