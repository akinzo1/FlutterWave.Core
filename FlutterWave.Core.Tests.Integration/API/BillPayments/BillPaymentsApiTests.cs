namespace FlutterWave.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentsApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public BillPaymentsApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
              
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
