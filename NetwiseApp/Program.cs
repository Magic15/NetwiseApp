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
           .AddSingleton<IFileService, FileService>()
           .AddSingleton<ICatService, CatService>()
           .BuildServiceProvider();

            var catService = serviceProvider.GetService<ICatService>();

            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var filePath = $"{System.IO.Path.GetDirectoryName(path)}\\catFactsFile.txt";
            Console.WriteLine("Started getting cat facts from endpoint");

            var timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < 100; i++)
                catService.GetCatFactAndSaveToFile(filePath);
            timer.Stop();
            Console.WriteLine("saving to file ended");
            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);
            Console.ReadLine();
        }
    }
}
