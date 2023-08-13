using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions
{
    internal class ExternalFetchRefundDetailsResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalFetchRefundDetailsData Data { get; set; }

        public class ExternalFetchRefundDetailsData
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("amount_refunded")]
            public double AmountRefunded { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("flw_ref")]
            public string FlwRef { get; set; }

            [JsonProperty("comment")]
            public object Comment { get; set; }

            [JsonProperty("settlement_id")]
            public string SettlementId { get; set; }

            [JsonProperty("meta")]
            public string Meta { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("account_id")]
            public int AccountId { get; set; }

            [JsonProperty("transaction_id")]
            public int TransactionId { get; set; }
        }





    }
}
