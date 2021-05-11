using Newtonsoft.Json;
using Sushi.BL.Logger;
using System;

namespace Sushi.User
{
    class RegistrationProp : IDisposable
    {

        [JsonProperty("CurrentName")]
        public string CurrentName { get; set; }
        [JsonProperty("CurrentPass")]
        public string CurrentPass { get; set; }
        [JsonProperty("CurrentMail")]
        public string CurrentMail { get; set; }
        public void Dispose()
        {
            MyLogger log = new MyLogger();
            RegistrationProp rP = new RegistrationProp();
            log.Debag("Disposed RegistrationProp", rP.GetType().ToString());
        }
    }
}
