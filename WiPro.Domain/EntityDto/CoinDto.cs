using Newtonsoft.Json;

namespace WiPro.Domain.EntityDto
{
    public class CoinDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string moeda { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
    }
}