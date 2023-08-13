namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments
{
    public class CreateBillPaymentRequest
    {
        public string Country { get; set; }
        public string Customer { get; set; }
        public string Amount { get; set; }
        public string Recurrence { get; set; }
        public string Type { get; set; }
        public string Reference { get; set; }
        public string BillerName { get; set; }
    }
}
