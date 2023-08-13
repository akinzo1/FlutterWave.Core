using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers
{
    internal class ExternalTransferRatesResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalTransferRateModel Data { get; set; }

        internal class ExternalTransferRateModel
        {
            [JsonProperty("rate")]
            public double Rate { get; set; }

            [JsonProperty("source")]
            public Source Source { get; set; }

            [JsonProperty("destination")]
            public Destination Destination { get; set; }
        }

        internal class Destination
        {
            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }
        }





        internal class Source
        {
            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }
        }


    }
}
