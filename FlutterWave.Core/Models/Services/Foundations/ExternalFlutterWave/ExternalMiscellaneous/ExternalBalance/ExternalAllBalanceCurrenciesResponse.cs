using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalBalance
{
    internal class ExternalAllBalanceCurrenciesResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        public class Datum
        {
            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("available_balance")]
            public int AvailableBalance { get; set; }

            [JsonProperty("ledger_balance")]
            public double LedgerBalance { get; set; }
        }


    }
}
