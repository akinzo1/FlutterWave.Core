using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;

namespace FlutterWave.Core.Tests.Integration.API.VirtualCards
{
    public partial class VirtualCardsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveVirtualCardsAsync()
        {
            // given



            // when
            FetchVirtualCards retrievedModel =
                await this.flutterWaveClient.VirtualCards.RetrieveVirtualCardsAsync();
            // then
            Assert.NotNull(retrievedModel);
        }
    }
}