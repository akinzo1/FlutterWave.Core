namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous
{
    public class BvnConsentResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public BvnConsentData Data { get; set; }

        public class BvnConsentData
        {
            public string Url { get; set; }
            public string Reference { get; set; }
        }
    }
}
