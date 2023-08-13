using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;

namespace FlutterWave.Core.Tests.Integration.API.CollectionSubaccounts
{
    public partial class CollectionSubaccountsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveCollectionSubaccountsStatusAsync()
        {

            // given
            int inputSubaccountId = 12;

            // . when
            FetchSubaccount responseAIModels =
                await this.flutterWaveClient.CollectionSubaccounts.RetrieveSubaccountAsync(inputSubaccountId);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
