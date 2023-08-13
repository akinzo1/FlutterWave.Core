using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;

namespace FlutterWave.Core.Tests.Integration.API.CollectionSubaccounts
{
    public partial class CollectionSubaccountsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveSubaccountAsync()
        {

            // given


            // . when
            FetchSubaccounts responseAIModels =
                await this.flutterWaveClient.CollectionSubaccounts.RetrieveSubaccountsAsync();

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
