namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class FetchTransactionFeesResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public FetchTransactionFeesDataModel Data { get; set; }

        public class FetchTransactionFeesDataModel
        {
            public int ChargeAmount { get; set; }
            public int Fee { get; set; }
            public int MerchantFee { get; set; }
            public int FlutterwaveFee { get; set; }
            public int StampDutyFee { get; set; }
            public string Currency { get; set; }
        }





    }
}
