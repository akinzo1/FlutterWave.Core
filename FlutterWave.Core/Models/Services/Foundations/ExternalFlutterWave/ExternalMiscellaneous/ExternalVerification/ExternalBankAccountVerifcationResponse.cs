using System.Text.Json.Serialization;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification
{
    internal class ExternalBankAccountVerificationResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public ExternalBankAccountVerificationData Data { get; set; }

        internal class ExternalBankAccountVerificationData
        {
            [JsonPropertyName("account_number")]
            public string AccountNumber { get; set; }

            [JsonPropertyName("account_name")]
            public string AccountName { get; set; }
        }



    }
}
