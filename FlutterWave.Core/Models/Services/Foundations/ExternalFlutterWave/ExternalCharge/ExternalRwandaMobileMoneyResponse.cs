using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge
{
    internal class ExternalRwandaMobileMoneyResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("meta")]
        public ExternalRwandaMobileMoneyMeta Meta { get; set; }
        public class Authorization
        {
            [JsonProperty("redirect")]
            public string Redirect { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }
        }

        public class ExternalRwandaMobileMoneyMeta
        {
            [JsonProperty("authorization")]
            public Authorization Authorization { get; set; }
        }






    }
}
