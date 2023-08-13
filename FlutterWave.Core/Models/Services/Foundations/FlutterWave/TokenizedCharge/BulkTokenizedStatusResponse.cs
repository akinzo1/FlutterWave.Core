using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class BulkTokenizedStatusResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public BulkTokenizedStatusData Data { get; set; }
        public class BulkTokenizedStatusData
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("approver")]
            public string Approver { get; set; }

            [JsonProperty("processed_charges")]
            public int ProcessedCharges { get; set; }

            [JsonProperty("pending_charges")]
            public int PendingCharges { get; set; }

            [JsonProperty("total_charges")]
            public int TotalCharges { get; set; }
        }






    }
}
