using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class FetchSubaccountAvailableBalanceResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public FetchSubaccountAvailableBalanceData Data { get; set; }

        public class FetchSubaccountAvailableBalanceData
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
