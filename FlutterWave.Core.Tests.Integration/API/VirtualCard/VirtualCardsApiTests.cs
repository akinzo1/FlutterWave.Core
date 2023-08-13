namespace FlutterWave.Core.Tests.Integration.API.VirtualCards
{
    public partial class VirtualCardsApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public VirtualCardsApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
             
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
