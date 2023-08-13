using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization
{
    internal class ExternalCaptureChargeRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
