﻿using NetwiseApp.Models;
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
        private RestClient _client;

        public CatClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _client = new RestClient(_baseUrl);
        }

        public CatFactModel GetCatFact()
        {
            var request = new RestRequest("/fact", Method.Get);
            var response =  _client.GetAsync<CatFactModel>(request);
            return response.Result;
        }
    }
}
