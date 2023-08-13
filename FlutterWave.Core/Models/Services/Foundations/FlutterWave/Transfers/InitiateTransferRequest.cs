namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class InitiateTransferRequest
    {
        public string AccountBank { get; set; }
        public string AccountNumber { get; set; }
        public int Amount { get; set; }
        public string Narration { get; set; }
        public string Currency { get; set; }
        public string Reference { get; set; }
        public string CallbackUrl { get; set; }
        public string DebitCurrency { get; set; }
    }
}
