using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards
{
    internal class ExternalVirtualCardWithdrawalRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
