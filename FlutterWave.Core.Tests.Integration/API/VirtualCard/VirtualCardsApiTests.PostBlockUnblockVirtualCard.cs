using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;

namespace FlutterWave.Core.Tests.Integration.API.VirtualCards
{
    public partial class VirtualCardsApiTests
    {
        [Fact]
        public async Task ShouldBlockUnblockVirtualCardAsync()
        {
            // given
            string virtualCardId = "AT099";
            string statusAction = "BIL099";


            // when
            BlockUnblockVirtualCard retrievedModel =
                await this.flutterWaveClient.VirtualCards.PostBlockUnblockVirtualCardAsync(virtualCardId, statusAction);
            // then
            Assert.NotNull(retrievedModel);
        }
    }
}