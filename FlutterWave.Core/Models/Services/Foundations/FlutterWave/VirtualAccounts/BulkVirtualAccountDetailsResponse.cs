using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{


    public class BulkVirtualAccountDetailsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<Datum> Data { get; set; }

        public class Datum
        {
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public string FlwRef { get; set; }
            public string OrderRef { get; set; }
            public string AccountNumber { get; set; }
            public string Frequency { get; set; }
            public string BankName { get; set; }
            public string CreatedAt { get; set; }
            public string ExpiryDate { get; set; }
            public string Note { get; set; }
            public object Amount { get; set; }

        }
    }
}
