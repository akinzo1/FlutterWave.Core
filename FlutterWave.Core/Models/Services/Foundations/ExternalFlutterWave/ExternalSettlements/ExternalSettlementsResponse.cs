using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    internal class ExternalSettlementsResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("meta")]
        public ExternalSettlementsMeta Meta { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        internal class Datum
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("account_id")]
            public int AccountId { get; set; }

            [JsonProperty("merchant_name")]
            public string MerchantName { get; set; }

            [JsonProperty("merchant_email")]
            public string MerchantEmail { get; set; }

            [JsonProperty("settlement_account")]
            public string SettlementAccount { get; set; }

            [JsonProperty("bank_code")]
            public string BankCode { get; set; }

            [JsonProperty("transaction_date")]
            public DateTime TransactionDate { get; set; }

            [JsonProperty("due_date")]
            public DateTime DueDate { get; set; }

            [JsonProperty("processed_date")]
            public object ProcessedDate { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("is_local")]
            public bool IsLocal { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("gross_amount")]
            public double GrossAmount { get; set; }

            [JsonProperty("app_fee")]
            public double AppFee { get; set; }

            [JsonProperty("merchant_fee")]
            public int MerchantFee { get; set; }

            [JsonProperty("chargeback")]
            public int Chargeback { get; set; }

            [JsonProperty("refund")]
            public int Refund { get; set; }

            [JsonProperty("stampduty_charge")]
            public int StampdutyCharge { get; set; }

            [JsonProperty("net_amount")]
            public int NetAmount { get; set; }

            [JsonProperty("transaction_count")]
            public int TransactionCount { get; set; }

            [JsonProperty("processor_ref")]
            public object ProcessorRef { get; set; }

            [JsonProperty("disburse_ref")]
            public string DisburseRef { get; set; }

            [JsonProperty("disburse_message")]
            public object DisburseMessage { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("destination")]
            public string Destination { get; set; }

            [JsonProperty("fx_data")]
            public object FxData { get; set; }

            [JsonProperty("flag_message")]
            public object FlagMessage { get; set; }

            [JsonProperty("meta")]
            public List<int> Meta { get; set; }

            [JsonProperty("refund_meta")]
            public List<int> RefundMeta { get; set; }

            [JsonProperty("chargeback_meta")]
            public List<object> ChargebackMeta { get; set; }

            [JsonProperty("source_bankcode")]
            public object SourceBankcode { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }

        internal class ExternalSettlementsMeta
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






    }
}
