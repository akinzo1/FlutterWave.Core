using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount
{
    internal class ExternalCreateVirtualAccountRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("is_permanent")]
        public bool IsPermanent { get; set; }

        [JsonProperty("bvn")]
        public string Bvn { get; set; }

        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }

        [JsonProperty("phonenumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }
    }
}
