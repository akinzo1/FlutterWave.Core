using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class BankBranchesResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<BankBranchesData> Data { get; set; }

        public class BankBranchesData
        {
            public int Id { get; set; }
            public string BranchCode { get; set; }
            public string BranchName { get; set; }
            public string SwiftCode { get; set; }
            public string Bic { get; set; }
            public int BankId { get; set; }
        }

    }
}
