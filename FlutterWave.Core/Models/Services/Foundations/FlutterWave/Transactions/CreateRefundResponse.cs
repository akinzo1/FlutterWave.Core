using System;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class CreateRefundResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public CreateRefundDataModel Data { get; set; }
        public class CreateRefundDataModel
        {
            public int Id { get; set; }
            public int AccountId { get; set; }
            public int TxId { get; set; }
            public string FlwRef { get; set; }
            public int WalletId { get; set; }
            public int AmountRefunded { get; set; }
            public string Status { get; set; }
            public string Destination { get; set; }
            public Meta Meta { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class Meta
        {
            public string Source { get; set; }
        }

    }
}
