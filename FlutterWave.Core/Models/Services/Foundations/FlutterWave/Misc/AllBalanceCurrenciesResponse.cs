using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous
{
    public class AllBalanceCurrenciesResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<Datum> Data { get; set; }

        public class Datum
        {
            public string Currency { get; set; }
            public int AvailableBalance { get; set; }
            public double LedgerBalance { get; set; }
        }


    }
}
