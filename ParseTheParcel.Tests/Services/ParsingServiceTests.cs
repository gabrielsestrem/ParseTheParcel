
using System;
using Xunit;
using ParseTheParcel.Services;

namespace ParseTheParcel.Tests.Services
{
    public class ParsingServiceTests
    {
        private readonly ParsingService parsingService;

        public ParsingServiceTests()
        {
            parsingService = new ParsingService();
        }

        [Fact]
        public void ParseParcel_ShouldReturnUsageMessageIfFourArgumentsAreNotProvided()
        {
            // Given
            var args = new string[]
            {
                "150",
                "200",
                "100"
            };

            // When
            var result = parsingService.ParseParcel(args);

            // Then
            Assert.Contains("Usage:", result);
        }
    }
}
