using Newtonsoft.Json;
using System;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class UpdateCardTokenResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public UpdateCardTokenData Data { get; set; }

        public class UpdateCardTokenData
        {
            [JsonProperty("customer_email")]
            public string CustomerEmail { get; set; }

            [JsonProperty("customer_full_name")]
            public string CustomerFullName { get; set; }

            [JsonProperty("customer_phone_number")]
            public string CustomerPhoneNumber { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }






    }
}
