using Microsoft.Extensions.DependencyInjection;
using NetwiseApp.Services;
using System;
using System.Diagnostics;
namespace NetwiseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
           .AddTransient<IFileService, FileService>()
           .AddTransient<ICatService, CatService>()      
           .BuildServiceProvider();

            var catFactsCreator = ActivatorUtilities.CreateInstance<CatFactsCreator>(serviceProvider);

            bool isSynchronous = false;
           
            if (isSynchronous)            
                catFactsCreator.CreateCatFacts(100);            
            else           
                catFactsCreator.CreateCatFactsAsync(100);                            
            Console.ReadLine();
        }
    }
}
