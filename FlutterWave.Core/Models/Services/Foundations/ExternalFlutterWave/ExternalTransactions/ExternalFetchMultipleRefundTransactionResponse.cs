using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions
{
    internal class ExternalFetchMultipleTransactionsResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("meta")]
        public ExternalFetchMultpleRefundTransactionMetaModel Meta { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        internal class ExternalFetchMultpleRefundTransactionMetaModel
        {
            [JsonProperty("page_info")]
            public PageInfo PageInfo { get; set; }
        }

        internal class PageInfo
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("current_page")]
            public int CurrentPage { get; set; }

            [JsonProperty("total_pages")]
            public int TotalPages { get; set; }

            [JsonProperty("page_size")]
            public int PageSize { get; set; }
        }
        internal class Datum
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("amount_refunded")]
            public int AmountRefunded { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("flw_ref")]
            public string FlwRef { get; set; }

            [JsonProperty("comment")]
            public string Comment { get; set; }

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
