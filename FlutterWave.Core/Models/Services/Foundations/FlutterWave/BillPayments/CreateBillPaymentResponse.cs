namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments
{
    public class CreateBillPaymentResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Datum Data { get; set; }
        public class Datum
        {
            public string PhoneNumber { get; set; }
            public int Amount { get; set; }
            public string Network { get; set; }
            public string FlwRef { get; set; }
            public string TxRef { get; set; }
            public object Reference { get; set; }
        }






    }
}
