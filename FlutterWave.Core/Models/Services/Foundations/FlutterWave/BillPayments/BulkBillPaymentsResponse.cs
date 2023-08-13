namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments
{
    public class BulkBillPaymentsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Datum Data { get; set; }

        public class Datum
        {
            public string BatchReference { get; set; }
        }




    }
}
