using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge
{
    internal class ExternalFawryRequest
    {

        public class ExternalFawryMeta
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("tools")]
            public string Tools { get; set; }
        }


        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonProperty("client_ip")]
        public string ClientIp { get; set; }

        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }



        [JsonProperty("meta")]
        public ExternalFawryMeta Meta { get; set; }



    }
}
