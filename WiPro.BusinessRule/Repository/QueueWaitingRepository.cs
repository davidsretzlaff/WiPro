using System.Collections.Generic;
using WiPro.BusinessRule.Interface;
using WiPro.Data;
using WiPro.Domain.Entity;
using WiPro.Domain.EntityDto;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace WiPro.BusinessRule.Repository
{
    public class QueueWaitingRepository : IQueueWaitingRepository
    {
        public string AddItens(List<CoinDto> listCoin)
        {
            try
            {
                if(listCoin == null || listCoin.Count == 0)
                {
                     return ($"lista vazia.");
                }
                 List<Coin> NewCoins = new List<Coin>();
                 int quantity =0;
                 listCoin.ForEach(x => {
                     NewCoins.Add(new Coin()
                     {
                         Description = x.moeda,
                         CreateDate = DateTime.Parse(x.data_inicio),
                         EndDate = DateTime.Parse(x.data_fim)
                     });
                     quantity ++;
                 });
                using (var context = new WiProContext())
                {
                    context.Set<Coin>().AddRange(NewCoins);
                    context.SaveChanges();
                    return ($"{quantity} Itens inseridos.");
                }
               
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetList()
        {
             using( var context = new WiProContext())
            {
                Coin lastCoin = context.Coin.ToList().LastOrDefault<Coin>();
                if(lastCoin == null)
                {
                    return JsonConvert.SerializeObject(new Coin() { Id = -1, Message = "Nenhum registro foi encontrado." }); 
                }
                else
                {
                    Coin lastExclude = context.Coin.Find(lastCoin.Id);
                    context.Coin.Remove(lastExclude);
                    context.SaveChanges();

                    return JsonConvert.SerializeObject(lastCoin, new JsonSerializerSettings() { DateFormatString = "yyyy-MM-dd" }).ToString();
                }
            }
        }
    }
}