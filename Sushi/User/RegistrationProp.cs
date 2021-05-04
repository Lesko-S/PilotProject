using Newtonsoft.Json;

namespace Sushi.User
{
    class RegistrationProp
    {

        [JsonProperty("CurrentName")]
        public string CurrentName { get; set; }
        [JsonProperty("CurrentPass")]
        public string CurrentPass { get; set; }
        [JsonProperty("CurrentMail")]
        public string CurrentMail { get; set; }
    }
}
