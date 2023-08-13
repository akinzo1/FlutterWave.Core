using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge
{
    internal class ExternalBulkTokenizedStatusResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalBulkTokenizedStatusData Data { get; set; }
        public class ExternalBulkTokenizedStatusData
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
