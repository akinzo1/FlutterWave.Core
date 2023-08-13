using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts
{
    internal class ExternalFetchSubaccountsResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("meta")]
        public ExternalFetchSubaccountsMeta Meta { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        public class Metum
        {
            [JsonProperty("meta_name")]
            public string MetaName { get; set; }

            [JsonProperty("meta_value")]
            public string MetaValue { get; set; }
        }

        public class Datum
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("account_number")]
            public string AccountNumber { get; set; }

            [JsonProperty("account_bank")]
            public string AccountBank { get; set; }

            [JsonProperty("business_name")]
            public string BusinessName { get; set; }

            [JsonProperty("full_name")]
            public string FullName { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("meta")]
            public List<Metum> Meta { get; set; }

            [JsonProperty("account_id")]
            public int AccountId { get; set; }

            [JsonProperty("split_ratio")]
            public int SplitRatio { get; set; }

            [JsonProperty("split_type")]
            public string SplitType { get; set; }

            [JsonProperty("split_value")]
            public double SplitValue { get; set; }

            [JsonProperty("subaccount_id")]
            public string SubaccountId { get; set; }

            [JsonProperty("bank_name")]
            public string BankName { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }
        }

        public class ExternalFetchSubaccountsMeta
        {
            [JsonProperty("page_info")]
            public PageInfo PageInfo { get; set; }

            [JsonProperty("meta_name")]
            public string MetaName { get; set; }

            [JsonProperty("meta_value")]
            public string MetaValue { get; set; }

            [JsonProperty("swift_code")]
            public string SwiftCode { get; set; }
        }

        public class PageInfo
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("current_page")]
            public int CurrentPage { get; set; }

            [JsonProperty("total_pages")]
            public int TotalPages { get; set; }
        }





    }
}
