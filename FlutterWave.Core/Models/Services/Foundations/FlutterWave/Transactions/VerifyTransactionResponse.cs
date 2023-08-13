using System;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class VerifyTransactionResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public VerifyTransactionDataModel Data { get; set; }

        public class VerifyTransactionDataModel
        {

            public int Id { get; set; }
            public string TxRef { get; set; }
            public string FlwRef { get; set; }
            public string DeviceFingerprint { get; set; }
            public int Amount { get; set; }
            public string Currency { get; set; }
            public int ChargedAmount { get; set; }
            public double AppFee { get; set; }
            public int MerchantFee { get; set; }
            public string ProcessorResponse { get; set; }
            public string AuthModel { get; set; }
            public string Ip { get; set; }
            public string Narration { get; set; }
            public string Status { get; set; }
            public string PaymentType { get; set; }
            public DateTime CreatedAt { get; set; }
            public int AccountId { get; set; }
            public VerifyTransactionCardModel Card { get; set; }
            public object Meta { get; set; }
            public double AmountSettled { get; set; }
            public VerifyTransactionCustomerModel Customer { get; set; }

        }
        public class VerifyTransactionCustomerModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public DateTime CreatedAt { get; set; }

        }

        public class VerifyTransactionCardModel
        {
            public string First6digits { get; set; }
            public string Last4digits { get; set; }
            public string Issuer { get; set; }
            public string Country { get; set; }
            public string Type { get; set; }
            public string Token { get; set; }
            public string Expiry { get; set; }

        }

    }
}
