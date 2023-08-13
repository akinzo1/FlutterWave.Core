using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments
{
    public class BillPaymentsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Datum Data { get; set; }

        public class Datum
        {
            public List<Summary> Summary { get; set; }
            public int Total { get; set; }
            public int TotalPages { get; set; }
            public object Reference { get; set; }
        }


        public class Summary
        {
            public string Currency { get; set; }
            public double SumBills { get; set; }
            public double SumCommission { get; set; }
            public int SumDstv { get; set; }
            public int SumAirtime { get; set; }
            public int CountDstv { get; set; }
            public int CountAirtime { get; set; }
        }


    }
}
