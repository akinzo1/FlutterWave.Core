using System;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class CreateBulkTransferResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Datum Data { get; set; }

        public class Datum
        {
            public int Id { get; set; }
            public DateTime CreatedAt { get; set; }
            public string Approver { get; set; }
        }


    }
}
