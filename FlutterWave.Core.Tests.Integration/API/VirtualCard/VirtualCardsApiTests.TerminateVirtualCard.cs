using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;

namespace FlutterWave.Core.Tests.Integration.API.VirtualCards
{
    public partial class VirtualCardsApiTests
    {
        [Fact]
        public async Task ShouldTerminateVirtualCardsAsync()
        {
            // given
            string virtualCardId = "AT099";



            // when
            TerminateVirtualCard retrievedModel =
                await this.flutterWaveClient.VirtualCards.TerminateVirtualCardAsync(virtualCardId);
            // then
            Assert.NotNull(retrievedModel);
        }
    }
}