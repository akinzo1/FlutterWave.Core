using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks
{
    public class ChargeBackResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public PageInfo Meta { get; set; }
        public List<Datum> Data { get; set; }

        public class Datum
        {
            public int Id { get; set; }
            public int Amount { get; set; }
            public string FlwRef { get; set; }
            public string Status { get; set; }
            public string Stage { get; set; }
            public string Comment { get; set; }
            public ChargebackMeta Meta { get; set; }
            public DateTime DueDate { get; set; }
            public string SettlementId { get; set; }
            public DateTime CreatedAt { get; set; }
            public int TransactionId { get; set; }
            public string TxRef { get; set; }
        }

        public class History
        {
            public string Initiator { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }
            public string Action { get; set; }
            public string Stage { get; set; }
            public string Source { get; set; }
        }

        public class ChargebackMeta
        {

            public PageInfo PageInfo { get; set; }
            public object UploadedProof { get; set; }
            public List<History> History { get; set; }
        }

        public class PageInfo
        {

            public int Total { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
            public int PageSize { get; set; }
        }

    }
}
