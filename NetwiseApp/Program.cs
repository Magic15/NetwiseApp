using NetwiseApp.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetwiseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CatClient catClient = new CatClient("https://catfact.ninja");
            var catFact = catClient.GetCatFactAsync();

            Console.WriteLine($"{catFact.Fact}");
            Console.ReadLine();
        }
    }
}
