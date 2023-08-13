namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class CreateVirtualAccountRequest
    {
        public string Email { get; set; }
        public bool IsPermanent { get; set; }
        public string Bvn { get; set; }
        public string TxRef { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Narration { get; set; }
    }
}
