using Microsoft.Extensions.DependencyInjection;
using NetwiseApp.Services;
using System;

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
            catService.GetCatFactAndSaveToFile(filePath);
            Console.ReadLine();
        }
    }
}
