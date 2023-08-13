using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp
{
    internal class ExternalCreateOtpRequest
    {
        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("customer")]
        public ExternalCustomerModel Customer { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("send")]
        public bool Send { get; set; }

        [JsonProperty("medium")]
        public List<string> Medium { get; set; }

        [JsonProperty("expiry")]
        public int Expiry { get; set; }

        public class ExternalCustomerModel
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("phone")]
            public string Phone { get; set; }
        }


    }
}
