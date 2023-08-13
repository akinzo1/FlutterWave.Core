



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldBlockUnblockVirtualCardAsync()
        {
            // given 
            dynamic createRandomBlockUnblockVirtualCardResponseProperties =
                 CreateRandomBlockUnblockVirtualCardResponseProperties();

            var randomVirtualCardId = GetRandomString();
            var randomStatuAction = GetRandomString();

            var randomExternalBlockUnblockVirtualCardsResponse = new ExternalBlockUnblockVirtualCardResponse
            {
                Message = createRandomBlockUnblockVirtualCardResponseProperties.Message,
                Status = createRandomBlockUnblockVirtualCardResponseProperties.Status,
                Data = createRandomBlockUnblockVirtualCardResponseProperties.Data



            };

            var randomExpectedVirtualCardResponse = new BlockUnblockVirtualCardResponse
            {
                Message = createRandomBlockUnblockVirtualCardResponseProperties.Message,
                Status = createRandomBlockUnblockVirtualCardResponseProperties.Status,
                Data = createRandomBlockUnblockVirtualCardResponseProperties.Data

            };


            var expectedInputVirtualCard = new BlockUnblockVirtualCard
            {
                Response = randomExpectedVirtualCardResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatuAction))
                    .ReturnsAsync(randomExternalBlockUnblockVirtualCardsResponse);

            // when
            BlockUnblockVirtualCard actualVirtualCard =
                await this.virtualCardsService.PostBlockUnblockVirtualCardRequestAsync(randomVirtualCardId, randomStatuAction);

            // then
            actualVirtualCard.Should().BeEquivalentTo(expectedInputVirtualCard);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatuAction),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}