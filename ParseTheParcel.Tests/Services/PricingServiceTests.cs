
using System;
using Xunit;
using ParseTheParcel.Models;
using ParseTheParcel.Services;

namespace ParseTheParcel.Tests.Services
{
    public class PricingServiceTests
    {
        private readonly PricingService pricingService;

        public PricingServiceTests()
        {
            pricingService = new PricingService();
        }

        [Theory]
        [InlineData(new double[] {251, 399, 599})]
        [InlineData(new double[] {249, 501, 599})]
        [InlineData(new double[] {249, 399, 601})]
        [InlineData(new double[] {251, 401, 599})]
        [InlineData(new double[] {251, 399, 601})]
        [InlineData(new double[] {249, 401, 601})]
        [InlineData(new double[] {251, 401, 601})]
        public void IsOverMaxSize_ShouldReturnTrueIfAnyDimensionOfParcelIsLargerThanMaxDimensions(double[] dimensions)
        {
            // Given
            var parcel = new Parcel(new Dimensions(dimensions[0], dimensions[1], dimensions[2]), 5);

            // When
            var result = pricingService.IsOverMaxSize(parcel);

            // Then
            Assert.True(result);
        }

        [Fact]
        public void IsOverMaxSize_ShouldReturnFalseIfAllDimensionsOfParcelAreSmallerThanMaxDimensions()
        {
            // Given
            var parcel = new Parcel(new Dimensions(249, 399, 599), 5);

            // When
            var result = pricingService.IsOverMaxSize(parcel);

            // Then
            Assert.False(result);
        }

        [Fact]
        public void IsOverMaxSize_ShouldReturnFalseIfAllDimensionsOfParcelAreEqualToMaxDimensions()
        {
            // Given
            var parcel = new Parcel(new Dimensions(250, 400, 600), 5);

            // When
            var result = pricingService.IsOverMaxSize(parcel);

            // Then
            Assert.False(result);
        }

        [Fact]
        public void GetMaxDimensions_ShouldReturnMaxDimensions()
        {
            // When
            var result = pricingService.GetMaxDimensions();

            // Then
            Assert.Equal(250, result.ShortDimension);
            Assert.Equal(400, result.MidDimension);
            Assert.Equal(600, result.LongDimension);
        }

        [Theory]
        [InlineData(new double[] {149, 199, 299})]
        [InlineData(new double[] {150, 200, 300})]
        public void CalculateShippingCost_ShouldReturnSmallCostIfParcelSmallerThanOrEqualToSmallDimensions(double[] dimensions)
        {
            // Given
            var parcel = new Parcel(new Dimensions(dimensions[0], dimensions[1], dimensions[2]), 5);

            // When
            var result = pricingService.CalculateShippingCost(parcel);

            // Then
            Assert.Equal(5.0m, result);
        }

        [Theory]
        [InlineData(new double[] {199, 299, 399})]
        [InlineData(new double[] {200, 300, 400})]
        public void CalculateShippingCost_ShouldReturnMediumCostIfParcelSmallerThanOrEqualToMediumDimensions(double[] dimensions)
        {
            // Given
            var parcel = new Parcel(new Dimensions(dimensions[0], dimensions[1], dimensions[2]), 5);

            // When
            var result = pricingService.CalculateShippingCost(parcel);

            // Then
            Assert.Equal(7.5m, result);
        }

        [Theory]
        [InlineData(new double[] {249, 399, 599})]
        [InlineData(new double[] {250, 400, 600})]
        public void CalculateShippingCost_ShouldReturnLargeCostIfParcelSmallerThanOrEqualToLargeDimensions(double[] dimensions)
        {
            // Given
            var parcel = new Parcel(new Dimensions(dimensions[0], dimensions[1], dimensions[2]), 5);

            // When
            var result = pricingService.CalculateShippingCost(parcel);

            // Then
            Assert.Equal(8.5m, result);
        }

        [Fact]
        public void CalculateShippingCost_ShouldThrowIfParcelLargerThanLargeDimensions()
        {
            // Given
            var parcel = new Parcel(new Dimensions(251, 401, 601), 5);

            // When
            Assert.Throws<InvalidOperationException>(() => pricingService.CalculateShippingCost(parcel));
        }
    }
}
