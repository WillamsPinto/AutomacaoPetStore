using System.Text.Json.Serialization;

namespace AutomacaoPetStore.Models
{
    public class GetStoreInventory_Response
    {
        [JsonPropertyName("1")]
        public int one {get; set;}
        
        [JsonPropertyName("sold")]
        public int sold {get; set;}

        [JsonPropertyName("string")]
        public int s_tring {get; set;}

        [JsonPropertyName("alive")]
        public int alive { get; set;}

        [JsonPropertyName("unavailable")]
        public int unavailable { get; set;}

        [JsonPropertyName("avaliable")]
        public int avaliable { get; set;}

        [JsonPropertyName("Busy")]
        public int Busy { get; set;}

        [JsonPropertyName("pending")]
        public int pending { get; set;}

        [JsonPropertyName("available")]
        public int available { get; set;}

        [JsonPropertyName("connector_up")]
        public int connector_up { get; set;}

        [JsonPropertyName("avalible")]
        public int avalible { get; set;}

        [JsonPropertyName("availiable")]
        public int availiable { get; set; }
    }
}
