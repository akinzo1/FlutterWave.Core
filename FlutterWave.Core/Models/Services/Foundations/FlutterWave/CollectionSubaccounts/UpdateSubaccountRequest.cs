using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class UpdateSubaccountRequest
    {
        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("business_email")]
        public string BusinessEmail { get; set; }

        [JsonProperty("account_bank")]
        public string AccountBank { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("split_type")]
        public string SplitType { get; set; }

        [JsonProperty("split_value")]
        public double SplitValue { get; set; }
    }
}
