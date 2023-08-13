using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount
{
    internal class ExternalCreateVirtualAccountResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalCreateVirtualAccountDataModel Data { get; set; }

        internal class ExternalCreateVirtualAccountDataModel
        {
            [JsonProperty("response_code")]
            public string ResponseCode { get; set; }

            [JsonProperty("response_message")]
            public string ResponseMessage { get; set; }

            [JsonProperty("order_ref")]
            public string OrderRef { get; set; }

            [JsonProperty("account_number")]
            public string AccountNumber { get; set; }

            [JsonProperty("bank_name")]
            public string BankName { get; set; }

            [JsonProperty("amount")]
            public object Amount { get; set; }
        }
    }

}
