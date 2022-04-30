using NetwiseApp.Services;
using System;
using System.Diagnostics;

namespace NetwiseApp
{
    public class CatFactsCreator
    {
        ICatService _catService;
        string _filePath;            
        public CatFactsCreator(ICatService catService)
        {
            _catService = catService;
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            _filePath = $"{System.IO.Path.GetDirectoryName(path)}\\catFactsFile.txt";
        }
        public void CreateCatFacts(int nTimes)
        {
            var timer = new Stopwatch();
            timer.Start();
            _catService.GetCatFactsAndSaveToFile(nTimes, _filePath);
            timer.Stop();
            Console.WriteLine("saving to file ended");
            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);
        }
        public void CreateCatFactsAsync(int nTimes)
        {
            var timer = new Stopwatch();
            timer.Start();
            _catService.GetCatFactsAsyncAndSaveToFile(nTimes, _filePath);
            timer.Stop();
            Console.WriteLine("saving to file ended");
            var timeTaken = timer.Elapsed;
            var foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);
        }
    }
}
