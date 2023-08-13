using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSubscriptions
{
    internal class ExternalSubscriptionResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalSubscriptionData Data { get; set; }

        public class Customer
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("customer_email")]
            public string CustomerEmail { get; set; }
        }

        public class ExternalSubscriptionData
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
    }
}
