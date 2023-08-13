using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions
{
    internal class ExternalCreateRefundResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalCreateRefundDataModel Data { get; set; }

        internal class ExternalCreateRefundDataModel
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("account_id")]
            public int AccountId { get; set; }

            [JsonProperty("tx_id")]
            public int TxId { get; set; }

            [JsonProperty("flw_ref")]
            public string FlwRef { get; set; }

            [JsonProperty("wallet_id")]
            public int WalletId { get; set; }

            [JsonProperty("amount_refunded")]
            public int AmountRefunded { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("destination")]
            public string Destination { get; set; }

            [JsonProperty("meta")]
            public Meta Meta { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }

        internal class Meta
        {
            [JsonProperty("source")]
            public string Source { get; set; }
        }






    }
}
