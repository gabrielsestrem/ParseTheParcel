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
            parser.parseParcel(args);
        }
    }
}
