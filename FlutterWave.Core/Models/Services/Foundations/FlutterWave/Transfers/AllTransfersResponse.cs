using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class AllTransfersResponse
    {

        public string Status { get; set; }
        public string Message { get; set; }
        public TransfersMetaModel Meta { get; set; }
        public List<Datum> Data { get; set; }

        public class TransfersMetaModel
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
            public string AccountNumber { get; set; }
            public string BankCode { get; set; }
            public string FullName { get; set; }
            public DateTime CreatedAt { get; set; }
            public string Currency { get; set; }
            public string DebitCurrency { get; set; }
            public int Amount { get; set; }
            public int Fee { get; set; }
            public string Status { get; set; }
            public string Reference { get; set; }
            public object Meta { get; set; }
            public string Narration { get; set; }
            public object Approver { get; set; }
            public string CompleteMessage { get; set; }
            public int RequiresApproval { get; set; }
            public int IsApproved { get; set; }
            public string BankName { get; set; }
        }

    }
}
