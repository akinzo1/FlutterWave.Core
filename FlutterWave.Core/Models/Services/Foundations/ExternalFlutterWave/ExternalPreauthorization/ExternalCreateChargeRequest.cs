using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization
{
    internal class ExternalCreateChargeRequest
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        [JsonProperty("cvv")]
        public string Cvv { get; set; }

        [JsonProperty("expiry_month")]
        public int ExpiryMonth { get; set; }

        [JsonProperty("expiry_year")]
        public int ExpiryYear { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonProperty("preauthorize")]
        public bool Preauthorize { get; set; }

        [JsonProperty("client_ip")]
        public string ClientIp { get; set; }

        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }

        [JsonProperty("payment_plan")]
        public string PaymentPlan { get; set; }

        [JsonProperty("meta")]
        public ExternalMeta Meta { get; set; }

        [JsonProperty("usesecureauth")]
        public bool UseSecureAuth { get; set; }

        [JsonProperty("authorization")]
        public ExternalAuthorizationData Authorization { get; set; }

        public class ExternalAuthorizationData
        {
            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("pin")]
            public int Pin { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("address")]
            public string Address { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("zipcode")]
            public string ZipCode { get; set; }
        }

        public class ExternalMeta
        {
            [JsonProperty("flightID")]
            public string FlightId { get; set; }

            [JsonProperty("sidNote")]
            public string SideNote { get; set; }


        }

    }
}
