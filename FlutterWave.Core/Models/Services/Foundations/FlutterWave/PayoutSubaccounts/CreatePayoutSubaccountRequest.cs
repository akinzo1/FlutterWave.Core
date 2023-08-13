using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class CreatePayoutSubaccountRequest
    {
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobilenumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("account_reference")]
        public string AccountReference { get; set; }

        [JsonProperty("barter_Id")]
        public string BarterId { get; set; }

        [JsonProperty("bank_code")]
        public int BankCode { get; set; }
    }
}
