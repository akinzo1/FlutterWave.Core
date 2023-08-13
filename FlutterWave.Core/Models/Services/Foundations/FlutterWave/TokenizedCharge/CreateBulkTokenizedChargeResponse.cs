using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class CreateBulkTokenizedChargeResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public CreateBulkTokenizedChargeData Data { get; set; }

        public class CreateBulkTokenizedChargeData
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
