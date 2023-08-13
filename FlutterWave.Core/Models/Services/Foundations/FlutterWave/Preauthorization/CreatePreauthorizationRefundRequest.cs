
using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class CreatePreauthorizationRefundRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
