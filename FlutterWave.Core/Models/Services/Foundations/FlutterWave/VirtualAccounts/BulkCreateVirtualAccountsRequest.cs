namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class BulkCreateVirtualAccountsRequest
    {
        public int Accounts { get; set; }
        public string Email { get; set; }
        public bool IsPermanent { get; set; }
        public string TxRef { get; set; }
    }
}
