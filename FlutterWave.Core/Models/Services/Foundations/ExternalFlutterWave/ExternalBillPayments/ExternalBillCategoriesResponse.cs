using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments
{
    internal class ExternalBillCategoriesResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        public class Datum
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("biller_code")]
            public string BillerCode { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("default_commission")]
            public double DefaultCommission { get; set; }

            [JsonProperty("date_added")]
            public DateTime DateAdded { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("is_airtime")]
            public bool IsAirtime { get; set; }

            [JsonProperty("biller_name")]
            public string BillerName { get; set; }

            [JsonProperty("item_code")]
            public string ItemCode { get; set; }

            [JsonProperty("short_name")]
            public string ShortName { get; set; }

            [JsonProperty("fee")]
            public int Fee { get; set; }

            [JsonProperty("commission_on_fee")]
            public bool CommissionOnFee { get; set; }

            [JsonProperty("label_name")]
            public string LabelName { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }
        }





    }
}
