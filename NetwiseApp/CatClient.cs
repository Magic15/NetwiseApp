using NetwiseApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetwiseApp
{
    public class CatClient
    {
        private string _baseUrl;

        public CatClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<CatFactModel> GetCatFactAsync()
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("/fact", Method.Get);
            var response = await client.GetAsync<CatFactModel>(request);
            return response;
        }
    }
}
