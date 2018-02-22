
using System;
using Xunit;
using ParseTheParcel.Models;
using ParseTheParcel.Services;

namespace ParseTheParcel.Tests.Services
{
    public class WeighingServiceTests
    {
        private readonly WeighingService weighingService;

        public WeighingServiceTests()
        {
            weighingService = new WeighingService();
        }

        [Fact]
        public void IsOverMaxWeight_ShouldReturnTrueIfParcelIsOverMaxWeight()
        {
            // Given
            var parcel = new Parcel(new Dimensions(100, 150, 200), 26);

            // When
            var result = weighingService.IsOverMaxWeight(parcel);

            // Then
            Assert.True(result);
        }

        [Fact]
        public void IsOverMaxWeight_ShouldReturnFalseIfParcelIsUnderMaxWeight()
        {
            // Given
            var parcel = new Parcel(new Dimensions(100, 150, 200), 24);

            // When
            var result = weighingService.IsOverMaxWeight(parcel);

            // Then
            Assert.False(result);
        }

        [Fact]
        public void IsOverMaxWeight_ShouldReturnFalseIfParcelIsEqualToMaxWeight()
        {
            // Given
            var parcel = new Parcel(new Dimensions(100, 150, 200), 25);

            // When
            var result = weighingService.IsOverMaxWeight(parcel);

            // Then
            Assert.False(result);
        }

        [Fact]
        public void GetMaxWeight_ShouldReturnMaxWeight()
        {
            // When
            var result = weighingService.GetMaxWeight();

            // Then
            Assert.Equal(25, result);
        }
    }
}
