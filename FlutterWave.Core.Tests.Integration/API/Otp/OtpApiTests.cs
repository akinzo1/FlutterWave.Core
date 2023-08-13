namespace FlutterWave.Core.Tests.Integration.API.Otp
{
    public partial class OtpApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public OtpApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
            
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
