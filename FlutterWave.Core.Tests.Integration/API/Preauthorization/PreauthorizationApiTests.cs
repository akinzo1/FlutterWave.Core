namespace FlutterWave.Core.Tests.Integration.API.Preauthorization
{
    public partial class PreauthorizationApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public PreauthorizationApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
             
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
