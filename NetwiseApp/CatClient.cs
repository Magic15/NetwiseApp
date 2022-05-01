using NetwiseApp.Models;
using RestSharp;
using System.Threading.Tasks;

namespace NetwiseApp
{
    public class CatClient
    {
        private string _baseUrl;
        private RestClient _client;
        public CatClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _client = new RestClient(_baseUrl);
        }
        public CatFactModel GetCatFact()
        {
            var request = new RestRequest("/fact", Method.Get);
            var response = _client.GetAsync<CatFactModel>(request);
            return response.Result;
        }
        public async Task<CatFactModel> GetCatFactAsync()
        {
            var request = new RestRequest("/fact", Method.Get);
            var response = await _client.GetAsync<CatFactModel>(request);
            return response;
        }
    }
}
