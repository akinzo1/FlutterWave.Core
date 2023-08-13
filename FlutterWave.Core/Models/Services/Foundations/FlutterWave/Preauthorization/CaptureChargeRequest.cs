using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class CaptureChargeRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
