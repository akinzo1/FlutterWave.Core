using System;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class FetchRefundDetailsResponse
    {

        public string Status { get; set; }
        public string Message { get; set; }

        public FetchRefundDetailsData Data { get; set; }
        public class FetchRefundDetailsData
        {
            public int Id { get; set; }
            public double AmountRefunded { get; set; }
            public string Status { get; set; }
            public string FlwRef { get; set; }
            public object Comment { get; set; }
            public string SettlementId { get; set; }
            public string Meta { get; set; }
            public DateTime CreatedAt { get; set; }
            public int AccountId { get; set; }
            public int TransactionId { get; set; }

        }


    }
}
