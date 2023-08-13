
using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization
{
    internal class ExternalCreatePreauthorizationRefundRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
