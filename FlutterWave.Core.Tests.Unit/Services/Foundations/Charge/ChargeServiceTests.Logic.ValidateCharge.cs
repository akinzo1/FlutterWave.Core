using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldPostValidateChargeWithValidateChargeRequestAsync()
        {
            // given 



            dynamic createRandomValidateChargeRequestProperties =
              CreateRandomValidateChargeRequestProperties();

            dynamic createRandomValidateChargeProperties =
                CreateRandomValidateChargeProperties();


            var randomExternalValidateChargeRequest = new ExternalValidateChargeRequest
            {
                FlwRef = createRandomValidateChargeRequestProperties.FlwRef,
                Otp = createRandomValidateChargeRequestProperties.Otp,
                Type = createRandomValidateChargeRequestProperties.Type,

            };

            var randomExternalValidateChargeResponse = new ExternalValidateChargeResponse
            {
                Data = new ExternalValidateChargeResponse.Datum
                {
                    TxRef = createRandomValidateChargeProperties.Data.TxRef,
                    Currency = createRandomValidateChargeProperties.Data.Currency,
                    AccountId = createRandomValidateChargeProperties.Data.AccountId,
                    Amount = createRandomValidateChargeProperties.Data.Amount,
                    AppFee = createRandomValidateChargeProperties.Data.AppFee,
                    AuthModel = createRandomValidateChargeProperties.Data.AuthModel,
                    AuthUrl = createRandomValidateChargeProperties.Data.AuthUrl,

                    Card = new ExternalValidateChargeResponse.Card
                    {
                        Country = createRandomValidateChargeProperties.Data.Card.Country,
                        Expiry = createRandomValidateChargeProperties.Data.Card.Expiry,
                        First6digits = createRandomValidateChargeProperties.Data.Card.First6digits,
                        Issuer = createRandomValidateChargeProperties.Data.Card.Issuer,
                        Last4digits = createRandomValidateChargeProperties.Data.Card.Last4digits,
                        Type = createRandomValidateChargeProperties.Data.Card.Type,
                    },
                    ChargedAmount = createRandomValidateChargeProperties.Data.ChargedAmount,
                    ChargeType = createRandomValidateChargeProperties.Data.ChargeType,
                    CreatedAt = createRandomValidateChargeProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomValidateChargeProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomValidateChargeProperties.Data.FlwRef,
                    FraudStatus = createRandomValidateChargeProperties.Data.FraudStatus,
                    Id = createRandomValidateChargeProperties.Data.Id,
                    Ip = createRandomValidateChargeProperties.Data.Ip,
                    MerchantFee = createRandomValidateChargeProperties.Data.MerchantFee,
                    Narration = createRandomValidateChargeProperties.Data.Narration,
                    PaymentType = createRandomValidateChargeProperties.Data.PaymentType,
                    ProcessorResponse = createRandomValidateChargeProperties.Data.ProcessorResponse,
                    Status = createRandomValidateChargeProperties.Data.Status,
                    Customer = new ExternalValidateChargeResponse.Customer
                    {
                        Id = createRandomValidateChargeProperties.Data.Customer.Id,
                        CreatedAt = createRandomValidateChargeProperties.Data.Customer.CreatedAt,
                        Email = createRandomValidateChargeProperties.Data.Customer.Email,
                        Name = createRandomValidateChargeProperties.Data.Customer.Name,
                        PhoneNumber = createRandomValidateChargeProperties.Data.Customer.PhoneNumber
                    }
                },

                Message = createRandomValidateChargeProperties.Message,
                Status = createRandomValidateChargeProperties.Status,

            };


            var randomValidateChargeRequest = new ValidateChargeRequest
            {
                FlwRef = createRandomValidateChargeRequestProperties.FlwRef,
                Otp = createRandomValidateChargeRequestProperties.Otp,
                Type = createRandomValidateChargeRequestProperties.Type,

            };

            var randomValidateChargeResponse = new ValidateChargeResponse
            {
                Data = new ValidateChargeResponse.Datum
                {
                    TxRef = createRandomValidateChargeProperties.Data.TxRef,
                    Currency = createRandomValidateChargeProperties.Data.Currency,
                    AccountId = createRandomValidateChargeProperties.Data.AccountId,
                    Amount = createRandomValidateChargeProperties.Data.Amount,
                    AppFee = createRandomValidateChargeProperties.Data.AppFee,
                    AuthModel = createRandomValidateChargeProperties.Data.AuthModel,
                    AuthUrl = createRandomValidateChargeProperties.Data.AuthUrl,
                    Card = new ValidateChargeResponse.Card
                    {
                        Country = createRandomValidateChargeProperties.Data.Card.Country,
                        Expiry = createRandomValidateChargeProperties.Data.Card.Expiry,
                        First6digits = createRandomValidateChargeProperties.Data.Card.First6digits,
                        Issuer = createRandomValidateChargeProperties.Data.Card.Issuer,
                        Last4digits = createRandomValidateChargeProperties.Data.Card.Last4digits,
                        Type = createRandomValidateChargeProperties.Data.Card.Type,
                    },
                    ChargedAmount = createRandomValidateChargeProperties.Data.ChargedAmount,
                    ChargeType = createRandomValidateChargeProperties.Data.ChargeType,
                    CreatedAt = createRandomValidateChargeProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomValidateChargeProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomValidateChargeProperties.Data.FlwRef,
                    FraudStatus = createRandomValidateChargeProperties.Data.FraudStatus,
                    Id = createRandomValidateChargeProperties.Data.Id,
                    Ip = createRandomValidateChargeProperties.Data.Ip,
                    MerchantFee = createRandomValidateChargeProperties.Data.MerchantFee,
                    Narration = createRandomValidateChargeProperties.Data.Narration,
                    PaymentType = createRandomValidateChargeProperties.Data.PaymentType,
                    ProcessorResponse = createRandomValidateChargeProperties.Data.ProcessorResponse,
                    Status = createRandomValidateChargeProperties.Data.Status,
                    Customer = new ValidateChargeResponse.Customer
                    {
                        Id = createRandomValidateChargeProperties.Data.Customer.Id,
                        CreatedAt = createRandomValidateChargeProperties.Data.Customer.CreatedAt,
                        Email = createRandomValidateChargeProperties.Data.Customer.Email,
                        Name = createRandomValidateChargeProperties.Data.Customer.Name,
                        PhoneNumber = createRandomValidateChargeProperties.Data.Customer.PhoneNumber
                    }
                },

                Message = createRandomValidateChargeProperties.Message,
                Status = createRandomValidateChargeProperties.Status,

            };


            var randomValidateCharge = new ValidateCharge
            {
                Request = randomValidateChargeRequest,
            };

            ValidateCharge inputValidateCharge = randomValidateCharge;
            ValidateCharge expectedValidateCharge = inputValidateCharge.DeepClone();
            expectedValidateCharge.Response = randomValidateChargeResponse;

            ExternalValidateChargeRequest mappedExternalValidateChargeRequest =
               randomExternalValidateChargeRequest;

            ExternalValidateChargeResponse returnedExternalValidateChargeResponse =
                randomExternalValidateChargeResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostValidateChargeAsync(It.Is(
                     SameExternalValidateChargeRequestAs(mappedExternalValidateChargeRequest))))
                     .ReturnsAsync(returnedExternalValidateChargeResponse);

            // when
            ValidateCharge actualCreateValidateCharge =
               await this.chargeService.PostValidateChargeRequestAsync(inputValidateCharge);

            // then
            actualCreateValidateCharge.Should().BeEquivalentTo(expectedValidateCharge);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostValidateChargeAsync(It.Is(
                   SameExternalValidateChargeRequestAs(mappedExternalValidateChargeRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}