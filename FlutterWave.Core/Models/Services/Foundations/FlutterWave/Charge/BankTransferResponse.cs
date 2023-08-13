namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class BankTransferResponse
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public BankTransferMeta Meta { get; set; }
        public class Authorization
        {

            public string TransferReference { get; set; }
            public string TransferAccount { get; set; }
            public string TransferBank { get; set; }
            public string AccountExpiration { get; set; }
            public string TransferNote { get; set; }
            public string TransferAmount { get; set; }
            public string Mode { get; set; }
        }

        public class BankTransferMeta
        {

            public Authorization Authorization { get; set; }
        }









    }
}
