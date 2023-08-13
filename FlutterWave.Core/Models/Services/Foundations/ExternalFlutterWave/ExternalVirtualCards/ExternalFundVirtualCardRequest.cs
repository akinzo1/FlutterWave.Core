using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards
{
    internal class ExternalFundVirtualCardRequest
    {
        [JsonProperty("debit_currency")]
        public string DebitCurrency { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
