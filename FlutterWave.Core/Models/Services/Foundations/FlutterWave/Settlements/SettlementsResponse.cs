using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements
{
    public class SettlementsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public SettlementsMeta Meta { get; set; }
        public List<Datum> Data { get; set; }

        public class Datum
        {
            public int Id { get; set; }
            public int AccountId { get; set; }
            public string MerchantName { get; set; }
            public string MerchantEmail { get; set; }
            public string SettlementAccount { get; set; }
            public string BankCode { get; set; }
            public DateTime TransactionDate { get; set; }
            public DateTime DueDate { get; set; }
            public object ProcessedDate { get; set; }
            public string Status { get; set; }
            public bool IsLocal { get; set; }
            public string Currency { get; set; }
            public double GrossAmount { get; set; }
            public double AppFee { get; set; }
            public int MerchantFee { get; set; }
            public int Chargeback { get; set; }
            public int Refund { get; set; }
            public int StampdutyCharge { get; set; }
            public int NetAmount { get; set; }
            public int TransactionCount { get; set; }
            public object ProcessorRef { get; set; }
            public string DisburseRef { get; set; }
            public object DisburseMessage { get; set; }
            public string Channel { get; set; }
            public string Destination { get; set; }
            public object FxData { get; set; }
            public object FlagMessage { get; set; }
            public List<int> Meta { get; set; }
            public Object RefundMeta { get; set; }
            public List<object> ChargebackMeta { get; set; }
            public object SourceBankcode { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class SettlementsMeta
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

    }
}
