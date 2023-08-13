using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount
{
    internal class ExternalDeleteVirtualAccountResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalDeleteVirtualAccountData Data { get; set; }

        public class ExternalDeleteVirtualAccountData
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("status_desc")]
            public string StatusDesc { get; set; }
        }




    }
}
