using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan
{
    internal class ExternalPaymentPlansResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("meta")]
        public ExternalPaymentPlanMeta Meta { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        public class Datum
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("interval")]
            public string Interval { get; set; }

            [JsonProperty("duration")]
            public int Duration { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("plan_token")]
            public string PlanToken { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }


        public class ExternalPaymentPlanMeta
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
