using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge
{
    internal class ExternalBankTransferResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("meta")]
        public ExternalBankTransferMeta Meta { get; set; }
        public class Authorization
        {
            [JsonProperty("transfer_reference")]
            public string TransferReference { get; set; }

            [JsonProperty("transfer_account")]
            public string TransferAccount { get; set; }

            [JsonProperty("transfer_bank")]
            public string TransferBank { get; set; }

            [JsonProperty("account_expiration")]
            public string AccountExpiration { get; set; }

            [JsonProperty("transfer_note")]
            public string TransferNote { get; set; }

            [JsonProperty("transfer_amount")]
            public string TransferAmount { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }
        }

        public class ExternalBankTransferMeta
        {
            [JsonProperty("authorization")]
            public Authorization Authorization { get; set; }
        }









    }
}
