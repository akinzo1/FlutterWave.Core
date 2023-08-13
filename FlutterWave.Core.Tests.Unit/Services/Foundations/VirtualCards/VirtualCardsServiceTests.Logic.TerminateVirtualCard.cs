



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldTerminateVirtualCardAsync()
        {
            // given 
            dynamic createRandomTerminateVirtualCardResponseProperties =
                 CreateRandomTerminateVirtualCardResponseProperties();

            var randomVirtualCardId = GetRandomString();

            var randomExternalTerminateVirtualCardsResponse = new ExternalTerminateVirtualCardResponse
            {
                Message = createRandomTerminateVirtualCardResponseProperties.Message,
                Status = createRandomTerminateVirtualCardResponseProperties.Status,
                Data = createRandomTerminateVirtualCardResponseProperties.Data



            };

            var randomExpectedVirtualCardResponse = new TerminateVirtualCardResponse
            {
                Message = createRandomTerminateVirtualCardResponseProperties.Message,
                Status = createRandomTerminateVirtualCardResponseProperties.Status,
                Data = createRandomTerminateVirtualCardResponseProperties.Data

            };


            var expectedInputVirtualCard = new TerminateVirtualCard
            {
                Response = randomExpectedVirtualCardResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId))
                    .ReturnsAsync(randomExternalTerminateVirtualCardsResponse);

            // when
            TerminateVirtualCard actualVirtualCard =
                await this.virtualCardsService.PostTerminateVirtualCardRequestAsync(randomVirtualCardId);

            // then
            actualVirtualCard.Should().BeEquivalentTo(expectedInputVirtualCard);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}