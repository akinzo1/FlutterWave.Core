using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization
{
    internal class ExternalCapturePayPalChargeRequest
    {
        [JsonProperty("flw_ref")]
        public string FlwRef { get; set; }
    }
}
