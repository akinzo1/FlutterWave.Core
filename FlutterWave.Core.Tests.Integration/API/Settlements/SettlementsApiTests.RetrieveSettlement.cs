using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;

namespace FlutterWave.Core.Tests.Integration.API.Settlements
{
    public partial class SettlementsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveSettlementByReferenceAsync()
        {
            // given
            string inputSettlement = "yuyutr";

            // when
            Settlement retrievedAIModel =
              await this.flutterWaveClient.Settlements.FetchSettlementByIdAsync(inputSettlement);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}