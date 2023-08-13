namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class CreateVirtualAccountResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public CreateVirtualAccountDataModel Data { get; set; }

        public class CreateVirtualAccountDataModel
        {
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public string OrderRef { get; set; }
            public string AccountNumber { get; set; }
            public string BankName { get; set; }
            public object Amount { get; set; }
        }
    }

}
