using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount
{
    internal class ExternalBulkCreateVirtualAccountsResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalBulkCreateVirtualAccountsData Data { get; set; }


        public class ExternalBulkCreateVirtualAccountsData
        {
            [JsonProperty("batch_id")]
            public string BatchId { get; set; }

            [JsonProperty("response_code")]
            public string ResponseCode { get; set; }

            [JsonProperty("response_message")]
            public string ResponseMessage { get; set; }
        }




    }
}
