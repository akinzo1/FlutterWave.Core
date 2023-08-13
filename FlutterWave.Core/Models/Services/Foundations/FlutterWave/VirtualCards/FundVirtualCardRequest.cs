using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class FundVirtualCardRequest
    {
        [JsonProperty("debit_currency")]
        public string DebitCurrency { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
