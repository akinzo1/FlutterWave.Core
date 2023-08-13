using Newtonsoft.Json;
using System.Text.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge
{
    internal class ExternalEncryptedChargeRequest
    {
        [JsonProperty("client")]
        public string Client { get; set; }
    }
}
