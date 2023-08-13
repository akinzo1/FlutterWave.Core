using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalBalance
{
    internal class ExternalStatementResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalStatementResult Data { get; set; }


        internal class ExternalStatementResult
        {

            [JsonProperty("page_info")]
            public ExternalStatementsPageInfo PageInfo { get; set; }

            [JsonProperty("transactions")]
            public List<ExternalTansactionStatement> Transactions { get; set; }

        }

        internal class ExternalStatementsPageInfo
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("current_page")]
            public int CurrentPage { get; set; }

            [JsonProperty("total_pages")]
            public int TotalPages { get; set; }
        }

        internal class ExternalTansactionStatement
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("balance_before")]
            public int BalanceBefore { get; set; }

            [JsonProperty("balance_after")]
            public int BalanceAfter { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("date")]
            public DateTime Date { get; set; }

            [JsonProperty("remarks")]
            public string Remarks { get; set; }

            [JsonProperty("sent_currency")]
            public string SentCurrency { get; set; }

            [JsonProperty("rate_used")]
            public int RateUsed { get; set; }

            [JsonProperty("sent_amount")]
            public int SentAmount { get; set; }

            [JsonProperty("statement_type")]
            public string StatementType { get; set; }
        }
    }
}
