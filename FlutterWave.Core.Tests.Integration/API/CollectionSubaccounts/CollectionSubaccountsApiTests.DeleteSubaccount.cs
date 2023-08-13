using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;

namespace FlutterWave.Core.Tests.Integration.API.CollectionSubaccounts
{
    public partial class CollectionSubaccountsApiTests
    {
        [Fact]
        public async Task ShouldDeleteSubaccountAsync()
        {
            // given
            int inputSubaccountId = 123;


            // when
            DeleteSubaccount retrievedAIModel =
                await this.flutterWaveClient.CollectionSubaccounts.DeleteCollectionSubaccountAsync(inputSubaccountId);
            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}