using System;
using Microsoft.Extensions.DependencyInjection;
using ParseTheParcel.Services;

namespace ParseTheParcel
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IParsingService, ParsingService>()
                .BuildServiceProvider();

            var parser = serviceProvider.GetService<IParsingService>();
            var result = parser.ParseParcel(args);
            Console.WriteLine(result);
        }
    }
}
