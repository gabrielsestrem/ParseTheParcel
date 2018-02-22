
using System;
using Moq;
using Xunit;
using ParseTheParcel.Exceptions;
using ParseTheParcel.Factories;
using ParseTheParcel.Models;
using ParseTheParcel.Services;

namespace ParseTheParcel.Tests.Services
{
    public class ParsingServiceTests
    {
        private readonly Mock<IParcelFactory> mockParcelFactory;
        private readonly Mock<IWeighingService> mockWeighingService;
        private readonly Mock<IPricingService> mockPricingService;
        private readonly ParsingService parsingService;

        public ParsingServiceTests()
        {
            mockParcelFactory = new Mock<IParcelFactory>();
            mockWeighingService = new Mock<IWeighingService>();
            mockPricingService = new Mock<IPricingService>();
            parsingService = new ParsingService(
                mockParcelFactory.Object,
                mockWeighingService.Object,
                mockPricingService.Object
            );
        }

        [Fact]
        public void ParseParcel_ShouldReturnUsageMessageIfCreateParcelThrowsInvalidNumberOfArgumentsException()
        {
            // Given
            mockParcelFactory.Setup(parcelFactory => parcelFactory.CreateParcel(It.IsAny<string[]>()))
                .Throws(new InvalidNumberOfArgumentsException());

            // When
            var result = parsingService.ParseParcel(new string[] {});

            // Then
            Assert.Contains("all three dimensions of the parcel and its weight", result);
            Assert.Contains("Usage: dotnet run <length> <breadth> <height> <weight>", result);
        }

        [Fact]
        public void ParseParcel_ShouldReturnNumericValuesMessageIfCreateParcelThrowsInvalidArgumentTypeException()
        {
            // Given
            mockParcelFactory.Setup(parcelFactory => parcelFactory.CreateParcel(It.IsAny<string[]>()))
                .Throws(new InvalidArgumentTypeException());

            // When
            var result = parsingService.ParseParcel(new string[] {});

            // Then
            Assert.Contains("only numeric values", result);
        }

        [Fact]
        public void ParseParcel_ShouldReturnGreaterThanZeroValuesMessageIfCreateParcelThrowsInvalidArgumentValueException()
        {
            // Given
            mockParcelFactory.Setup(parcelFactory => parcelFactory.CreateParcel(It.IsAny<string[]>()))
                .Throws(new InvalidArgumentValueException());

            // When
            var result = parsingService.ParseParcel(new string[] {});

            // Then
            Assert.Contains("values greater than 0", result);
        }

        [Fact]
        public void ParseParcel_ShouldReturnMaxWeightMessageIfWeighingServiceReturnsOverMaxWeight()
        {
            // Given
            var parcel = new Parcel(new Dimensions(100, 150, 200), 26);
            var maxWeight = 25.0;
            mockParcelFactory.Setup(pf => pf.CreateParcel(It.IsAny<string[]>()))
                .Returns(parcel);
            mockWeighingService.Setup(ws => ws.IsOverMaxWeight(parcel)).Returns(true);
            mockWeighingService.Setup(ws => ws.GetMaxWeight()).Returns(maxWeight);

            // When
            var result = parsingService.ParseParcel(new string[] {});

            // Then
            Assert.Contains("heavier than 25kg cannot be shipped", result);
        }

        [Fact]
        public void ParseParcel_ShouldReturnMaxDimensionsMessageIfPricingServiceReturnsOverMaxSize()
        {
            // Given
            var parcel = new Parcel(new Dimensions(100, 150, 200), 26);
            var maxDimensions = new Dimensions(90, 140, 190);
            mockParcelFactory.Setup(pf => pf.CreateParcel(It.IsAny<string[]>()))
                .Returns(parcel);
            mockWeighingService.Setup(ws => ws.IsOverMaxWeight(parcel)).Returns(false);
            mockPricingService.Setup(ps => ps.IsOverMaxSize(parcel)).Returns(true);
            mockPricingService.Setup(ps => ps.GetMaxDimensions()).Returns(maxDimensions);

            // When
            var result = parsingService.ParseParcel(new string[] {});

            // Then
            Assert.Contains("larger than 140mm x 190mm x 90mm cannot be shipped", result);
        }

        [Fact]
        public void ParseParcel_ShouldReturnShippingCostMessage()
        {
            // Given
            var parcel = new Parcel(new Dimensions(100, 150, 200), 26);
            var shippingCost = 7.5m;
            mockParcelFactory.Setup(pf => pf.CreateParcel(It.IsAny<string[]>()))
                .Returns(parcel);
            mockWeighingService.Setup(ws => ws.IsOverMaxWeight(parcel)).Returns(false);
            mockPricingService.Setup(ps => ps.IsOverMaxSize(parcel)).Returns(false);
            mockPricingService.Setup(ps => ps.CalculateShippingCost(parcel)).Returns(shippingCost);

            // When
            var result = parsingService.ParseParcel(new string[] {});

            // Then
            Assert.Contains("Cost to ship parcel: $7.50", result);
        }
    }
}
