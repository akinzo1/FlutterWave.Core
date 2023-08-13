using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge
{
    internal class ExternalValidateChargeRequest
    {
        [JsonProperty("otp")]
        public string Otp { get; set; }

        [JsonProperty("flw_ref")]
        public string FlwRef { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
