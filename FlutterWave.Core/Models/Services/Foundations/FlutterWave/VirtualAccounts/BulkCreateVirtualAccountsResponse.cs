namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccount
{
    public class BulkCreateVirtualAccountResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public BulkCreateVirtualAccountsData Data { get; set; }


        public class BulkCreateVirtualAccountsData
        {
            public string BatchId { get; set; }
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
        }
    }
}
