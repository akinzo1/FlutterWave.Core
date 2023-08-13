



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldPostFundVirtualCardWithFundVirtualCardRequestAsync()
        {
            // given 



            dynamic createRandomFundVirtualCardRequestProperties =
              CreateRandomFundVirtualCardRequestProperties();

            dynamic createRandomFundVirtualCardResponseProperties =
                CreateRandomFundVirtualCardResponseProperties();

            var virtualCardId = GetRandomString();

            var randomExternalFundVirtualCardRequest = new ExternalFundVirtualCardRequest
            {
                Amount = createRandomFundVirtualCardRequestProperties.Amount,
                DebitCurrency = createRandomFundVirtualCardRequestProperties.DebitCurrency


            };

            var randomExternalFundVirtualCardResponse = new ExternalFundVirtualCardResponse
            {
                Data = createRandomFundVirtualCardResponseProperties.Data,
                Message = createRandomFundVirtualCardResponseProperties.Message,
                Status = createRandomFundVirtualCardResponseProperties.Status


            };


            var randomFundVirtualCardRequest = new FundVirtualCardRequest
            {
                Amount = createRandomFundVirtualCardRequestProperties.Amount,
                DebitCurrency = createRandomFundVirtualCardRequestProperties.DebitCurrency


            };
            var randomFundVirtualCardResponse = new FundVirtualCardResponse
            {
                Data = createRandomFundVirtualCardResponseProperties.Data,
                Message = createRandomFundVirtualCardResponseProperties.Message,
                Status = createRandomFundVirtualCardResponseProperties.Status

            };



            var randomFundVirtualCard = new FundVirtualCard
            {
                Request = randomFundVirtualCardRequest,
            };

            FundVirtualCard inputFundVirtualCard = randomFundVirtualCard;
            FundVirtualCard expectedFundVirtualCard = inputFundVirtualCard.DeepClone();
            expectedFundVirtualCard.Response = randomFundVirtualCardResponse;

            ExternalFundVirtualCardRequest mappedExternalFundVirtualCardRequest =
               randomExternalFundVirtualCardRequest;

            ExternalFundVirtualCardResponse returnedExternalFundVirtualCardResponse =
                randomExternalFundVirtualCardResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.Is(
                      SameExternalFundVirtualCardRequestAs(mappedExternalFundVirtualCardRequest))))
                     .ReturnsAsync(returnedExternalFundVirtualCardResponse);

            // when
            FundVirtualCard actualCreateFundVirtualCard =
               await this.virtualCardsService.PostFundVirtualCardRequestAsync(virtualCardId, inputFundVirtualCard);

            // then
            actualCreateFundVirtualCard.Should().BeEquivalentTo(expectedFundVirtualCard);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.Is(
                   SameExternalFundVirtualCardRequestAs(mappedExternalFundVirtualCardRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}