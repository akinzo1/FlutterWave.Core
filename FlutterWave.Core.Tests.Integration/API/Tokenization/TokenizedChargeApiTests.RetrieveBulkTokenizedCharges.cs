using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;

namespace FlutterWave.Core.Tests.Integration.API.TokenizedCharge
{
    public partial class TokenizedChargeApiTests
    {
        [Fact]
        public async Task ShouldRetrieveBulkTokenizedChargesAsync()
        {
            // given
            int inputBulkId = 1;


            // when
            FetchBulkTokenizedCharge retrievedModel =
                await this.flutterWaveClient.TokenizedCharge.RetrieveBulkTokenizedChargesAsync(inputBulkId);
            // then
            Assert.NotNull(retrievedModel);
        }
    }
}