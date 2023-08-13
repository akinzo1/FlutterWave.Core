using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification
{
    internal class ExternalBvnConsentRequest
    {



        [JsonProperty("bvn")]
        public string Bvn { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }




    }
}
