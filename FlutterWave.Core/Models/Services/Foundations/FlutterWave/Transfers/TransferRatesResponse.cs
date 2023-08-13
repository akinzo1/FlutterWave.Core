namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class TransferRatesResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public TransferRateModel Data { get; set; }

        public class TransferRateModel
        {
            public double Rate { get; set; }
            public Source Source { get; set; }
            public Destination Destination { get; set; }
        }

        public class Destination
        {
            public string Currency { get; set; }
            public int Amount { get; set; }
        }

        public class Source
        {
            public string Currency { get; set; }
            public int Amount { get; set; }
        }


    }
}
