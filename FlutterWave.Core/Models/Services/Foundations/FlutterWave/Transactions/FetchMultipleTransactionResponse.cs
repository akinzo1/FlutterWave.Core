using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class FetchMultipleTransactionResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public MultipleTransactionMetaModel Meta { get; set; }
        public List<Datum> Data { get; set; }

        public class Account
        {
            public string Nuban { get; set; }
            public string Bank { get; set; }
        }

        public class Datum
        {
            public string Id { get; set; }
            public string TxRef { get; set; }
            public string FlwRef { get; set; }
            public string DeviceFingerprint { get; set; }
            public int Amount { get; set; }
            public string Currency { get; set; }
            public int ChargedAmount { get; set; }
            public int? AppFee { get; set; }
            public int MerchantFee { get; set; }
            public string ProcessorResponse { get; set; }
            public string AuthModel { get; set; }
            public string Ip { get; set; }
            public string Narration { get; set; }
            public string Status { get; set; }
            public string PaymentType { get; set; }
            public DateTime CreatedAt { get; set; }
            public int? AmountSettled { get; set; }
            public Account Account { get; set; }
            public string CustomerName { get; set; }
            public string CustomerEmail { get; set; }
            public string AccountId { get; set; }
        }


        public class MultipleTransactionMetaModel
        {
            public PageInfo PageInfo { get; set; }
        }

        public class PageInfo
        {
            public int Total { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
        }
    }
}
