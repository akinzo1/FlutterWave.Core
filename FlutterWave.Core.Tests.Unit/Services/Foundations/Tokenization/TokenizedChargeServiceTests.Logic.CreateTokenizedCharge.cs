



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Fact]
        public async Task ShouldPostCreateTokenizedChargeWithCreateTokenizedChargeRequestAsync()
        {
            // given 



            dynamic createRandomCreateTokenizedChargeRequestProperties =
              CreateRandomCreateTokenizedChargeRequestProperties();

            dynamic createRandomCreateTokenizedChargeResponseProperties =
                CreateRandomCreateTokenizedChargeResponseProperties();


            var randomExternalCreateTokenizedChargeRequest = new ExternalCreateTokenizedChargeRequest
            {
                Amount = createRandomCreateTokenizedChargeRequestProperties.Amount,
                Country = createRandomCreateTokenizedChargeRequestProperties.Country,
                Currency = createRandomCreateTokenizedChargeRequestProperties.Currency,
                Email = createRandomCreateTokenizedChargeRequestProperties.Email,
                FirstName = createRandomCreateTokenizedChargeRequestProperties.FirstName,
                Ip = createRandomCreateTokenizedChargeRequestProperties.Ip,
                LastName = createRandomCreateTokenizedChargeRequestProperties.LastName,
                Narration = createRandomCreateTokenizedChargeRequestProperties.Narration,
                Token = createRandomCreateTokenizedChargeRequestProperties.Token,
                TxRef = createRandomCreateTokenizedChargeRequestProperties.TxRef


            };

            var randomExternalCreateTokenizedChargeResponse = new ExternalCreateTokenizedChargeResponse
            {
                Data = new ExternalCreateTokenizedChargeResponse.ExternalCreateTokenizedChargeData
                {
                    TxRef = createRandomCreateTokenizedChargeResponseProperties.Data.TxRef,
                    Currency = createRandomCreateTokenizedChargeResponseProperties.Data.Currency,
                    AccountId = createRandomCreateTokenizedChargeResponseProperties.Data.AccountId,
                    Amount = createRandomCreateTokenizedChargeResponseProperties.Data.Amount,
                    Narration = createRandomCreateTokenizedChargeResponseProperties.Data.Narration,
                    Ip = createRandomCreateTokenizedChargeResponseProperties.Data.Ip,
                    AppFee = createRandomCreateTokenizedChargeResponseProperties.Data.AppFee,
                    AuthModel = createRandomCreateTokenizedChargeResponseProperties.Data.AuthModel,
                    ChargedAmount = createRandomCreateTokenizedChargeResponseProperties.Data.ChargedAmount,
                    CreatedAt = createRandomCreateTokenizedChargeResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomCreateTokenizedChargeResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomCreateTokenizedChargeResponseProperties.Data.FlwRef,
                    Id = createRandomCreateTokenizedChargeResponseProperties.Data.Id,
                    MerchantFee = createRandomCreateTokenizedChargeResponseProperties.Data.MerchantFee,
                    PaymentType = createRandomCreateTokenizedChargeResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomCreateTokenizedChargeResponseProperties.Data.ProcessorResponse,
                    RedirectUrl = createRandomCreateTokenizedChargeResponseProperties.Data.RedirectUrl,
                    Status = createRandomCreateTokenizedChargeResponseProperties.Data.Status,
                    Customer = new ExternalCreateTokenizedChargeResponse.Customer
                    {
                        Id = createRandomCreateTokenizedChargeResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomCreateTokenizedChargeResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomCreateTokenizedChargeResponseProperties.Data.Customer.Email,
                        Name = createRandomCreateTokenizedChargeResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomCreateTokenizedChargeResponseProperties.Data.Customer.PhoneNumber
                    },
                    Card = new ExternalCreateTokenizedChargeResponse.Card
                    {
                        Country = createRandomCreateTokenizedChargeResponseProperties.Data.Card.Country,
                        Expiry = createRandomCreateTokenizedChargeResponseProperties.Data.Card.Expiry,
                        First6digits = createRandomCreateTokenizedChargeResponseProperties.Data.Card.First6digits,
                        Issuer = createRandomCreateTokenizedChargeResponseProperties.Data.Card.Issuer,
                        Last4digits = createRandomCreateTokenizedChargeResponseProperties.Data.Card.Last4digits,
                        Token = createRandomCreateTokenizedChargeResponseProperties.Data.Card.Token,
                        Type = createRandomCreateTokenizedChargeResponseProperties.Data.Card.Type
                    }



                },
                Message = createRandomCreateTokenizedChargeResponseProperties.Message,
                Status = createRandomCreateTokenizedChargeResponseProperties.Status,

            };


            var randomCreateTokenizedChargeRequest = new CreateTokenizedChargeRequest
            {
                Amount = createRandomCreateTokenizedChargeRequestProperties.Amount,
                Country = createRandomCreateTokenizedChargeRequestProperties.Country,
                Currency = createRandomCreateTokenizedChargeRequestProperties.Currency,
                Email = createRandomCreateTokenizedChargeRequestProperties.Email,
                FirstName = createRandomCreateTokenizedChargeRequestProperties.FirstName,
                Ip = createRandomCreateTokenizedChargeRequestProperties.Ip,
                LastName = createRandomCreateTokenizedChargeRequestProperties.LastName,
                Narration = createRandomCreateTokenizedChargeRequestProperties.Narration,
                Token = createRandomCreateTokenizedChargeRequestProperties.Token,
                TxRef = createRandomCreateTokenizedChargeRequestProperties.TxRef

            };

            var randomCreateTokenizedChargeResponse = new CreateTokenizedChargeResponse
            {

                Data = new CreateTokenizedChargeResponse.CreateTokenizedChargeData
                {
                    TxRef = createRandomCreateTokenizedChargeResponseProperties.Data.TxRef,
                    Currency = createRandomCreateTokenizedChargeResponseProperties.Data.Currency,
                    AccountId = createRandomCreateTokenizedChargeResponseProperties.Data.AccountId,
                    Amount = createRandomCreateTokenizedChargeResponseProperties.Data.Amount,
                    Narration = createRandomCreateTokenizedChargeResponseProperties.Data.Narration,
                    Ip = createRandomCreateTokenizedChargeResponseProperties.Data.Ip,
                    AppFee = createRandomCreateTokenizedChargeResponseProperties.Data.AppFee,
                    AuthModel = createRandomCreateTokenizedChargeResponseProperties.Data.AuthModel,
                    ChargedAmount = createRandomCreateTokenizedChargeResponseProperties.Data.ChargedAmount,
                    CreatedAt = createRandomCreateTokenizedChargeResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomCreateTokenizedChargeResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomCreateTokenizedChargeResponseProperties.Data.FlwRef,
                    Id = createRandomCreateTokenizedChargeResponseProperties.Data.Id,
                    MerchantFee = createRandomCreateTokenizedChargeResponseProperties.Data.MerchantFee,
                    PaymentType = createRandomCreateTokenizedChargeResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomCreateTokenizedChargeResponseProperties.Data.ProcessorResponse,
                    RedirectUrl = createRandomCreateTokenizedChargeResponseProperties.Data.RedirectUrl,
                    Status = createRandomCreateTokenizedChargeResponseProperties.Data.Status,
                    Customer = new CreateTokenizedChargeResponse.Customer
                    {
                        Id = createRandomCreateTokenizedChargeResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomCreateTokenizedChargeResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomCreateTokenizedChargeResponseProperties.Data.Customer.Email,
                        Name = createRandomCreateTokenizedChargeResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomCreateTokenizedChargeResponseProperties.Data.Customer.PhoneNumber
                    },
                    Card = new CreateTokenizedChargeResponse.Card
                    {
                        Country = createRandomCreateTokenizedChargeResponseProperties.Data.Card.Country,
                        Expiry = createRandomCreateTokenizedChargeResponseProperties.Data.Card.Expiry,
                        First6digits = createRandomCreateTokenizedChargeResponseProperties.Data.Card.First6digits,
                        Issuer = createRandomCreateTokenizedChargeResponseProperties.Data.Card.Issuer,
                        Last4digits = createRandomCreateTokenizedChargeResponseProperties.Data.Card.Last4digits,
                        Token = createRandomCreateTokenizedChargeResponseProperties.Data.Card.Token,
                        Type = createRandomCreateTokenizedChargeResponseProperties.Data.Card.Type
                    }



                },
                Message = createRandomCreateTokenizedChargeResponseProperties.Message,
                Status = createRandomCreateTokenizedChargeResponseProperties.Status,

            };


            var randomCreateTokenizedCharge = new CreateTokenizedCharge
            {
                Request = randomCreateTokenizedChargeRequest,
            };

            CreateTokenizedCharge inputCreateTokenizedCharge = randomCreateTokenizedCharge;
            CreateTokenizedCharge expectedCreateTokenizedCharge = inputCreateTokenizedCharge.DeepClone();
            expectedCreateTokenizedCharge.Response = randomCreateTokenizedChargeResponse;

            ExternalCreateTokenizedChargeRequest mappedExternalCreateTokenizedChargeRequest =
               randomExternalCreateTokenizedChargeRequest;

            ExternalCreateTokenizedChargeResponse returnedExternalCreateTokenizedChargeResponse =
                randomExternalCreateTokenizedChargeResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateTokenizedChargeAsync(It.Is(
                      SameExternalCreateTokenizedChargeRequestAs(mappedExternalCreateTokenizedChargeRequest))))
                     .ReturnsAsync(returnedExternalCreateTokenizedChargeResponse);

            // when
            CreateTokenizedCharge actualCreateCreateTokenizedCharge =
               await this.tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(inputCreateTokenizedCharge);

            // then
            actualCreateCreateTokenizedCharge.Should().BeEquivalentTo(expectedCreateTokenizedCharge);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreateTokenizedChargeAsync(It.Is(
                   SameExternalCreateTokenizedChargeRequestAs(mappedExternalCreateTokenizedChargeRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}