using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification
{
    internal class ExternalBvnConsentResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalBvnConsentData Data { get; set; }

        public class ExternalBvnConsentData
        {

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }
        }


    }
}
