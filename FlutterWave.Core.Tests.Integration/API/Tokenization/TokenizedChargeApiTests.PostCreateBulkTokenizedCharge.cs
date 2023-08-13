using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;

namespace FlutterWave.Core.Tests.Integration.API.TokenizedCharge
{
    public partial class TokenizedChargeApiTests
    {
        [Fact]
        public async Task ShouldPostCreateBulkTokenizedChargeAsync()
        {

            // given
            var request = new CreateBulkTokenizedCharge
            {
                Request = new CreateBulkTokenizedChargeRequest
                {
                    BulkData = new List<CreateBulkTokenizedChargeRequest.BulkDatum>
                  {
                       new CreateBulkTokenizedChargeRequest.BulkDatum
                       {
                         Amount = 1,
                         Country = "12",
                         Currency = "NG",
                         Email = "slim",
                         FirstName = "Ahmad",
                         Ip = "127.0.0.1",
                         LastName = "salim",
                         Token = "e",
                         TxRef = "eeyuyrfddffd"
                       }

                  },
                    RetryStrategy = new CreateBulkTokenizedChargeRequest.RetryStrategyData
                    {
                        RetryAmountVariable = 0,
                        RetryAttemptVariable = 0,
                        RetryInterval = 0,
                    },
                    Title = "rtrer"
                }
            };

            // . when
            CreateBulkTokenizedCharge responseAIModels =
                await this.flutterWaveClient.TokenizedCharge.CreateBulkTokenizedChargeAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
