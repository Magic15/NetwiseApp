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
            string isSynchronous;
            int nTimes;
            string quit = "repeat";

            Console.WriteLine("Hello in cat facts console appliaction");

            while (quit.Equals("repeat"))
            {
                isSynchronous = Prompt.Select("Select way to get cat facts", new[] { "synchronous requests", "asynchronous requests" });
                nTimes = Prompt.Input<int>("How many cat facts do you want to get?");
                
                if (isSynchronous.Equals("synchronous requests"))
                    catFactsCreator.CreateCatFacts(nTimes);
                else
                    catFactsCreator.CreateCatFactsAsync(nTimes);

                quit = Prompt.Select("Do you want to repeat process?",  new[] { "repeat", "quit" });             
            }                                   
        }
    }
}
