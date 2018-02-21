using System;

namespace ParseTheParcel.Services
{
    public class ParsingService : IParsingService
    {
        public void parseParcel(string[] dimensionsAndWeight)
        {
            if (dimensionsAndWeight.Length != 4)
            {
                Console.WriteLine("Please enter the dimensions and weight of the package in millimeters and kilograms, respectively.");
                Console.WriteLine("Usage: xxx <length> <breadth> <height> <weight>");
                return;
            }
            
            double length, breadth, height, weight;
            var isLengthParsed = Double.TryParse(dimensionsAndWeight[0], out length);
            var isBreadthParsed = Double.TryParse(dimensionsAndWeight[1], out breadth);
            var isHeightParsed = Double.TryParse(dimensionsAndWeight[2], out height);
            var isWeightParsed = Double.TryParse(dimensionsAndWeight[3], out weight);

            var areAllValuesParsed = isLengthParsed && isBreadthParsed && isHeightParsed && isWeightParsed;
            if (!areAllValuesParsed)
            {
                Console.WriteLine("Please ensure all values are numeric.");
                return;
            }

            Console.WriteLine($"{length}, {breadth}, {height}, {weight}");
        }
    }
}
