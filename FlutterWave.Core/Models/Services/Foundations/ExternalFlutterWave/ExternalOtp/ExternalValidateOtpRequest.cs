using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp
{
    internal class ExternalValidateOtpRequest
    {
        [JsonProperty("otp")]
        public string Otp { get; set; }


    }
}
