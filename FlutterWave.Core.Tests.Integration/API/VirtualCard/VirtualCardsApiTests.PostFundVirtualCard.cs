using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;

namespace FlutterWave.Core.Tests.Integration.API.VirtualCards
{
    public partial class VirtualCardsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveFundVirtualCardAsync()
        {
            // given
            string virtualCardId = "AT099";
            var request = new FundVirtualCard
            {
                Request = new FundVirtualCardRequest
                {
                    Amount = 100,
                    DebitCurrency = "NG"
                }
            };


            // when
            FundVirtualCard retrievedAIModel =
                await this.flutterWaveClient.VirtualCards.PostFundVirtualCardAsync(virtualCardId, request);
            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}