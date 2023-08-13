using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;

namespace FlutterWave.Core.Tests.Integration.API.Settlements
{
    public partial class SettlementsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveAllSettlementsAsync()
        {

            // given

            // . when
            AllSettlements responseAIModels =
                await this.flutterWaveClient.Settlements.RetrieveAllSettlementsAsync();

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
