using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class VirtualCardWithdrawalRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
