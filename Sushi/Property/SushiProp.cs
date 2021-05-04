using Newtonsoft.Json;

namespace Sushi.BL.Sushi
{
    class SushiProp
    {
        [JsonProperty("SushiName")]
        public string SushiName { get; set; }
        [JsonProperty("NumberOfRolls")]
        public int NumberOfRolls { get; set; }
        [JsonProperty("Price")]
        public int Price { get; set; }
    }
}
