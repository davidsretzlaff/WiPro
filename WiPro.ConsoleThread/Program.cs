using System;
using WiPro.Domain.Entity;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WiPro.ConsoleThread
{
    class Program
    {
        static string pathBase = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("WiPro.ConsoleThread")) + @"WiPro.ConsoleThread\Docs";


        static void Main(string[] args)
        {
            Console.WriteLine("Inicio Thread");
            Thread thread = new Thread(StartThread);
            thread.Start();

        }

        public static async void StartThread()
        {
            Coin coin = await CallApiGetItemFila();
            List<CoinData> coinDataList = GetCoinData(coin);
            List<PriceData> coinPriceList = GetPricesData();

        }
        private static async Task<Coin> CallApiGetItemFila()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5000/api/QueueWaiting/");
                    var response = client.GetAsync("GetItemFila").Result;
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var coin = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Coin>(coin);
                    }
                     return new Coin() { Id = -1, Message = "Nenhum registro na base" };
                }
            }
            catch (Exception ex)
            {
                return  new Coin() { Id = -1, Message = ex.Message };
            }
        }

        private static List<CoinData> GetCoinData(Coin coin)
        {
            List<CoinData> coinDataList = new List<CoinData>();
            var list = File.ReadAllLines(@$"{pathBase}\DadosMoeda.csv");
            foreach(var row in list)
            {
                if(row == "ID_MOEDA;DATA_REF")
                    continue;
                
                string[] values = row.Split(';');
                if(values.Length == 2)
                {
                    coinDataList.Add(new CoinData()
                    {
                        ID_MOEDA = values[0].ToString(),
                        DATA_REF = Convert.ToDateTime(values[1])
                    });
                }
            }

             return coinDataList.Where(
                x => x.ID_MOEDA == coin.Description
                && x.DATA_REF >= coin.CreateDate
                && x.DATA_REF <= coin.EndDate).ToList();
        }

        private static List<PriceData> GetPricesData()
        {
            List<PriceData> pricesData = new List<PriceData>();
            var list = File.ReadAllLines(@$"{pathBase}\DadosCotacao.csv");
            foreach(var row in list)
            {
                if (row == "vlr_cotacao;cod_cotacao;dat_cotacao")
                    continue;
                
                string[] values = row.Split(';');
                if(values != null && values.Length == 3)
                {
                    pricesData.Add(new PriceData()
                    {
                        vlr_cotacao = decimal.Parse(values[0].ToString()),
                        cod_cotacao = int.Parse(values[1].ToString()),
                        dat_cotacao = Convert.ToDateTime(values[2])
                    });
                }
            }

            return pricesData;
        }
    }
}
