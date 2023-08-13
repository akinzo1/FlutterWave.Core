namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous
{
    public class BalanceByCurrencyResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public BalanceCurrencyData Data { get; set; }

        public class BalanceCurrencyData
        {
            public string Currency { get; set; }
            public int AvailableBalance { get; set; }
            public double LedgerBalance { get; set; }
        }

    }
}
