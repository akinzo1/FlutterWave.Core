using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments
{
    internal class ExternalCreateBillPaymentRequest
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("customer")]
        public string Customer { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("recurrence")]
        public string Recurrence { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("biller_name")]
        public string BillerName { get; set; }
    }
}
