using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount
{
    internal class ExternalCreateBulkVirtualAccountsRequest
    {
        [JsonProperty("accounts")]
        public int Accounts { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("is_permanent")]
        public bool IsPermanent { get; set; }

        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }
    }
}
