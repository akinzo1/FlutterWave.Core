using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments
{
    internal class ExternalBillStatusPaymentResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Datum Data { get; set; }

        public class Datum
        {
            [JsonProperty("tx_ref")]
            public string TxRef { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("fee")]
            public int Fee { get; set; }

            [JsonProperty("currency")]
            public object Currency { get; set; }

            [JsonProperty("extra")]
            public object Extra { get; set; }

            [JsonProperty("flw_ref")]
            public object FlwRef { get; set; }

            [JsonProperty("token")]
            public object Token { get; set; }
        }



    }
}
