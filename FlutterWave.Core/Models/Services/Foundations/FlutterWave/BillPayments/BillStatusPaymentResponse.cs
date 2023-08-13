namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments
{
    public class BillStatusPaymentResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Datum Data { get; set; }

        public class Datum
        {
            public string TxRef { get; set; }
            public int Amount { get; set; }
            public int Fee { get; set; }
            public object Currency { get; set; }
            public object Extra { get; set; }
            public object FlwRef { get; set; }
            public object Token { get; set; }
        }



    }
}
