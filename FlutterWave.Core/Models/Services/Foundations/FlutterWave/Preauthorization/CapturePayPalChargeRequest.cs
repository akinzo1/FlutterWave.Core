using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class CapturePayPalChargeRequest
    {
        [JsonProperty("flw_ref")]
        public string FlwRef { get; set; }
    }
}
