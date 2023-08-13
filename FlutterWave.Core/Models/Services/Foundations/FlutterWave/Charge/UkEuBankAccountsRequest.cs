using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class UkEuBankAccountsRequest
    {

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("is_token_io")]
        public int IsTokenIo { get; set; }

        [JsonProperty("client_ip")]
        public string ClientIp { get; set; }

        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }

        [JsonProperty("meta")]
        public UkEuBankAccountsMeta Meta { get; set; }

        public class UkEuBankAccountsMeta
        {
            [JsonProperty("flightID")]
            public string FlightId { get; set; }

            [JsonProperty("sideNote")]
            public string SideNote { get; set; }
        }



    }
}
