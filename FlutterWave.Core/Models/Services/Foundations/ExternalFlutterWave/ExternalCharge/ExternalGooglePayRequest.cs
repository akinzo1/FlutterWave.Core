using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge
{
    internal class ExternalGooglePayRequest
    {

        public class ExternalGooglePayMeta
        {
            [JsonProperty("metaname")]
            public string MetaName { get; set; }

            [JsonProperty("metavalue")]
            public string MetaValue { get; set; }
        }


        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonProperty("client_ip")]
        public string ClientIp { get; set; }

        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }

        [JsonProperty("billing_zip")]
        public string BillingZip { get; set; }

        [JsonProperty("billing_city")]
        public string BillingCity { get; set; }

        [JsonProperty("billing_address")]
        public string BillingAddress { get; set; }

        [JsonProperty("billing_state")]
        public string BillingState { get; set; }

        [JsonProperty("billing_country")]
        public string BillingCountry { get; set; }

        [JsonProperty("meta")]
        public ExternalGooglePayMeta Meta { get; set; }



    }
}
