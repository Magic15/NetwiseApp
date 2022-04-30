using Microsoft.Extensions.DependencyInjection;
using NetwiseApp.Services;
using Sharprompt;
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
         
            Console.WriteLine("Hello in cat facts appliaction");
            string isSynchronous = Prompt.Select("Select way to get cat facts", new[] { "synchronous requests", "asynchronous requets"});
            int nTimes = Prompt.Input<int>("How many cat facts do you want to get?");
            
            if (isSynchronous.Equals("synchronous requests"))
                catFactsCreator.CreateCatFacts(nTimes);
            else
                catFactsCreator.CreateCatFactsAsync(nTimes);
             
           Console.ReadLine();
        }
    }
}
