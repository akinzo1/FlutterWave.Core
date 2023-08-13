using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements
{
    public class SettlementResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Datum Data { get; set; }
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
            public int GrossAmount { get; set; }
            public int AppFee { get; set; }
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
            public object RefundMeta { get; set; }
            public object ChargebackMeta { get; set; }
            public object SourceBankcode { get; set; }
            public DateTime CreatedAt { get; set; }
            public List<Transaction> Transactions { get; set; }
        }
        public class Transaction
        {
            public string CustomerEmail { get; set; }
            public string FlwRef { get; set; }
            public string TxRef { get; set; }
            public int Id { get; set; }
            public int ChargedAmount { get; set; }
            public int AppFee { get; set; }
            public int MerchantFee { get; set; }
            public int StampdutyCharge { get; set; }
            public int SettlementAmount { get; set; }
            public string Status { get; set; }
            public string PaymentEntity { get; set; }
            public string TransactionDate { get; set; }
            public string Currency { get; set; }
            public string CardLocale { get; set; }
            public string Rrn { get; set; }
            public int SubaccountSettlement { get; set; }
        }


    }
}
