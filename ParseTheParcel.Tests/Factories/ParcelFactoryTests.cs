using System;
using Xunit;
using ParseTheParcel.Exceptions;
using ParseTheParcel.Models;
using ParseTheParcel.Factories;

namespace ParseTheParcel.Tests.Factories
{
    public class ParcelFactoryTests
    {
        private readonly ParcelFactory parcelFactory;

        public ParcelFactoryTests()
        {
            parcelFactory = new ParcelFactory();
        }

        [Theory]
        [InlineData()]
        [InlineData("150")]
        [InlineData("150", "200")]
        [InlineData("150", "200", "100")]
        [InlineData("150", "200", "100", "5", "10")]
        public void CreateParcel_ShouldThrowIfFewerOrMoreThanFourArgsAreProvided(params string[] args)
        {
            // When
            Assert.Throws<InvalidNumberOfArgumentsException>(() => parcelFactory.CreateParcel(args));
        }

        [Theory]
        [InlineData("length", "200", "100", "5")]
        [InlineData("150", "breadth", "100", "5")]
        [InlineData("150", "200", "height", "5")]
        [InlineData("150", "200", "100", "weight")]
        public void CreateParcel_ShouldThrowIfAnyArgIsNotNumeric(params string[] args)
        {
            // When
            Assert.Throws<InvalidArgumentTypeException>(() => parcelFactory.CreateParcel(args));
        }

        [Theory]
        [InlineData("0", "200", "100", "5")]
        [InlineData("150", "0", "100", "5")]
        [InlineData("150", "200", "0", "5")]
        [InlineData("150", "200", "100", "0")]
        public void CreateParcel_ShouldThrowIfArgIsNotGreaterThanZero(params string[] args)
        {
            // When
            Assert.Throws<InvalidArgumentValueException>(() => parcelFactory.CreateParcel(args));
        }

        [Fact]
        public void CreateParcel_ShouldCreateAParcel()
        {
            // Given
            var args = new string[] {"150", "200", "100", "5"};

            // When
            var result = parcelFactory.CreateParcel(args);

            // THen
            Assert.Equal(100, result.Dimensions.ShortDimension);
            Assert.Equal(150, result.Dimensions.MidDimension);
            Assert.Equal(200, result.Dimensions.LongDimension);
            Assert.Equal(5, result.Weight);
        }
    }
}