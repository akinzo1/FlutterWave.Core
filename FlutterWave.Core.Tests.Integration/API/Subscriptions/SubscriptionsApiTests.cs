namespace FlutterWave.Core.Tests.Integration.API.Subscriptions
{
    public partial class SubscriptionsApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public SubscriptionsApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
