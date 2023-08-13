namespace FlutterWave.Core.Tests.Integration.API.Settlements
{
    public partial class SettlementsApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public SettlementsApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
