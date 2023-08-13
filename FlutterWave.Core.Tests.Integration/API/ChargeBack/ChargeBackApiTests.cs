namespace FlutterWave.Core.Tests.Integration.API.ChargeBacks
{
    public partial class ChargeBackApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public ChargeBackApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
