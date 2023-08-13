using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;

namespace FlutterWave.Core.Tests.Integration.API.VirtualCards
{
    public partial class VirtualCardsApiTests
    {
        [Fact]
        public async Task ShouldPayoutSubaccountAvailableBalanceAsync()
        {
            // given
            string virtualCardId = "AT099";



            // when
            FetchVirtualCard retrievedModel =
                await this.flutterWaveClient.VirtualCards.RetrieveVirtualCardAsync(virtualCardId);
            // then
            Assert.NotNull(retrievedModel);
        }
    }
}