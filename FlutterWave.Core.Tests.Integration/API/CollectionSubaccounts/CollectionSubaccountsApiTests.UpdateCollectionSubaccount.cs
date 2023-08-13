using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;

namespace FlutterWave.Core.Tests.Integration.API.CollectionSubaccounts
{
    public partial class CollectionSubaccountsApiTests
    {
        [Fact]
        public async Task ShouldPostUpdateSubaccountAsync()
        {

            // given
            var request = new UpdateSubaccount
            {
                Request = new UpdateSubaccountRequest
                {
                    SplitValue = 500,
                    SplitType = "flat",
                    BusinessName = "Luxe collectibles",
                    AccountBank = "044",
                    AccountNumber = "0690000040",
                    BusinessEmail = "mad@o.enterprises",

                }
            };

            var subaccountId = 2165;
            // . when
            UpdateSubaccount responseAIModels =
                await this.flutterWaveClient.CollectionSubaccounts.UpdateCollectionSubaccountAsync(subaccountId, request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
