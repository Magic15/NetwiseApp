using NetwiseApp.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetwiseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CatClient catClient = new CatClient("https://catfact.ninja");

            Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    var model = await catClient.GetCatFactAsync();
                    Console.WriteLine($"iteracja{i}: {model.Fact}");
                    Thread.Sleep(100);
                }
            });
        
            Console.ReadLine();
        }
    }
}
