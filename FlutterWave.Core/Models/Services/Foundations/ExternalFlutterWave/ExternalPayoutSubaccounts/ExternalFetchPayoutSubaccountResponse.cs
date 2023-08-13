using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts
{
    internal class ExternalFetchPayoutSubaccountResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalFetchPayoutSubaccountData Data { get; set; }
        public class ExternalFetchPayoutSubaccountData
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("account_reference")]
            public string AccountReference { get; set; }

            [JsonProperty("account_name")]
            public string AccountName { get; set; }

            [JsonProperty("barter_id")]
            public string BarterId { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("mobilenumber")]
            public string Mobilenumber { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("nuban")]
            public string Nuban { get; set; }

            [JsonProperty("bank_name")]
            public string BankName { get; set; }

            [JsonProperty("bank_code")]
            public string BankCode { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("transfer_limits")]
            public TransferLimits TransferLimits { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }





        public class TransferLimits
        {
            [JsonProperty("single_limit")]
            public int SingleLimit { get; set; }

            [JsonProperty("total_daily_limit")]
            public int TotalDailyLimit { get; set; }
        }


    }
}
