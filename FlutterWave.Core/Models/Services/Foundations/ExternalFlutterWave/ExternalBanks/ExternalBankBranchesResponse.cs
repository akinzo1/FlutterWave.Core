using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBanks
{
    internal class ExternalBankBranchesResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<ExternalBankBranchesData> Data { get; set; }

        public class ExternalBankBranchesData
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("branch_code")]
            public string BranchCode { get; set; }

            [JsonProperty("branch_name")]
            public string BranchName { get; set; }

            [JsonProperty("swift_code")]
            public string SwiftCode { get; set; }

            [JsonProperty("bic")]
            public string Bic { get; set; }

            [JsonProperty("bank_id")]
            public int BankId { get; set; }
        }





    }
}
