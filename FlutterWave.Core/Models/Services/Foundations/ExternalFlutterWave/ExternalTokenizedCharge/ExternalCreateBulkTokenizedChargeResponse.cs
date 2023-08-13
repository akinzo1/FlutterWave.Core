using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge
{
    internal class ExternalCreateBulkTokenizedChargeResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalCreateBulkTokenizedChargeData Data { get; set; }

        public class ExternalCreateBulkTokenizedChargeData
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("approver")]
            public string Approver { get; set; }
        }






    }
}
