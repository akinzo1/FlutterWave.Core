using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers
{
    internal class ExternalTransferFeesResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        internal class Datum
        {
            [JsonProperty("fee_type")]
            public string FeeType { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("fee")]
            public double Fee { get; set; }
        }





    }
}
