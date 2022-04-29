using NetwiseApp.Models;
using System;
using System.Collections.Generic;
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

        public CatService(IFileService fileService)
        {
            _fileService = fileService;
        }
        private CatFactModel GetCatFact()
        {
            CatClient client = new CatClient(_baseUrl);
            return client.GetCatFact();
        }
        public void GetCatFactAndSaveToFile(string filePath)
        {
            CatFactModel catFact = GetCatFact();
            _fileService.SaveMessageToFile($"{catFact.Fact};{catFact.Length}", filePath);
        }
    }
}
