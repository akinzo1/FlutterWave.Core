namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class DeleteVirtualAccountResponse
    {

        public string Status { get; set; }
        public string Message { get; set; }
        public DeleteVirtualAccountData Data { get; set; }

        public class DeleteVirtualAccountData
        {
            public string Status { get; set; }
            public string StatusDesc { get; set; }
        }

    }
}
