namespace FlutterWave.Core.Tests.Integration.API.TokenizedCharge
{
    public partial class TokenizedChargeApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public TokenizedChargeApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
