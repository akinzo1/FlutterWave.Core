using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class ZambiaMobileMoneyResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Authorization
        {
            [JsonProperty("redirect")]
            public string Redirect { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }
        }

        public class ZambiaMobileMoneyMeta
        {
            [JsonProperty("authorization")]
            public Authorization Authorization { get; set; }
        }


        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("meta")]
        public ZambiaMobileMoneyMeta Meta { get; set; }



    }
}
