using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class TransferFeesResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<Datum> Data { get; set; }

        public class Datum
        {
            public string FeeType { get; set; }
            public string Currency { get; set; }
            public double Fee { get; set; }
        }

    }
}
