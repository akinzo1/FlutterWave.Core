using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers
{
    internal class ExternalCreateBulkTransferRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("bulk_data")]
        public List<BulkDatum> BulkData { get; set; }

        internal class BulkDatum
        {
            [JsonProperty("bank_code")]
            public string BankCode { get; set; }

            [JsonProperty("account_number")]
            public string AccountNumber { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("narration")]
            public string Narration { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("meta")]
            public List<Metum> Meta { get; set; }
        }

        internal class Metum
        {
            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("mobile_number")]
            public string MobileNumber { get; set; }

            [JsonProperty("recipient_address")]
            public string RecipientAddress { get; set; }
        }






    }
}
