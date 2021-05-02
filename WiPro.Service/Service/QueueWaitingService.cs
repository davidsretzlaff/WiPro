using System.Collections.Generic;
using WiPro.BusinessRule.Interface;
using WiPro.Domain.Entity;
using WiPro.Domain.EntityDto;
using WiPro.Service.Interface;

namespace WiPro.Service.Service
{
    public class QueueWaitingService : IQueueWaitingService
    {
        private readonly IQueueWaitingRepository _queueWaitingRepository;

        public QueueWaitingService(IQueueWaitingRepository queueWaitingRepository)
        {
            _queueWaitingRepository = queueWaitingRepository;
        }

        public string AddItens(List<CoinDto> listCoin)
        {
            return _queueWaitingRepository.AddItens(listCoin);
        }

        public string GetList()
        {
            return _queueWaitingRepository.GetList();
        }
    }
}