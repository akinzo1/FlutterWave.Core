﻿using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class UpdatePayoutSubaccountResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public UpdatePayoutSubaccountData Data { get; set; }

        public class UpdatePayoutSubaccountData
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

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }






    }
}
