using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization
{
    internal class ExternalVoidPaypalChargeRequest
    {
        [JsonProperty("flw_ref")]
        public string FlwRef { get; set; }
    }
}
