namespace FlutterWave.Core.Tests.Integration.API.VirtualAccounts
{
    public partial class VirtualAccountsApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public VirtualAccountsApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
              
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
