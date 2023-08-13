using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBanks
{
    internal class ExternalBankResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<ExternalBankData> Data { get; set; }

        public class ExternalBankData
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }







    }
}
