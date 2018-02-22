using System;
using ParseTheParcel.Exceptions;
using ParseTheParcel.Factories;

namespace ParseTheParcel.Services
{
    public class ParsingService : IParsingService
    {
        private readonly IParcelFactory parcelFactory;
        private readonly IWeighingService weighingService;
        private readonly IPricingService pricingService;

        public ParsingService(IParcelFactory parcelFactory, IWeighingService weighingService, IPricingService pricingService)
        {
            this.parcelFactory = parcelFactory;
            this.weighingService = weighingService;
            this.pricingService = pricingService;
        }

        public string ParseParcel(string[] dimensionsAndWeight)
        {
            try
            {
                var parcel = parcelFactory.CreateParcel(dimensionsAndWeight);

                if (weighingService.IsOverMaxWeight(parcel))
                {
                    var maxWeight = weighingService.GetMaxWeight();
                    return $"Parcels heavier than {maxWeight}kg cannot be shipped.";
                }

                if (pricingService.IsOverMaxSize(parcel))
                {
                    var maxDimensions = pricingService.GetMaxDimensions();
                    // Print in length, breadth, height order of size for conistency with question.
                    return $"Parcels larger than {maxDimensions.MidDimension}mm x {maxDimensions.LongDimension}mm x " +
                        $"{maxDimensions.ShortDimension}mm cannot be shipped.";
                }

                var cost = pricingService.CalculateShippingCost(parcel);
                return $"Cost to ship parcel: ${cost.ToString("#,0.00")}";
            }
            catch (InvalidNumberOfArgumentsException)
            {
                return "Please enter all three dimensions of the parcel and its weight.\n" +
                    "Usage: dotnet run <length> <breadth> <height> <weight>";
            }
            catch (InvalidArgumentTypeException)
            {
                return "Please enter only numeric values.";
            }
            catch (InvalidArgumentValueException)
            {
                return "Please enter values greater than 0.";
            }
        }
    }
}
