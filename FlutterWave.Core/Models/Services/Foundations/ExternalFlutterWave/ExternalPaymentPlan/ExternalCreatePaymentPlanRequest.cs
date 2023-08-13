using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPaymentPlan
{
    internal class ExternalCreatePaymentPlanRequest
    {

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }



    }
}
