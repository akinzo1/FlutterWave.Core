using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge
{
    internal class ExternalUpdateCardTokenRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
