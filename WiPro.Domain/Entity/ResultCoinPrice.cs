using System;

namespace WiPro.Domain.Entity
{
    public class ResultCoinPrice
    {
        public string ID_MOEDA { get; set; }
        public DateTime DATA_REF { get; set; }
        public decimal VL_COTACAO { get; set; }
    }
}