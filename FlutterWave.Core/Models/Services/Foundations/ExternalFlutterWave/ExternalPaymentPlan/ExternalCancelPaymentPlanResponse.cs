using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan
{
    internal class ExternalCancelPaymentPlanResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Datum Data { get; set; }

        public class Datum
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("plan_token")]
            public string PlanToken { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("duration")]
            public int Duration { get; set; }

            [JsonProperty("interval")]
            public string Interval { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }





    }
}
