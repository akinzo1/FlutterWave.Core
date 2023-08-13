using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class CreateBulkTransferRequest
    {
        public string Title { get; set; }
        public List<BulkDatum> BulkData { get; set; }

        public class BulkDatum
        {
            public string BankCode { get; set; }
            public string AccountNumber { get; set; }
            public int Amount { get; set; }
            public string Currency { get; set; }
            public string Narration { get; set; }
            public string Reference { get; set; }
            public List<Metum> Meta { get; set; }
        }

        public class Metum
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string MobileNumber { get; set; }
            public string RecipientAddress { get; set; }
        }






    }
}
