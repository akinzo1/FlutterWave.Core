



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
        public async Task ShouldPostCapturePayPalChargeWithRequestAsync()
        {
            // given 



            dynamic createRandomCapturePayPalChargeRequestProperties =
              CreateRandomCapturePayPalChargeRequestProperties();

            dynamic createRandomCapturePayPalChargeResponseProperties =
                CreateRandomCapturePayPalChargeResponseProperties();


            var randomExternalCapturePayPalChargeRequest = new ExternalCapturePayPalChargeRequest
            {
                FlwRef = createRandomCapturePayPalChargeRequestProperties.FlwRef,



            };

            var randomExternalCapturePaypalChargeResponse = new ExternalCapturePayPalChargeResponse
            {
                Data = new ExternalCapturePayPalChargeResponse.ExternalCapturePaypalChargeData
                {
                    TxRef = createRandomCapturePayPalChargeResponseProperties.Data.TxRef,
                    Id = createRandomCapturePayPalChargeResponseProperties.Data.Id,
                    FlwRef = createRandomCapturePayPalChargeResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomCapturePayPalChargeResponseProperties.Data.FraudStatus,
                    Ip = createRandomCapturePayPalChargeResponseProperties.Data.Ip,
                    MerchantFee = createRandomCapturePayPalChargeResponseProperties.Data.MerchantFee,
                    Narration = createRandomCapturePayPalChargeResponseProperties.Data.Narration,
                    PaymentType = createRandomCapturePayPalChargeResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomCapturePayPalChargeResponseProperties.Data.ProcessorResponse,
                    Status = createRandomCapturePayPalChargeResponseProperties.Data.Status,
                    CreatedAt = createRandomCapturePayPalChargeResponseProperties.Data.CreatedAt,
                    Amount = createRandomCapturePayPalChargeResponseProperties.Data.Amount,
                    AccountId = createRandomCapturePayPalChargeResponseProperties.Data.AccountId,
                    AppFee = createRandomCapturePayPalChargeResponseProperties.Data.AppFee,
                    AuthModel = createRandomCapturePayPalChargeResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomCapturePayPalChargeResponseProperties.Data.AuthUrl,
                    ChargedAmount = createRandomCapturePayPalChargeResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomCapturePayPalChargeResponseProperties.Data.ChargeType,
                    Currency = createRandomCapturePayPalChargeResponseProperties.Data.Currency,
                    DeviceFingerprint = createRandomCapturePayPalChargeResponseProperties.Data.DeviceFingerprint,
                    Customer = new ExternalCapturePayPalChargeResponse.Customer
                    {
                        CreatedAt = createRandomCapturePayPalChargeResponseProperties.Data.Customer.CreatedAt,
                        Id = createRandomCapturePayPalChargeResponseProperties.Data.Customer.Id,
                        Name = createRandomCapturePayPalChargeResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomCapturePayPalChargeResponseProperties.Data.Customer.PhoneNumber,
                        Email = createRandomCapturePayPalChargeResponseProperties.Data.Customer.Email

                    },





                },
                Message = createRandomCapturePayPalChargeResponseProperties.Message,
                Status = createRandomCapturePayPalChargeResponseProperties.Status,

            };


            var randomCapturePayPalChargeRequest = new CapturePayPalChargeRequest
            {
                FlwRef = createRandomCapturePayPalChargeRequestProperties.FlwRef,

            };

            var randomCapturePayPalChargeResponse = new CapturePaypalChargeResponse
            {

                Data = new CapturePaypalChargeResponse.CapturePaypalChargeData
                {
                    TxRef = createRandomCapturePayPalChargeResponseProperties.Data.TxRef,
                    Id = createRandomCapturePayPalChargeResponseProperties.Data.Id,
                    FlwRef = createRandomCapturePayPalChargeResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomCapturePayPalChargeResponseProperties.Data.FraudStatus,
                    Ip = createRandomCapturePayPalChargeResponseProperties.Data.Ip,
                    MerchantFee = createRandomCapturePayPalChargeResponseProperties.Data.MerchantFee,
                    Narration = createRandomCapturePayPalChargeResponseProperties.Data.Narration,
                    PaymentType = createRandomCapturePayPalChargeResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomCapturePayPalChargeResponseProperties.Data.ProcessorResponse,
                    Status = createRandomCapturePayPalChargeResponseProperties.Data.Status,
                    CreatedAt = createRandomCapturePayPalChargeResponseProperties.Data.CreatedAt,
                    Amount = createRandomCapturePayPalChargeResponseProperties.Data.Amount,
                    AccountId = createRandomCapturePayPalChargeResponseProperties.Data.AccountId,
                    AppFee = createRandomCapturePayPalChargeResponseProperties.Data.AppFee,
                    AuthModel = createRandomCapturePayPalChargeResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomCapturePayPalChargeResponseProperties.Data.AuthUrl,
                    ChargedAmount = createRandomCapturePayPalChargeResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomCapturePayPalChargeResponseProperties.Data.ChargeType,
                    Currency = createRandomCapturePayPalChargeResponseProperties.Data.Currency,
                    DeviceFingerprint = createRandomCapturePayPalChargeResponseProperties.Data.DeviceFingerprint,
                    Customer = new CapturePaypalChargeResponse.Customer
                    {
                        CreatedAt = createRandomCapturePayPalChargeResponseProperties.Data.Customer.CreatedAt,
                        Id = createRandomCapturePayPalChargeResponseProperties.Data.Customer.Id,
                        Name = createRandomCapturePayPalChargeResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomCapturePayPalChargeResponseProperties.Data.Customer.PhoneNumber,
                        Email = createRandomCapturePayPalChargeResponseProperties.Data.Customer.Email

                    },





                },
                Message = createRandomCapturePayPalChargeResponseProperties.Message,
                Status = createRandomCapturePayPalChargeResponseProperties.Status,
            };


            var randomCapturePayPalCharge = new CapturePayPalCharge
            {
                Request = randomCapturePayPalChargeRequest,
            };

            var randomFlwRef = GetRandomString();

            CapturePayPalCharge inputCapturePayPalCharge = randomCapturePayPalCharge;
            CapturePayPalCharge expectedCapturePayPalCharge = inputCapturePayPalCharge.DeepClone();
            expectedCapturePayPalCharge.Response = randomCapturePayPalChargeResponse;

            ExternalCapturePayPalChargeRequest mappedExternalCapturePayPalChargeRequest =
               randomExternalCapturePayPalChargeRequest;

            ExternalCapturePayPalChargeResponse returnedExternalCapturePaypalChargeResponse =
                randomExternalCapturePaypalChargeResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCapturePayPalChargeAsync(It.Is(
                      SameExternalCapturePaypalChargeRequestAs(mappedExternalCapturePayPalChargeRequest))))
                     .ReturnsAsync(returnedExternalCapturePaypalChargeResponse);

            // when
            CapturePayPalCharge actualCreateCapturePayPalCharge =
               await this.preauthorizationService.PostCapturePayPalChargeRequestAsync(inputCapturePayPalCharge);

            // then
            actualCreateCapturePayPalCharge.Should().BeEquivalentTo(expectedCapturePayPalCharge);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCapturePayPalChargeAsync(It.Is(
                   SameExternalCapturePaypalChargeRequestAs(mappedExternalCapturePayPalChargeRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}