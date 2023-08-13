using Newtonsoft.Json;
using static FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous.BalanceByCurrencyResponse;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalBalance
{
    internal class ExternalBalanceByCurrencyResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public BalanceCurrencyData Data { get; set; }

        public class ExternalBalanceByCurrencyData
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
