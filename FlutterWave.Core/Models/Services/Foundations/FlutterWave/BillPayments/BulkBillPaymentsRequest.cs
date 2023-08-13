using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments
{
    public class BulkBillPaymentsRequest
    {
        public string BulkReference { get; set; }
        public string CallbackUrl { get; set; }
        public List<BulkDatum> BulkData { get; set; }

        public class BulkDatum
        {
            public string Country { get; set; }
            public string Customer { get; set; }
            public int Amount { get; set; }
            public string Recurrence { get; set; }
            public string Type { get; set; }
            public string Reference { get; set; }
        }






    }
}
