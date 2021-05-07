using Newtonsoft.Json;

namespace Sushi.BL.Sushi
{
    class SushiProp
    {
        [JsonProperty("SushiName")]
        public string SushiName { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("NumberOfRolls")]
        public int NumberOfRolls { get; set; }
        [JsonProperty("Weight")]
        public int Weight { get; set; }
        [JsonProperty("Price")]
        public double Price { get; set; }
    }
}
