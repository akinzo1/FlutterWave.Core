using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts
{
    internal class ExternalUpdatePayoutSubaccountRequest
    {
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobilenumber")]
        public string Mobilenumber { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
