using System.Collections.Generic;
using WiPro.Domain.Entity;
using WiPro.Domain.EntityDto;

namespace WiPro.Service.Interface
{
    public interface IQueueWaitingService
    {
        string AddItens(List<CoinDto> listCoin);

        string GetList();
    }
}