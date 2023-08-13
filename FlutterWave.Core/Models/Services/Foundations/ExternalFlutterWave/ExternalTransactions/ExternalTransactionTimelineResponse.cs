using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions
{
    internal class ExternalTransactionTimelineResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        public class Datum
        {
            [JsonProperty("note")]
            public string Note { get; set; }

            [JsonProperty("actor")]
            public string Actor { get; set; }

            [JsonProperty("object")]
            public string Object { get; set; }

            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("context")]
            public string Context { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }






    }
}
