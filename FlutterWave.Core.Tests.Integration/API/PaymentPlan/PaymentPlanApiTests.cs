namespace FlutterWave.Core.Tests.Integration.API.PaymentPlans
{
    public partial class PaymentPlansApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public PaymentPlansApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
