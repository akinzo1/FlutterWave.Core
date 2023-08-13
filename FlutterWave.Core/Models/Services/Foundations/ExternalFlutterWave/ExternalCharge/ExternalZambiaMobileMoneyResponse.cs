using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge
{
    internal class ExternalZambiaMobileMoneyResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("meta")]
        public ExternalZambiaMobileMoneyMeta Meta { get; set; }

        public class Authorization
        {
            [JsonProperty("redirect")]
            public string Redirect { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }
        }

        public class ExternalZambiaMobileMoneyMeta
        {
            [JsonProperty("authorization")]
            public Authorization Authorization { get; set; }
        }






    }
}
