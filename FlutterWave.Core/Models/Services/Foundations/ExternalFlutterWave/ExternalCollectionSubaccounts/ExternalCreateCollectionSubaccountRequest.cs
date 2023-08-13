using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts
{
    internal class ExternalCreateCollectionSubaccountRequest
    {




        [JsonProperty("account_bank")]
        public string AccountBank { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("business_email")]
        public string BusinessEmail { get; set; }

        [JsonProperty("business_contact")]
        public string BusinessContact { get; set; }

        [JsonProperty("business_contact_mobile")]
        public string BusinessContactMobile { get; set; }

        [JsonProperty("business_mobile")]
        public string BusinessMobile { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("meta")]
        public List<Metum> Meta { get; set; }

        [JsonProperty("split_type")]
        public string SplitType { get; set; }

        [JsonProperty("split_value")]
        public double SplitValue { get; set; }

        public class Metum
        {
            [JsonProperty("meta_name")]
            public string MetaName { get; set; }

            [JsonProperty("meta_value")]
            public string MetaValue { get; set; }
        }

    }
}
