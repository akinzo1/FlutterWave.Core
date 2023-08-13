using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers
{
    internal class ExternalCreateBulkTransferResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Datum Data { get; set; }

        internal class Datum
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
