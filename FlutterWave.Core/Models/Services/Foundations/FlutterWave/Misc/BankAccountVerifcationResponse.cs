namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous
{
    public class BankAccountVerificationResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public BankAccountVerificationData Data { get; set; }

        public class BankAccountVerificationData
        {
            public string AccountNumber { get; set; }
            public string AccountName { get; set; }
        }



    }
}
