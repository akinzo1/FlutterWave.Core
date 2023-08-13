using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class UpdatePayoutSubaccountRequest
    {
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobilenumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
