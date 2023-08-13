using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge
{
    internal class ExternalCreateBulkTokenizedChargeRequest
    {

        public class BulkDatum
        {
            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("token")]
            public string Token { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("ip")]
            public string Ip { get; set; }

            [JsonProperty("tx_ref")]
            public string TxRef { get; set; }
        }

        public class RetryStrategyData
        {
            [JsonProperty("retry_interval")]
            public int RetryInterval { get; set; }

            [JsonProperty("retry_amount_variable")]
            public int RetryAmountVariable { get; set; }

            [JsonProperty("retry_attempt_variable")]
            public int RetryAttemptVariable { get; set; }
        }


        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("retry_strategy")]
        public RetryStrategyData RetryStrategy { get; set; }

        [JsonProperty("bulk_data")]
        public List<BulkDatum> BulkData { get; set; }



    }
}
