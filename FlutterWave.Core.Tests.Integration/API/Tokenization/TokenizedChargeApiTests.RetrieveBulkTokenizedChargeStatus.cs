using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;

namespace FlutterWave.Core.Tests.Integration.API.TokenizedCharge
{
    public partial class TokenizedChargeApiTests
    {
        [Fact]
        public async Task ShouldRetrieveTokenizedChargeStatusAsync()
        {

            // given
            int inputBulkId = 1;

            // . when
            BulkTokenizedStatus responseModels =
                await this.flutterWaveClient.TokenizedCharge.RetrieveBulkTokenizedStatusAsync(inputBulkId);

            // then
            Assert.NotNull(responseModels);
        }
    }
}
