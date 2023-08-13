using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class FetchMultipleRefundTransactionResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public FetchMultipleRefundTransactionMetaModel Meta { get; set; }
        public List<Datum> Data { get; set; }
        public class FetchMultipleRefundTransactionMetaModel
        {
            public PageInfo PageInfo { get; set; }
        }

        public class PageInfo
        {
            public int Total { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
            public int PageSize { get; set; }
        }
        public class Datum
        {
            public int Id { get; set; }
            public int AmountRefunded { get; set; }
            public string Status { get; set; }
            public string FlwRef { get; set; }
            public string Comment { get; set; }
            public string SettlementId { get; set; }
            public string Meta { get; set; }
            public DateTime CreatedAt { get; set; }
            public int AccountId { get; set; }
            public int TransactionId { get; set; }
        }

    }
}

