namespace FlutterWave.Core.Tests.Integration.API.Banks
{
    public partial class BanksApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public BanksApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
