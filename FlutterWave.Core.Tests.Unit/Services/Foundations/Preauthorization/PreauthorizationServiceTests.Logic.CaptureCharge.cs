



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldPostCaptureChargeWithRequestAsync()
        {
            // given 



            dynamic createRandomCaptureChargeRequestProperties =
              CreateRandomCaptureChargeRequestProperties();

            dynamic createRandomCaptureChargeResponseProperties =
                CreateRandomCaptureChargeResponseProperties();


            var randomExternalCaptureChargeRequest = new ExternalCaptureChargeRequest
            {
                Amount = createRandomCaptureChargeRequestProperties.Amount,



            };

            var randomExternalCaptureChargeResponse = new ExternalCaptureChargeResponse
            {
                Data = new ExternalCaptureChargeResponse.ExternalCaptureChargeData
                {
                    CreatedAt = createRandomCaptureChargeResponseProperties.Data.CreatedAt,
                    Amount = createRandomCaptureChargeResponseProperties.Data.Amount,
                    AccountId = createRandomCaptureChargeResponseProperties.Data.AccountId,
                    AppFee = createRandomCaptureChargeResponseProperties.Data.AppFee,
                    AuthModel = createRandomCaptureChargeResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomCaptureChargeResponseProperties.Data.AuthUrl,
                    Card = new ExternalCaptureChargeResponse.Card
                    {
                        Country = createRandomCaptureChargeResponseProperties.Data.Card.Country,
                        Expiry = createRandomCaptureChargeResponseProperties.Data.Card.Expiry,
                        First6digits = createRandomCaptureChargeResponseProperties.Data.Card.First6digits,
                        Issuer = createRandomCaptureChargeResponseProperties.Data.Card.Issuer,
                        Last4digits = createRandomCaptureChargeResponseProperties.Data.Card.Last4digits,
                        Type = createRandomCaptureChargeResponseProperties.Data.Card.Type,

                    },
                    ChargedAmount = createRandomCaptureChargeResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomCaptureChargeResponseProperties.Data.ChargeType,
                    Currency = createRandomCaptureChargeResponseProperties.Data.Currency,
                    DeviceFingerprint = createRandomCaptureChargeResponseProperties.Data.DeviceFingerprint,
                    Customer = new ExternalCaptureChargeResponse.Customer
                    {
                        CreatedAt = createRandomCaptureChargeResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomCaptureChargeResponseProperties.Data.Customer.Email,
                        Id = createRandomCaptureChargeResponseProperties.Data.Customer.Id,
                        Name = createRandomCaptureChargeResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomCaptureChargeResponseProperties.Data.Customer.PhoneNumber,


                    },
                    Id = createRandomCaptureChargeResponseProperties.Data.Id,
                    FlwRef = createRandomCaptureChargeResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomCaptureChargeResponseProperties.Data.FraudStatus,
                    Ip = createRandomCaptureChargeResponseProperties.Data.Ip,
                    MerchantFee = createRandomCaptureChargeResponseProperties.Data.MerchantFee,
                    Narration = createRandomCaptureChargeResponseProperties.Data.Narration,
                    PaymentType = createRandomCaptureChargeResponseProperties.Data.PaymentType,
                    Plan = createRandomCaptureChargeResponseProperties.Data.Plan,
                    ProcessorResponse = createRandomCaptureChargeResponseProperties.Data.ProcessorResponse,
                    Status = createRandomCaptureChargeResponseProperties.Data.Status,
                    TxRef = createRandomCaptureChargeResponseProperties.Data.TxRef





                },
                Message = createRandomCaptureChargeResponseProperties.Message,
                Status = createRandomCaptureChargeResponseProperties.Status,

            };


            var randomCaptureChargeRequest = new CaptureChargeRequest
            {
                Amount = createRandomCaptureChargeRequestProperties.Amount,

            };

            var randomCaptureChargeResponse = new CaptureChargeResponse
            {

                Data = new CaptureChargeResponse.CaptureChargeData
                {
                    CreatedAt = createRandomCaptureChargeResponseProperties.Data.CreatedAt,
                    Amount = createRandomCaptureChargeResponseProperties.Data.Amount,
                    AccountId = createRandomCaptureChargeResponseProperties.Data.AccountId,
                    AppFee = createRandomCaptureChargeResponseProperties.Data.AppFee,
                    AuthModel = createRandomCaptureChargeResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomCaptureChargeResponseProperties.Data.AuthUrl,
                    Card = new CaptureChargeResponse.Card
                    {
                        Country = createRandomCaptureChargeResponseProperties.Data.Card.Country,
                        Expiry = createRandomCaptureChargeResponseProperties.Data.Card.Expiry,
                        First6digits = createRandomCaptureChargeResponseProperties.Data.Card.First6digits,
                        Issuer = createRandomCaptureChargeResponseProperties.Data.Card.Issuer,
                        Last4digits = createRandomCaptureChargeResponseProperties.Data.Card.Last4digits,
                        Type = createRandomCaptureChargeResponseProperties.Data.Card.Type,

                    },
                    ChargedAmount = createRandomCaptureChargeResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomCaptureChargeResponseProperties.Data.ChargeType,
                    Currency = createRandomCaptureChargeResponseProperties.Data.Currency,
                    DeviceFingerprint = createRandomCaptureChargeResponseProperties.Data.DeviceFingerprint,
                    Customer = new CaptureChargeResponse.Customer
                    {
                        CreatedAt = createRandomCaptureChargeResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomCaptureChargeResponseProperties.Data.Customer.Email,
                        Id = createRandomCaptureChargeResponseProperties.Data.Customer.Id,
                        Name = createRandomCaptureChargeResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomCaptureChargeResponseProperties.Data.Customer.PhoneNumber,


                    },
                    Id = createRandomCaptureChargeResponseProperties.Data.Id,
                    FlwRef = createRandomCaptureChargeResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomCaptureChargeResponseProperties.Data.FraudStatus,
                    Ip = createRandomCaptureChargeResponseProperties.Data.Ip,
                    MerchantFee = createRandomCaptureChargeResponseProperties.Data.MerchantFee,
                    Narration = createRandomCaptureChargeResponseProperties.Data.Narration,
                    PaymentType = createRandomCaptureChargeResponseProperties.Data.PaymentType,
                    Plan = createRandomCaptureChargeResponseProperties.Data.Plan,
                    ProcessorResponse = createRandomCaptureChargeResponseProperties.Data.ProcessorResponse,
                    Status = createRandomCaptureChargeResponseProperties.Data.Status,
                    TxRef = createRandomCaptureChargeResponseProperties.Data.TxRef




                },
                Message = createRandomCaptureChargeResponseProperties.Message,
                Status = createRandomCaptureChargeResponseProperties.Status,
            };


            var randomCaptureCharge = new CaptureCharge
            {
                Request = randomCaptureChargeRequest,
            };

            var randomFlwRef = GetRandomString();

            CaptureCharge inputCaptureCharge = randomCaptureCharge;
            CaptureCharge expectedCaptureCharge = inputCaptureCharge.DeepClone();
            expectedCaptureCharge.Response = randomCaptureChargeResponse;

            ExternalCaptureChargeRequest mappedExternalCaptureChargeRequest =
               randomExternalCaptureChargeRequest;

            ExternalCaptureChargeResponse returnedExternalCaptureChargeResponse =
                randomExternalCaptureChargeResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCaptureChargeAsync(It.IsAny<string>(), It.Is(
                      SameExternalCaptureChargeRequestAs(mappedExternalCaptureChargeRequest))))
                     .ReturnsAsync(returnedExternalCaptureChargeResponse);

            // when
            CaptureCharge actualCreateCaptureCharge =
               await this.preauthorizationService.PostCaptureChargeRequestAsync(randomFlwRef, inputCaptureCharge);

            // then
            actualCreateCaptureCharge.Should().BeEquivalentTo(expectedCaptureCharge);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCaptureChargeAsync(It.IsAny<string>(), It.Is(
                   SameExternalCaptureChargeRequestAs(mappedExternalCaptureChargeRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}