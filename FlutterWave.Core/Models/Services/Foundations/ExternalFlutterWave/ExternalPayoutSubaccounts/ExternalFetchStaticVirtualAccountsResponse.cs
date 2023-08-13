using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts
{
    internal class ExternalFetchStaticVirtualAccountsResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalFetchStaticVirtualAccountsData Data { get; set; }

        public class ExternalFetchStaticVirtualAccountsData
        {
            [JsonProperty("static_account")]
            public string StaticAccount { get; set; }

            [JsonProperty("bank_name")]
            public string BankName { get; set; }

            [JsonProperty("bank_code")]
            public string BankCode { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("is_default")]
            public object IsDefault { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }





    }
}
