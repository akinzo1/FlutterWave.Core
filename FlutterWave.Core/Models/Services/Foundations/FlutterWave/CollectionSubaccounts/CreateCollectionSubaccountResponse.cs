using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class CreateCollectionSubaccountResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public CreateCollectionSubaccountData Data { get; set; }

        public class CreateCollectionSubaccountData
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("account_number")]
            public string AccountNumber { get; set; }

            [JsonProperty("account_bank")]
            public string AccountBank { get; set; }

            [JsonProperty("full_name")]
            public string FullName { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("split_type")]
            public string SplitType { get; set; }

            [JsonProperty("split_value")]
            public double SplitValue { get; set; }

            [JsonProperty("subaccount_id")]
            public string SubaccountId { get; set; }

            [JsonProperty("bank_name")]
            public string BankName { get; set; }
        }






    }
}
