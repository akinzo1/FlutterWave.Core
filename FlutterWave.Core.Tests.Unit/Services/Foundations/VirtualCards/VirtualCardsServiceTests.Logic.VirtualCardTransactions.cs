



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldVirtualCardTransactionsAsync()
        {
            // given 
            dynamic createRandomVirtualCardTransactionsResponseProperties =
                 CreateRandomVirtualCardTransactionsResponseProperties();

            var randomVirtualCardId = GetRandomString();

            var randomExternalVirtualCardTransactionsResponse = new ExternalVirtualCardTransactionsResponse
            {
                Message = createRandomVirtualCardTransactionsResponseProperties.Message,
                Status = createRandomVirtualCardTransactionsResponseProperties.Status,
                Data = createRandomVirtualCardTransactionsResponseProperties.Data



            };

            var randomExpectedVirtualCardResponse = new VirtualCardTransactionsResponse
            {
                Message = createRandomVirtualCardTransactionsResponseProperties.Message,
                Status = createRandomVirtualCardTransactionsResponseProperties.Status,
                Data = createRandomVirtualCardTransactionsResponseProperties.Data

            };


            var expectedInputVirtualCard = new VirtualCardTransactions
            {
                Response = randomExpectedVirtualCardResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetVirtualCardTransactionsAsync(randomVirtualCardId))
                    .ReturnsAsync(randomExternalVirtualCardTransactionsResponse);

            // when
            VirtualCardTransactions actualVirtualCard =
                await this.virtualCardsService.GetVirtualCardTransactionsRequestAsync(randomVirtualCardId);

            // then
            actualVirtualCard.Should().BeEquivalentTo(expectedInputVirtualCard);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardTransactionsAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}