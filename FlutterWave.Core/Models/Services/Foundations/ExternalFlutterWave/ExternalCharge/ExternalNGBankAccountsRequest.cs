using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge
{
    internal class ExternalNGBankAccountsRequest
    {
        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("account_bank")]
        public string AccountBank { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("client_ip")]
        public string ClientIp { get; set; }

        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }

        [JsonProperty("meta")]
        public ExternalNGBankAccountsMeta Meta { get; set; }

        public class ExternalNGBankAccountsMeta
        {
            [JsonProperty("flightID")]
            public string FlightId { get; set; }

            [JsonProperty("sideNote")]
            public string SideNote { get; set; }
        }
    }
}
