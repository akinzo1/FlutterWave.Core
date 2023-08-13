using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack
{
    internal class ExternalAcceptDeclineChargeBackRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("comment")]
        public string Comment { get; set; }




    }
}
