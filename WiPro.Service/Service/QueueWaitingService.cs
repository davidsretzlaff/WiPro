using System.Collections.Generic;
using WiPro.Domain.Entity;
using WiPro.Domain.EntityDto;
using WiPro.Service.Interface;

namespace WiPro.Service.Service
{
    public class QueueWaitingService : IQueueWaitingService
    {
        private readonly IQueueWaitingService _queueWaitingService;

        public QueueWaitingService(IQueueWaitingService queueWaitingService)
        {
            _queueWaitingService = queueWaitingService;
        }
        public Coin AddItem(Coin item)
        {
            return _queueWaitingService.AddItem(item);
        }

        public Coin AddItemRanger(List<CoinDto> listCoin)
        {
            return _queueWaitingService.AddItemRanger(listCoin);
        }

        public string GetList()
        {
            return _queueWaitingService.GetList();
        }
        public void ValidList(List<CoinDto> listCoin)
        {
            _queueWaitingService.ValidList(listCoin);
        }
    }
}