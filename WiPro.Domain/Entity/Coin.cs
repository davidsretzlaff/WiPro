using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WiPro.Domain.Entity
{
    public class Coin
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        
        [JsonProperty("moeda")]
        public string Description { get; set; }
        [JsonProperty("data_inicio")]
        public DateTime CreateDate { get; set; }
        [JsonProperty("data_fim")]
        public DateTime EndDate { get; set; }

        public string Message { get; set; }
    }
}