using Newtonsoft.Json;
using System.Text.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class EncryptedChargeRequest
    {
        [JsonProperty("client")]
        public string Client { get; set; }
    }
}
