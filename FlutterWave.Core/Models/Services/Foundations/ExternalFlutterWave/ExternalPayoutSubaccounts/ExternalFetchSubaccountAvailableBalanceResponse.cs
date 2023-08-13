using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts
{
    internal class ExternalFetchSubaccountAvailableBalanceResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalFetchSubaccountAvailableBalanceData Data { get; set; }

        public class ExternalFetchSubaccountAvailableBalanceData
        {
            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("available_balance")]
            public int AvailableBalance { get; set; }

            [JsonProperty("ledger_balance")]
            public int LedgerBalance { get; set; }
        }






    }
}
