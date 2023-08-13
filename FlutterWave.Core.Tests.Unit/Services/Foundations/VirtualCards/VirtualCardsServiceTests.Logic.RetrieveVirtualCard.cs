



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveVirtualCardAsync()
        {
            // given 
            dynamic createRandomFetchVirtualCardResponseProperties =
                 CreateRandomFetchVirtualCardResponseProperties();

            var randomVirtualCardId = GetRandomString();

            var randomExternalFetchVirtualCardsResponse = new ExternalFetchVirtualCardResponse
            {
                Message = createRandomFetchVirtualCardResponseProperties.Message,
                Status = createRandomFetchVirtualCardResponseProperties.Status,
                Data = new ExternalFetchVirtualCardResponse.ExternalFetchVirtualCardData
                {
                    AccountId = createRandomFetchVirtualCardResponseProperties.Data.AccountId,
                    Address1 = createRandomFetchVirtualCardResponseProperties.Data.Address1,
                    Address2 = createRandomFetchVirtualCardResponseProperties.Data.Address2,
                    Amount = createRandomFetchVirtualCardResponseProperties.Data.Amount,
                    BinCheckName = createRandomFetchVirtualCardResponseProperties.Data.BinCheckName,
                    CallbackUrl = createRandomFetchVirtualCardResponseProperties.Data.CallbackUrl,
                    CardHash = createRandomFetchVirtualCardResponseProperties.Data.CardHash,
                    CardPan = createRandomFetchVirtualCardResponseProperties.Data.CardPan,
                    CardType = createRandomFetchVirtualCardResponseProperties.Data.CardType,
                    City = createRandomFetchVirtualCardResponseProperties.Data.City,
                    CreatedAt = createRandomFetchVirtualCardResponseProperties.Data.CreatedAt,
                    Currency = createRandomFetchVirtualCardResponseProperties.Data.Currency,
                    Cvv = createRandomFetchVirtualCardResponseProperties.Data.Cvv,
                    Expiration = createRandomFetchVirtualCardResponseProperties.Data.Expiration,
                    Id = createRandomFetchVirtualCardResponseProperties.Data.Id,
                    IsActive = createRandomFetchVirtualCardResponseProperties.Data.IsActive,
                    MaskedPan = createRandomFetchVirtualCardResponseProperties.Data.MaskedPan,
                    NameOnCard = createRandomFetchVirtualCardResponseProperties.Data.NameOnCard,
                    SendTo = createRandomFetchVirtualCardResponseProperties.Data.SendTo,
                    State = createRandomFetchVirtualCardResponseProperties.Data.State,
                    ZipCode = createRandomFetchVirtualCardResponseProperties.Data.ZipCode

                }



            };

            var randomExpectedVirtualCardResponse = new FetchVirtualCardResponse
            {
                Message = createRandomFetchVirtualCardResponseProperties.Message,
                Status = createRandomFetchVirtualCardResponseProperties.Status,
                Data = new FetchVirtualCardResponse.FetchVirtualCardData
                {
                    AccountId = createRandomFetchVirtualCardResponseProperties.Data.AccountId,
                    Address1 = createRandomFetchVirtualCardResponseProperties.Data.Address1,
                    Address2 = createRandomFetchVirtualCardResponseProperties.Data.Address2,
                    Amount = createRandomFetchVirtualCardResponseProperties.Data.Amount,
                    BinCheckName = createRandomFetchVirtualCardResponseProperties.Data.BinCheckName,
                    CallbackUrl = createRandomFetchVirtualCardResponseProperties.Data.CallbackUrl,
                    CardHash = createRandomFetchVirtualCardResponseProperties.Data.CardHash,
                    CardPan = createRandomFetchVirtualCardResponseProperties.Data.CardPan,
                    CardType = createRandomFetchVirtualCardResponseProperties.Data.CardType,
                    City = createRandomFetchVirtualCardResponseProperties.Data.City,
                    CreatedAt = createRandomFetchVirtualCardResponseProperties.Data.CreatedAt,
                    Currency = createRandomFetchVirtualCardResponseProperties.Data.Currency,
                    Cvv = createRandomFetchVirtualCardResponseProperties.Data.Cvv,
                    Expiration = createRandomFetchVirtualCardResponseProperties.Data.Expiration,
                    Id = createRandomFetchVirtualCardResponseProperties.Data.Id,
                    IsActive = createRandomFetchVirtualCardResponseProperties.Data.IsActive,
                    MaskedPan = createRandomFetchVirtualCardResponseProperties.Data.MaskedPan,
                    NameOnCard = createRandomFetchVirtualCardResponseProperties.Data.NameOnCard,
                    SendTo = createRandomFetchVirtualCardResponseProperties.Data.SendTo,
                    State = createRandomFetchVirtualCardResponseProperties.Data.State,
                    ZipCode = createRandomFetchVirtualCardResponseProperties.Data.ZipCode

                }

            };


            var expectedInputVirtualCard = new FetchVirtualCard
            {
                Response = randomExpectedVirtualCardResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId))
                    .ReturnsAsync(randomExternalFetchVirtualCardsResponse);

            // when
            FetchVirtualCard actualVirtualCard =
                await this.virtualCardsService.GetVirtualCardRequestAsync(randomVirtualCardId);

            // then
            actualVirtualCard.Should().BeEquivalentTo(expectedInputVirtualCard);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}