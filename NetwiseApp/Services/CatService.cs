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
        void GetCatFactsAndSaveToFile(int nTimes, string filePath);
        void GetCatFactsAsyncAndSaveToFile(int nTimes, string filePath);
    }
    public class CatService : ICatService
    {
        private readonly string _baseUrl = "https://catfact.ninja";
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
        private Task<CatFactModel> GetCatFactAsnyc()
        {
            return _catClient.GetCatFactAsync();
        }
        public void GetCatFactAndSaveToFile(string filePath)
        {            
            CatFactModel catFact = GetCatFact();                      
            _fileService.SaveMessageToFile($"{catFact.Fact};{catFact.Length}", filePath);
        }
        public void GetCatFactsAndSaveToFile(int nTimes, string filePath)
        {
            for(int i = 0; i < nTimes ; i++)
            {
                var catFact = GetCatFact();
                _fileService.SaveMessageToFile($"{catFact.Fact};{catFact.Length}", filePath);
            }            
        }
        public async void GetCatFactsAsyncAndSaveToFile(int nTimes, string filePath)
        {            
            List<Task<CatFactModel>> tasks = new List<Task<CatFactModel>>();
            for (int i = 0; i < nTimes; i++)            
                tasks.Add(GetCatFactAsnyc());            
            foreach (var catFact in await Task.WhenAll(tasks))            
                _fileService.SaveMessageToFile($"{catFact.Fact};{catFact.Length}", filePath);                     
        }
    }
}
