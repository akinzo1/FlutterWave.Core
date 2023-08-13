using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;

namespace FlutterWave.Core.Tests.Integration.API.VirtualCards
{
    public partial class VirtualCardsApiTests
    {
        [Fact]
        public async Task ShouldPostVirtualCardWithdrawalAsync()
        {

            // given
            var request = new VirtualCardWithdrawal
            {
                Request = new VirtualCardWithdrawalRequest
                {
                    Amount = 1,
                }
            };

            var virtualCardId = "1234";
            // . when
            VirtualCardWithdrawal responseAIModels =
                await this.flutterWaveClient.VirtualCards.VirtualCardWithdrawalAsync(virtualCardId, request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
