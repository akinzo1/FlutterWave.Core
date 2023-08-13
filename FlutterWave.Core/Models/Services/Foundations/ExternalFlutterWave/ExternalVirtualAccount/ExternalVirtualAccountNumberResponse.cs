using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount
{
    internal class ExternalVirtualAccountNumberResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public VirtualAccountNumberData Data { get; set; }

        internal class VirtualAccountNumberData
        {
            [JsonProperty("response_code")]
            public string ResponseCode { get; set; }

            [JsonProperty("response_message")]
            public string ResponseMessage { get; set; }

            [JsonProperty("flw_ref")]
            public string FlwRef { get; set; }

            [JsonProperty("order_ref")]
            public string OrderRef { get; set; }

            [JsonProperty("account_number")]
            public string AccountNumber { get; set; }

            [JsonProperty("frequency")]
            public string Frequency { get; set; }

            [JsonProperty("bank_name")]
            public string BankName { get; set; }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("expiry_date")]
            public string ExpiryDate { get; set; }

            [JsonProperty("note")]
            public string Note { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }
        }






    }
}
