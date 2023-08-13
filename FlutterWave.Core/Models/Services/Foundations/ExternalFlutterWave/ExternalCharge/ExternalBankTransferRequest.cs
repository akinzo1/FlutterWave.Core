using Newtonsoft.Json;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge
{
    internal class ExternalBankTransferRequest
    {

        [JsonProperty("tx_ref")]
        public string TxRef { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("client_ip")]
        public string ClientIp { get; set; }

        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }

        [JsonProperty("is_permanent")]
        public bool IsPermanent { get; set; }


        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("bank_transfer_options")]
        public ExterrnalBankTransferOption BankTransferOptions { get; set; }

        [JsonProperty("meta")]
        public ExternalBankTransferMeta Meta { get; set; }

        [JsonProperty("subaccounts")]
        public ExternalBankTransferSubaccounts Subaccounts { get; set; }

        public class ExterrnalBankTransferOption
        {
            [JsonProperty("expires")]
            public int Expires { get; set; }
        }


        public class ExternalBankTransferMeta
        {
            [JsonProperty("flightId")]
            public string FlightId { get; set; }

            [JsonProperty("sideNote")]
            public string SideNote { get; set; }
        }

        public class ExternalBankTransferSubaccounts
        {
            [JsonProperty("id")]
            public string Id { get; set; }


        }



    }
}
