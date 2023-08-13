



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveVirtualCardsAsync()
        {
            // given 
            dynamic createRandomFetchVirtualCardsResponseProperties =
                 CreateRandomFetchVirtualCardsResponseProperties();

            var RandomExternalFetchVirtualCardsResponse = new ExternalFetchVirtualCardsResponse
            {
                Message = createRandomFetchVirtualCardsResponseProperties.Message,
                Status = createRandomFetchVirtualCardsResponseProperties.Status,
                Data = ((List<dynamic>)createRandomFetchVirtualCardsResponseProperties.Data).Select(data =>
                {
                    return new ExternalFetchVirtualCardsResponse.Datum
                    {
                        AccountId = data.AccountId,
                        Address1 = data.Address1,
                        Address2 = data.Address2,
                        Amount = data.Amount,
                        BinCheckName = data.BinCheckName,
                        CallbackUrl = data.CallbackUrl,
                        CardHash = data.CardHash,
                        CardPan = data.CardPan,
                        CardType = data.CardType,
                        City = data.City,
                        CreatedAt = data.CreatedAt,
                        Currency = data.Currency,
                        Cvv = data.Cvv,
                        Expiration = data.Expiration,
                        Id = data.Id,
                        IsActive = data.IsActive,
                        MaskedPan = data.MaskedPan,
                        NameOnCard = data.NameOnCard,
                        SendTo = data.SendTo,
                        State = data.State,
                        ZipCode = data.ZipCode

                    };
                }).ToList(),


            };

            var RandomExpectedVirtualCardResponse = new FetchVirtualCardsResponse
            {
                Message = createRandomFetchVirtualCardsResponseProperties.Message,
                Status = createRandomFetchVirtualCardsResponseProperties.Status,
                Data = ((List<dynamic>)createRandomFetchVirtualCardsResponseProperties.Data).Select(data =>
                {
                    return new FetchVirtualCardsResponse.Datum
                    {
                        AccountId = data.AccountId,
                        Address1 = data.Address1,
                        Address2 = data.Address2,
                        Amount = data.Amount,
                        BinCheckName = data.BinCheckName,
                        CallbackUrl = data.CallbackUrl,
                        CardHash = data.CardHash,
                        CardPan = data.CardPan,
                        CardType = data.CardType,
                        City = data.City,
                        CreatedAt = data.CreatedAt,
                        Currency = data.Currency,
                        Cvv = data.Cvv,
                        Expiration = data.Expiration,
                        Id = data.Id,
                        IsActive = data.IsActive,
                        MaskedPan = data.MaskedPan,
                        NameOnCard = data.NameOnCard,
                        SendTo = data.SendTo,
                        State = data.State,
                        ZipCode = data.ZipCode

                    };
                }).ToList(),

            };


            var expectedInputVirtualCard = new FetchVirtualCards
            {
                Response = RandomExpectedVirtualCardResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetVirtualCardsAsync())
                    .ReturnsAsync(RandomExternalFetchVirtualCardsResponse);

            // when
            FetchVirtualCards actualVirtualCard =
                await this.virtualCardsService.GetVirtualCardsRequestAsync();

            // then
            actualVirtualCard.Should().BeEquivalentTo(expectedInputVirtualCard);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}