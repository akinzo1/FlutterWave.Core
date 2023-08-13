using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge
{
    internal class ExternalUgandaMobileMoneyResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("meta")]
        public ExternalUgandaMobileMoneyMeta Meta { get; set; }

        public class Authorization
        {
            [JsonProperty("redirect")]
            public string Redirect { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }
        }

        public class ExternalUgandaMobileMoneyMeta
        {
            [JsonProperty("authorization")]
            public Authorization Authorization { get; set; }
        }






    }
}
