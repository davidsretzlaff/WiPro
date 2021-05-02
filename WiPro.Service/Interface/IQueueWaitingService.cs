using System.Collections.Generic;
using WiPro.Domain.Entity;
using WiPro.Domain.EntityDto;

namespace WiPro.Service.Interface
{
    public interface IQueueWaitingService
    {
        Coin AddItem(Coin item);

        Coin AddItemRanger(List<CoinDto> listCoin);

        void ValidList(List<CoinDto> listCoin);

        string GetList();
    }
}