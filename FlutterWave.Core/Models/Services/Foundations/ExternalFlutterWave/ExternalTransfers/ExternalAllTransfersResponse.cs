using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers
{
    internal class ExternalAllTransfersResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("meta")]
        public ExternalTransfersMetaModel Meta { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        internal class ExternalTransfersMetaModel
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

            [JsonProperty("account_number")]
            public string AccountNumber { get; set; }

            [JsonProperty("bank_code")]
            public string BankCode { get; set; }

            [JsonProperty("full_name")]
            public string FullName { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("debit_currency")]
            public string DebitCurrency { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("fee")]
            public int Fee { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("meta")]
            public object Meta { get; set; }

            [JsonProperty("narration")]
            public string Narration { get; set; }

            [JsonProperty("approver")]
            public object Approver { get; set; }

            [JsonProperty("complete_message")]
            public string CompleteMessage { get; set; }

            [JsonProperty("requires_approval")]
            public int RequiresApproval { get; set; }

            [JsonProperty("is_approved")]
            public int IsApproved { get; set; }

            [JsonProperty("bank_name")]
            public string BankName { get; set; }
        }








    }
}
