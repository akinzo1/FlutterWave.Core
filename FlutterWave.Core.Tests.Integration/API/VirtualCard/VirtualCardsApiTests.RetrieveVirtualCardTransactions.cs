using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;

namespace FlutterWave.Core.Tests.Integration.API.VirtualCards
{
    public partial class VirtualCardsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveVirtualCardTransactionAsync()
        {
            // given
            string virtualCardId = "AT099";



            // when
            VirtualCardTransactions retrievedModel =
                await this.flutterWaveClient.VirtualCards.GetVirtualCardTransactionsAsync(virtualCardId);
            // then
            Assert.NotNull(retrievedModel);
        }
    }
}