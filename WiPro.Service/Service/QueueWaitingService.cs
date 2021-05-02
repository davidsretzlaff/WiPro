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

        public string AddItens(List<CoinDto> listCoin)
        {
            return _queueWaitingService.AddItens(listCoin);
        }

        public string GetList()
        {
            return _queueWaitingService.GetList();
        }
    }
}