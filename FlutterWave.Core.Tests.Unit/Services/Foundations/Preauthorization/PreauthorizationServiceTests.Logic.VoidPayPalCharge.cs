



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldPostVoidPayPalChargeAsync()
        {
            // given 
            dynamic createRandomVoidPayPalChargeResponseProperties =
                 CreateRandomVoidPayPalChargeResponseProperties();

            var randomFlwRef = GetRandomString();

            var randomExternalVoidPayPalChargeResponse = new ExternalVoidPayPalChargeResponse
            {
                Message = createRandomVoidPayPalChargeResponseProperties.Message,
                Status = createRandomVoidPayPalChargeResponseProperties.Status,
                Data = new ExternalVoidPayPalChargeResponse.ExternalVoidPaypalChargeData
                {
                    CreatedAt = createRandomVoidPayPalChargeResponseProperties.Data.CreatedAt,
                    Amount = createRandomVoidPayPalChargeResponseProperties.Data.Amount,
                    AccountId = createRandomVoidPayPalChargeResponseProperties.Data.AccountId,
                    AppFee = createRandomVoidPayPalChargeResponseProperties.Data.AppFee,
                    AuthModel = createRandomVoidPayPalChargeResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomVoidPayPalChargeResponseProperties.Data.AuthUrl,
                    ChargedAmount = createRandomVoidPayPalChargeResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomVoidPayPalChargeResponseProperties.Data.ChargeType,
                    Currency = createRandomVoidPayPalChargeResponseProperties.Data.Currency,
                    DeviceFingerprint = createRandomVoidPayPalChargeResponseProperties.Data.DeviceFingerprint,
                    Customer = new ExternalVoidPayPalChargeResponse.Customer
                    {
                        CreatedAt = createRandomVoidPayPalChargeResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomVoidPayPalChargeResponseProperties.Data.Customer.Email,
                        Id = createRandomVoidPayPalChargeResponseProperties.Data.Customer.Id,
                        Name = createRandomVoidPayPalChargeResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomVoidPayPalChargeResponseProperties.Data.Customer.PhoneNumber,


                    },
                    Id = createRandomVoidPayPalChargeResponseProperties.Data.Id,
                    FlwRef = createRandomVoidPayPalChargeResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomVoidPayPalChargeResponseProperties.Data.FraudStatus,
                    Ip = createRandomVoidPayPalChargeResponseProperties.Data.Ip,
                    MerchantFee = createRandomVoidPayPalChargeResponseProperties.Data.MerchantFee,
                    Narration = createRandomVoidPayPalChargeResponseProperties.Data.Narration,
                    PaymentType = createRandomVoidPayPalChargeResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomVoidPayPalChargeResponseProperties.Data.ProcessorResponse,
                    Status = createRandomVoidPayPalChargeResponseProperties.Data.Status,
                    TxRef = createRandomVoidPayPalChargeResponseProperties.Data.TxRef


                }

            };

            var randomExpectedVoidPayPalChargeResponse = new VoidPayPalChargeResponse
            {
                Message = createRandomVoidPayPalChargeResponseProperties.Message,
                Status = createRandomVoidPayPalChargeResponseProperties.Status,
                Data = new VoidPayPalChargeResponse.VoidPaypalChargeData
                {
                    CreatedAt = createRandomVoidPayPalChargeResponseProperties.Data.CreatedAt,
                    Amount = createRandomVoidPayPalChargeResponseProperties.Data.Amount,
                    AccountId = createRandomVoidPayPalChargeResponseProperties.Data.AccountId,
                    AppFee = createRandomVoidPayPalChargeResponseProperties.Data.AppFee,
                    AuthModel = createRandomVoidPayPalChargeResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomVoidPayPalChargeResponseProperties.Data.AuthUrl,
                    ChargedAmount = createRandomVoidPayPalChargeResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomVoidPayPalChargeResponseProperties.Data.ChargeType,
                    Currency = createRandomVoidPayPalChargeResponseProperties.Data.Currency,
                    DeviceFingerprint = createRandomVoidPayPalChargeResponseProperties.Data.DeviceFingerprint,
                    Customer = new VoidPayPalChargeResponse.Customer
                    {
                        CreatedAt = createRandomVoidPayPalChargeResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomVoidPayPalChargeResponseProperties.Data.Customer.Email,
                        Id = createRandomVoidPayPalChargeResponseProperties.Data.Customer.Id,
                        Name = createRandomVoidPayPalChargeResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomVoidPayPalChargeResponseProperties.Data.Customer.PhoneNumber,


                    },
                    Id = createRandomVoidPayPalChargeResponseProperties.Data.Id,
                    FlwRef = createRandomVoidPayPalChargeResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomVoidPayPalChargeResponseProperties.Data.FraudStatus,
                    Ip = createRandomVoidPayPalChargeResponseProperties.Data.Ip,
                    MerchantFee = createRandomVoidPayPalChargeResponseProperties.Data.MerchantFee,
                    Narration = createRandomVoidPayPalChargeResponseProperties.Data.Narration,
                    PaymentType = createRandomVoidPayPalChargeResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomVoidPayPalChargeResponseProperties.Data.ProcessorResponse,
                    Status = createRandomVoidPayPalChargeResponseProperties.Data.Status,
                    TxRef = createRandomVoidPayPalChargeResponseProperties.Data.TxRef
                },

            };


            var expectedInputRetrieveVoidPayPalCharge = new VoidPayPalCharge
            {
                Response = randomExpectedVoidPayPalChargeResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVoidPayPalChargeAsync(randomFlwRef))
                    .ReturnsAsync(randomExternalVoidPayPalChargeResponse);

            // when
            VoidPayPalCharge actualRetrieveVoidPayPalCharge =
                await this.preauthorizationService.PostVoidPayPalChargeRequestAsync(randomFlwRef);

            // then
            actualRetrieveVoidPayPalCharge.Should().BeEquivalentTo(expectedInputRetrieveVoidPayPalCharge);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVoidPayPalChargeAsync(randomFlwRef),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}