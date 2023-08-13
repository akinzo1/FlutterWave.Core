using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions
{
    internal class ExternalFetchTransactionFeesResponse
    {


        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalFetchTransactionFeesDataModel Data { get; set; }

        internal class ExternalFetchTransactionFeesDataModel
        {
            [JsonProperty("charge_amount")]
            public int ChargeAmount { get; set; }

            [JsonProperty("fee")]
            public int Fee { get; set; }

            [JsonProperty("merchant_fee")]
            public int MerchantFee { get; set; }

            [JsonProperty("flutterwave_fee")]
            public int FlutterwaveFee { get; set; }

            [JsonProperty("stamp_duty_fee")]
            public int StampDutyFee { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }
        }





    }
}
