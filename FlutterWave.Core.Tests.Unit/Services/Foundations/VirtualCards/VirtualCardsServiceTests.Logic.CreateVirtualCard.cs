



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
        public async Task ShouldPostCreateVirtualCardWithCreateVirtualCardRequestAsync()
        {
            // given 



            dynamic createRandomCreateVirtualCardRequestProperties =
              CreateRandomCreateVirtualCardRequestProperties();

            dynamic createRandomCreateVirtualCardResponseProperties =
                CreateRandomCreateVirtualCardResponseProperties();


            var randomExternalCreateVirtualCardRequest = new ExternalCreateVirtualCardRequest
            {
                Amount = createRandomCreateVirtualCardRequestProperties.Amount,
                BillingAddress = createRandomCreateVirtualCardRequestProperties.BillingAddress,
                BillingCity = createRandomCreateVirtualCardRequestProperties.BillingCity,
                BillingCountry = createRandomCreateVirtualCardRequestProperties.BillingCountry,
                Email = createRandomCreateVirtualCardRequestProperties.Email,
                BillingName = createRandomCreateVirtualCardRequestProperties.BillingName,
                BillingPostalCode = createRandomCreateVirtualCardRequestProperties.BillingPostalCode,
                BillingState = createRandomCreateVirtualCardRequestProperties.BillingState,
                CallbackUrl = createRandomCreateVirtualCardRequestProperties.CallbackUrl,
                Currency = createRandomCreateVirtualCardRequestProperties.Currency,
                DateOfBirth = createRandomCreateVirtualCardRequestProperties.DateOfBirth,
                DebitCurrency = createRandomCreateVirtualCardRequestProperties.DebitCurrency,
                FirstName = createRandomCreateVirtualCardRequestProperties.FirstName,
                Gender = createRandomCreateVirtualCardRequestProperties.Gender,
                LastName = createRandomCreateVirtualCardRequestProperties.LastName,
                Phone = createRandomCreateVirtualCardRequestProperties.Phone,
                Title = createRandomCreateVirtualCardRequestProperties.Title,


            };

            var randomExternalCreateVirtualCardResponse = new ExternalCreateVirtualCardResponse
            {
                Data = new ExternalCreateVirtualCardResponse.ExternalCreateVirtualAccountData
                {
                    Address1 = createRandomCreateVirtualCardResponseProperties.Data.Address1,
                    Currency = createRandomCreateVirtualCardResponseProperties.Data.Currency,
                    AccountId = createRandomCreateVirtualCardResponseProperties.Data.AccountId,
                    Amount = createRandomCreateVirtualCardResponseProperties.Data.Amount,
                    Address2 = createRandomCreateVirtualCardResponseProperties.Data.Address2,
                    BinCheckName = createRandomCreateVirtualCardResponseProperties.Data.BinCheckName,
                    CallbackUrl = createRandomCreateVirtualCardResponseProperties.Data.CallbackUrl,
                    CardPan = createRandomCreateVirtualCardResponseProperties.Data.CardPan,
                    CardType = createRandomCreateVirtualCardResponseProperties.Data.CardType,
                    City = createRandomCreateVirtualCardResponseProperties.Data.City,
                    CreatedAt = createRandomCreateVirtualCardResponseProperties.Data.CreatedAt,
                    Cvv = createRandomCreateVirtualCardResponseProperties.Data.Cvv,
                    Expiration = createRandomCreateVirtualCardResponseProperties.Data.Expiration,
                    Id = createRandomCreateVirtualCardResponseProperties.Data.Id,
                    IsActive = createRandomCreateVirtualCardResponseProperties.Data.IsActive,
                    MaskedPan = createRandomCreateVirtualCardResponseProperties.Data.MaskedPan,
                    NameOnCard = createRandomCreateVirtualCardResponseProperties.Data.NameOnCard,
                    SendTo = createRandomCreateVirtualCardResponseProperties.Data.SendTo,
                    State = createRandomCreateVirtualCardResponseProperties.Data.State,
                    ZipCode = createRandomCreateVirtualCardResponseProperties.Data.ZipCode,

                },
                Message = createRandomCreateVirtualCardResponseProperties.Message,
                Status = createRandomCreateVirtualCardResponseProperties.Status,

            };


            var randomCreateVirtualCardRequest = new CreateVirtualCardRequest
            {
                Amount = createRandomCreateVirtualCardRequestProperties.Amount,
                BillingAddress = createRandomCreateVirtualCardRequestProperties.BillingAddress,
                BillingCity = createRandomCreateVirtualCardRequestProperties.BillingCity,
                BillingCountry = createRandomCreateVirtualCardRequestProperties.BillingCountry,
                Email = createRandomCreateVirtualCardRequestProperties.Email,
                BillingName = createRandomCreateVirtualCardRequestProperties.BillingName,
                BillingPostalCode = createRandomCreateVirtualCardRequestProperties.BillingPostalCode,
                BillingState = createRandomCreateVirtualCardRequestProperties.BillingState,
                CallbackUrl = createRandomCreateVirtualCardRequestProperties.CallbackUrl,
                Currency = createRandomCreateVirtualCardRequestProperties.Currency,
                DateOfBirth = createRandomCreateVirtualCardRequestProperties.DateOfBirth,
                DebitCurrency = createRandomCreateVirtualCardRequestProperties.DebitCurrency,
                FirstName = createRandomCreateVirtualCardRequestProperties.FirstName,
                Gender = createRandomCreateVirtualCardRequestProperties.Gender,
                LastName = createRandomCreateVirtualCardRequestProperties.LastName,
                Phone = createRandomCreateVirtualCardRequestProperties.Phone,
                Title = createRandomCreateVirtualCardRequestProperties.Title,

            };

            var randomCreateVirtualCardResponse = new CreateVirtualCardResponse
            {
                Data = new CreateVirtualCardResponse.CreateVirtualCardData
                {
                    Address1 = createRandomCreateVirtualCardResponseProperties.Data.Address1,
                    Currency = createRandomCreateVirtualCardResponseProperties.Data.Currency,
                    AccountId = createRandomCreateVirtualCardResponseProperties.Data.AccountId,
                    Amount = createRandomCreateVirtualCardResponseProperties.Data.Amount,
                    Address2 = createRandomCreateVirtualCardResponseProperties.Data.Address2,
                    BinCheckName = createRandomCreateVirtualCardResponseProperties.Data.BinCheckName,
                    CallbackUrl = createRandomCreateVirtualCardResponseProperties.Data.CallbackUrl,
                    CardPan = createRandomCreateVirtualCardResponseProperties.Data.CardPan,
                    CardType = createRandomCreateVirtualCardResponseProperties.Data.CardType,
                    City = createRandomCreateVirtualCardResponseProperties.Data.City,
                    CreatedAt = createRandomCreateVirtualCardResponseProperties.Data.CreatedAt,
                    Cvv = createRandomCreateVirtualCardResponseProperties.Data.Cvv,
                    Expiration = createRandomCreateVirtualCardResponseProperties.Data.Expiration,
                    Id = createRandomCreateVirtualCardResponseProperties.Data.Id,
                    IsActive = createRandomCreateVirtualCardResponseProperties.Data.IsActive,
                    MaskedPan = createRandomCreateVirtualCardResponseProperties.Data.MaskedPan,
                    NameOnCard = createRandomCreateVirtualCardResponseProperties.Data.NameOnCard,
                    SendTo = createRandomCreateVirtualCardResponseProperties.Data.SendTo,
                    State = createRandomCreateVirtualCardResponseProperties.Data.State,
                    ZipCode = createRandomCreateVirtualCardResponseProperties.Data.ZipCode,

                },
                Message = createRandomCreateVirtualCardResponseProperties.Message,
                Status = createRandomCreateVirtualCardResponseProperties.Status,

            };


            var randomCreateVirtualCard = new CreateVirtualCard
            {
                Request = randomCreateVirtualCardRequest,
            };

            CreateVirtualCard inputCreateVirtualCard = randomCreateVirtualCard;
            CreateVirtualCard expectedCreateVirtualCard = inputCreateVirtualCard.DeepClone();
            expectedCreateVirtualCard.Response = randomCreateVirtualCardResponse;

            ExternalCreateVirtualCardRequest mappedExternalCreateVirtualCardRequest =
               randomExternalCreateVirtualCardRequest;

            ExternalCreateVirtualCardResponse returnedExternalCreateVirtualCardResponse =
                randomExternalCreateVirtualCardResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateVirtualCardAsync(It.Is(
                      SameExternalCreateVirtualCardRequestAs(mappedExternalCreateVirtualCardRequest))))
                     .ReturnsAsync(returnedExternalCreateVirtualCardResponse);

            // when
            CreateVirtualCard actualCreateCreateVirtualCard =
               await this.virtualCardsService.PostCreateVirtualCardRequestAsync(inputCreateVirtualCard);

            // then
            actualCreateCreateVirtualCard.Should().BeEquivalentTo(expectedCreateVirtualCard);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreateVirtualCardAsync(It.Is(
                   SameExternalCreateVirtualCardRequestAs(mappedExternalCreateVirtualCardRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}