namespace FlutterWave.Core.Tests.Integration.API.Miscellaneous
{
    public partial class MiscellaneousApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public MiscellaneousApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
