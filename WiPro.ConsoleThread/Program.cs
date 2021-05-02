using System;
using WiPro.Domain.Entity;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WiPro.ConsoleThread
{
    class Program
    {
        static string pathBase = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("ConsoleAppThead")) + @"ConsoleAppThead\\Docs";


        static void Main(string[] args)
        {
            Console.WriteLine("Inicio Thread");
            Thread thread = new Thread(StartThread);
            thread.Start();
            
        }

        public static async void StartThread()
        {
            Console.WriteLine("teste");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/QueueWaiting/");
                var response = client.GetAsync("GetItemFila").Result;
                if (response != null && response.IsSuccessStatusCode)
                {
                    string coin = await response.Content.ReadAsStringAsync();
                    var x = JsonConvert.DeserializeObject<Coin>(coin);
                }
                // return new Coin() { Id = -1, Mensagem = "Nenhum registro na base" };
            }
            
        }
    }
}
