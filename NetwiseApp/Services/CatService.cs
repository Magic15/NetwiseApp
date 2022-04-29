using NetwiseApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetwiseApp.Services
{

    public interface ICatService
    {
        void GetCatFactAndSaveToFile(string filePath);
    }
    public class CatService : ICatService
    {
        private readonly string _baseUrl = "https://catfact.ninja";
        private readonly string _filePath = "";
        private readonly IFileService _fileService;
        private CatClient _catClient;

        public CatService(IFileService fileService)
        {
            _fileService = fileService;
            _catClient = new CatClient(_baseUrl);
        }
        private CatFactModel GetCatFact()
        {
            return _catClient.GetCatFact();
        }
        public void GetCatFactAndSaveToFile(string filePath)
        {
            var timer = new Stopwatch();
            timer.Start();
            CatFactModel catFact = GetCatFact();
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);
            
            //Console.WriteLine($"{catFact.Fact};{catFact.Length}");
            _fileService.SaveMessageToFile($"{catFact.Fact};{catFact.Length}", filePath);
        }
    }
}
