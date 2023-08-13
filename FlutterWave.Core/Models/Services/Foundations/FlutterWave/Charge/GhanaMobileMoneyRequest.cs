using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class GhanaMobileMoneyRequest
    {


        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("voucher")]
        public string Voucher { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

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

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonProperty("meta")]
        public GhanaMobileMoneyMeta Meta { get; set; }
        public class GhanaMobileMoneyMeta
        {
            [JsonProperty("flightID")]
            public string FlightID { get; set; }

            [JsonProperty("sideNote")]
            public string SideNote { get; set; }
        }








    }
}
