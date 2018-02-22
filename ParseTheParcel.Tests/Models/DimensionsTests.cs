using System;
using Xunit;
using ParseTheParcel.Models;

namespace ParseTheParcel.Tests.Models
{
    public class DimensionsTests
    {
        [Theory]
        [InlineData(new double[] {1, 3, 2})]
        [InlineData(new double[] {2, 1, 3})]
        [InlineData(new double[] {2, 3, 1})]
        [InlineData(new double[] {3, 1, 2})]
        [InlineData(new double[] {3, 2, 1})]
        public void Dimensions_ShouldThrowIfNotProvidedInAscendingOrder(double[] dimensions)
        {
            // When
            Assert.Throws<ArgumentException>(() => new Dimensions(dimensions[0], dimensions[1], dimensions[2]));
        }

        [Fact]
        public void Dimensions_ShouldCreateDimensionsIfProvidedInAscendingOrder()
        {
            // When
            var result = new Dimensions(1, 2, 3);

            // Then
            Assert.Equal(1, result.ShortDimension);
            Assert.Equal(2, result.MidDimension);
            Assert.Equal(3, result.LongDimension);
        }
    }
}