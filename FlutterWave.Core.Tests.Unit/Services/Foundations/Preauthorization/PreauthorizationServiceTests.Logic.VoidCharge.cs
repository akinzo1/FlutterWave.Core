



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldPostVoidChargeAsync()
        {
            // given 
            dynamic createRandomVoidChargeResponseProperties =
                 CreateRandomVoidChargeResponseProperties();

            var randomFlwRef = GetRandomString();

            var randomExternalVoidChargeResponse = new ExternalVoidChargeResponse
            {
                Message = createRandomVoidChargeResponseProperties.Message,
                Status = createRandomVoidChargeResponseProperties.Status,
                Data = new ExternalVoidChargeResponse.ExternalVoidChargeData
                {
                    CreatedAt = createRandomVoidChargeResponseProperties.Data.CreatedAt,
                    Amount = createRandomVoidChargeResponseProperties.Data.Amount,
                    AccountId = createRandomVoidChargeResponseProperties.Data.AccountId,
                    AppFee = createRandomVoidChargeResponseProperties.Data.AppFee,
                    AuthModel = createRandomVoidChargeResponseProperties.Data.AuthModel,
                    OrderId = createRandomVoidChargeResponseProperties.Data.OrderId,
                    Card = new ExternalVoidChargeResponse.Card
                    {
                        Country = createRandomVoidChargeResponseProperties.Data.Card.Country,
                        Expiry = createRandomVoidChargeResponseProperties.Data.Card.Expiry,
                        First6digits = createRandomVoidChargeResponseProperties.Data.Card.First6digits,
                        Issuer = createRandomVoidChargeResponseProperties.Data.Card.Issuer,
                        Last4digits = createRandomVoidChargeResponseProperties.Data.Card.Last4digits,
                        Type = createRandomVoidChargeResponseProperties.Data.Card.Type,
                    },
                    ChargedAmount = createRandomVoidChargeResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomVoidChargeResponseProperties.Data.ChargeType,
                    Currency = createRandomVoidChargeResponseProperties.Data.Currency,
                    DeviceFingerprint = createRandomVoidChargeResponseProperties.Data.DeviceFingerprint,
                    Customer = new ExternalVoidChargeResponse.Customer
                    {
                        CreatedAt = createRandomVoidChargeResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomVoidChargeResponseProperties.Data.Customer.Email,
                        Id = createRandomVoidChargeResponseProperties.Data.Customer.Id,
                        Name = createRandomVoidChargeResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomVoidChargeResponseProperties.Data.Customer.PhoneNumber,


                    },
                    Id = createRandomVoidChargeResponseProperties.Data.Id,
                    FlwRef = createRandomVoidChargeResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomVoidChargeResponseProperties.Data.FraudStatus,
                    Ip = createRandomVoidChargeResponseProperties.Data.Ip,
                    MerchantFee = createRandomVoidChargeResponseProperties.Data.MerchantFee,
                    Narration = createRandomVoidChargeResponseProperties.Data.Narration,
                    PaymentType = createRandomVoidChargeResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomVoidChargeResponseProperties.Data.ProcessorResponse,
                    Status = createRandomVoidChargeResponseProperties.Data.Status,
                    TxRef = createRandomVoidChargeResponseProperties.Data.TxRef
                },




            };

            var randomExpectedVoidChargeResponse = new VoidChargeResponse
            {
                Message = createRandomVoidChargeResponseProperties.Message,
                Status = createRandomVoidChargeResponseProperties.Status,
                Data = new VoidChargeResponse.VoidChargeData
                {
                    CreatedAt = createRandomVoidChargeResponseProperties.Data.CreatedAt,
                    Amount = createRandomVoidChargeResponseProperties.Data.Amount,
                    AccountId = createRandomVoidChargeResponseProperties.Data.AccountId,
                    AppFee = createRandomVoidChargeResponseProperties.Data.AppFee,
                    AuthModel = createRandomVoidChargeResponseProperties.Data.AuthModel,
                    OrderId = createRandomVoidChargeResponseProperties.Data.OrderId,
                    Card = new VoidChargeResponse.Card
                    {
                        Country = createRandomVoidChargeResponseProperties.Data.Card.Country,
                        Expiry = createRandomVoidChargeResponseProperties.Data.Card.Expiry,
                        First6digits = createRandomVoidChargeResponseProperties.Data.Card.First6digits,
                        Issuer = createRandomVoidChargeResponseProperties.Data.Card.Issuer,
                        Last4digits = createRandomVoidChargeResponseProperties.Data.Card.Last4digits,
                        Type = createRandomVoidChargeResponseProperties.Data.Card.Type,
                    },
                    ChargedAmount = createRandomVoidChargeResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomVoidChargeResponseProperties.Data.ChargeType,
                    Currency = createRandomVoidChargeResponseProperties.Data.Currency,
                    DeviceFingerprint = createRandomVoidChargeResponseProperties.Data.DeviceFingerprint,
                    Customer = new VoidChargeResponse.Customer
                    {
                        CreatedAt = createRandomVoidChargeResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomVoidChargeResponseProperties.Data.Customer.Email,
                        Id = createRandomVoidChargeResponseProperties.Data.Customer.Id,
                        Name = createRandomVoidChargeResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomVoidChargeResponseProperties.Data.Customer.PhoneNumber,


                    },
                    Id = createRandomVoidChargeResponseProperties.Data.Id,
                    FlwRef = createRandomVoidChargeResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomVoidChargeResponseProperties.Data.FraudStatus,
                    Ip = createRandomVoidChargeResponseProperties.Data.Ip,
                    MerchantFee = createRandomVoidChargeResponseProperties.Data.MerchantFee,
                    Narration = createRandomVoidChargeResponseProperties.Data.Narration,
                    PaymentType = createRandomVoidChargeResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomVoidChargeResponseProperties.Data.ProcessorResponse,
                    Status = createRandomVoidChargeResponseProperties.Data.Status,
                    TxRef = createRandomVoidChargeResponseProperties.Data.TxRef
                },

            };


            var expectedInputRetrieveVoidCharge = new VoidCharge
            {
                Response = randomExpectedVoidChargeResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVoidChargeAsync(randomFlwRef))
                    .ReturnsAsync(randomExternalVoidChargeResponse);

            // when
            VoidCharge actualRetrieveVoidCharge =
                await this.preauthorizationService.PostVoidChargeRequestAsync(randomFlwRef);

            // then
            actualRetrieveVoidCharge.Should().BeEquivalentTo(expectedInputRetrieveVoidCharge);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVoidChargeAsync(randomFlwRef),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}