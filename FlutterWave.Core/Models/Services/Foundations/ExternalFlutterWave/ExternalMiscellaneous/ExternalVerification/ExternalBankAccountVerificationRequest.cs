using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification
{
    internal class ExternalBankAccountVerificationRequest
    {
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("account_bank")]
        public string AccountBank { get; set; }
    }
}
