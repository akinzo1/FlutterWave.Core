namespace FlutterWave.Core.Tests.Integration.API.PayoutSubaccounts
{
    public partial class PayoutSubaccountsApiTests
    {
        private readonly IFlutterWaveClient flutterWaveClient;

        public PayoutSubaccountsApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
               
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }
    }
}
