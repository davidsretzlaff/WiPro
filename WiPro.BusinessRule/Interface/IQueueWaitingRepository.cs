using System.Collections.Generic;
using WiPro.Domain.Entity;
using WiPro.Domain.EntityDto;

namespace WiPro.BusinessRule.Interface
{
    public interface IQueueWaitingRepository
    {

        string AddItens(List<CoinDto> listCoin);

        string GetList();
    }
}