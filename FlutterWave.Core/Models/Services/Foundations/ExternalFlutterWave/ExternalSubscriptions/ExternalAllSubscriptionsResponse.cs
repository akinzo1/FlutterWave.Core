using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSubscriptions
{
    internal class ExternalAllSubscriptionsResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("meta")]
        public ExternalSubscriptionsMeta Meta { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        public class Customer
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("customer_email")]
            public string CustomerEmail { get; set; }
        }

        public class Datum
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("customer")]
            public Customer Customer { get; set; }

            [JsonProperty("plan")]
            public int Plan { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }

        public class ExternalSubscriptionsMeta
        {
            [JsonProperty("page_info")]
            public PageInfo PageInfo { get; set; }
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
