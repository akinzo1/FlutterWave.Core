using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments
{
    internal class ExternalCreateBillPaymentResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Datum Data { get; set; }

        public class Datum
        {
            [JsonProperty("phone_number")]
            public string PhoneNumber { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("network")]
            public string Network { get; set; }

            [JsonProperty("flw_ref")]
            public string FlwRef { get; set; }

            [JsonProperty("tx_ref")]
            public string TxRef { get; set; }

            [JsonProperty("reference")]
            public object Reference { get; set; }
        }






    }
}
