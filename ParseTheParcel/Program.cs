using System;
using Microsoft.Extensions.DependencyInjection;
using ParseTheParcel.Factories;
using ParseTheParcel.Services;

namespace ParseTheParcel
{
    class Program
    {
        // Using command line arguments instead of reading input for simpicity.
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IParsingService, ParsingService>()
                .AddSingleton<IWeighingService, WeighingService>()
                .AddSingleton<IPricingService, PricingService>()
                .AddSingleton<IParcelFactory, ParcelFactory>()
                .BuildServiceProvider();

            var parser = serviceProvider.GetService<IParsingService>();
            var result = parser.ParseParcel(args);
            Console.WriteLine(result);
        }
    }
}
