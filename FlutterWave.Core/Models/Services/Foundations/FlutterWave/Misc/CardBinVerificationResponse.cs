using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous
{
    public class CardBinVerificationResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public CardBinVerificationData Data { get; set; }

        public class CardBinVerificationData
        {

            [JsonProperty("issuing_country")]
            public string IssuingCountry { get; set; }

            [JsonProperty("bin")]
            public string Bin { get; set; }

            [JsonProperty("card_type")]
            public string CardType { get; set; }

            [JsonProperty("issuer_info")]
            public string IssuerInfo { get; set; }
        }

    }
}
