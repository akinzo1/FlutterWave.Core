using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards
{
    internal class ExternalCreateVirtualCardRequest
    {

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("debit_currency")]
        public string DebitCurrency { get; set; }

        [JsonProperty("billing_name")]
        public string BillingName { get; set; }

        [JsonProperty("billing_address")]
        public string BillingAddress { get; set; }

        [JsonProperty("billing_city")]
        public string BillingCity { get; set; }

        [JsonProperty("billing_state")]
        public string BillingState { get; set; }

        [JsonProperty("billing_postal_code")]
        public string BillingPostalCode { get; set; }

        [JsonProperty("billing_country")]
        public string BillingCountry { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }



    }
}
