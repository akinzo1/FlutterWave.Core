using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    internal class ExternalSettlementResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Datum Data { get; set; }

        internal class Datum
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("account_id")]
            public int AccountId { get; set; }

            [JsonProperty("merchant_name")]
            public string MerchantName { get; set; }

            [JsonProperty("merchant_email")]
            public string MerchantEmail { get; set; }

            [JsonProperty("settlement_account")]
            public string SettlementAccount { get; set; }

            [JsonProperty("bank_code")]
            public string BankCode { get; set; }

            [JsonProperty("transaction_date")]
            public DateTime TransactionDate { get; set; }

            [JsonProperty("due_date")]
            public DateTime DueDate { get; set; }

            [JsonProperty("processed_date")]
            public object ProcessedDate { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("is_local")]
            public bool IsLocal { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("gross_amount")]
            public int GrossAmount { get; set; }

            [JsonProperty("app_fee")]
            public int AppFee { get; set; }

            [JsonProperty("merchant_fee")]
            public int MerchantFee { get; set; }

            [JsonProperty("chargeback")]
            public int Chargeback { get; set; }

            [JsonProperty("refund")]
            public int Refund { get; set; }

            [JsonProperty("stampduty_charge")]
            public int StampdutyCharge { get; set; }

            [JsonProperty("net_amount")]
            public int NetAmount { get; set; }

            [JsonProperty("transaction_count")]
            public int TransactionCount { get; set; }

            [JsonProperty("processor_ref")]
            public object ProcessorRef { get; set; }

            [JsonProperty("disburse_ref")]
            public string DisburseRef { get; set; }

            [JsonProperty("disburse_message")]
            public object DisburseMessage { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("destination")]
            public string Destination { get; set; }

            [JsonProperty("fx_data")]
            public object FxData { get; set; }

            [JsonProperty("flag_message")]
            public object FlagMessage { get; set; }

            [JsonProperty("meta")]
            public List<int> Meta { get; set; }

            [JsonProperty("refund_meta")]
            public object RefundMeta { get; set; }

            [JsonProperty("chargeback_meta")]
            public object ChargebackMeta { get; set; }

            [JsonProperty("source_bankcode")]
            public object SourceBankcode { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("transactions")]
            public List<Transaction> Transactions { get; set; }
        }





        internal class Transaction
        {
            [JsonProperty("customer_email")]
            public string CustomerEmail { get; set; }

            [JsonProperty("flw_ref")]
            public string FlwRef { get; set; }

            [JsonProperty("tx_ref")]
            public string TxRef { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("charged_amount")]
            public int ChargedAmount { get; set; }

            [JsonProperty("app_fee")]
            public int AppFee { get; set; }

            [JsonProperty("merchant_fee")]
            public int MerchantFee { get; set; }

            [JsonProperty("stampduty_charge")]
            public int StampdutyCharge { get; set; }

            [JsonProperty("settlement_amount")]
            public int SettlementAmount { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("payment_entity")]
            public string PaymentEntity { get; set; }

            [JsonProperty("transaction_date")]
            public string TransactionDate { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("card_locale")]
            public string CardLocale { get; set; }

            [JsonProperty("rrn")]
            public string Rrn { get; set; }

            [JsonProperty("subaccount_settlement")]
            public int SubaccountSettlement { get; set; }
        }




    }
}
