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
        public async Task ShouldPostCardChargeWithCardChargeRequestAsync()
        {
            // given 



            dynamic createRandomCardChargeRequestProperties =
              CreateRandomCardChargeRequestProperties();

            dynamic createRandomEncryptedChargeRequestProperties =
              CreateRandomEncryptedChargeRequestProperties();

            dynamic createRandomCardChargeResponseProperties =
                CreateRandomCardChargeResponseProperties();

            var randomExternalEncryptedChargeRequest = new ExternalEncryptedChargeRequest
            {
                Client = createRandomEncryptedChargeRequestProperties.Client,
            };

            var randomExternalCardChargeRequest = new ExternalCardChargeRequest
            {
                Amount = createRandomCardChargeRequestProperties.Amount,
                Currency = createRandomCardChargeRequestProperties.Currency,
                Email = createRandomCardChargeRequestProperties.Email,
                CardNumber = createRandomCardChargeRequestProperties.CardNumber,
                ClientIp = createRandomCardChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCardChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCardChargeRequestProperties.PaymentPlan,
                Authorization = new ExternalCardChargeRequest.ExternalAuthorizationData
                {
                    Address = createRandomCardChargeRequestProperties.Authorization.Address,
                    City = createRandomCardChargeRequestProperties.Authorization.City,
                    Country = createRandomCardChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCardChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCardChargeRequestProperties.Authorization.Pin,
                    State = createRandomCardChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCardChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCardChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCardChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCardChargeRequestProperties.ExpiryYear,
                FullName = createRandomCardChargeRequestProperties.FullName,
                Meta = new ExternalCardChargeRequest.ExternalMeta
                {
                    SideNote = createRandomCardChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCardChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCardChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCardChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCardChargeRequestProperties.TxRef





            };

            var randomExternalCardChargeResponse = new ExternalCardChargeResponse
            {
                Data = new ExternalCardChargeResponse.ExternalCardChargeData
                {
                    TxRef = createRandomCardChargeResponseProperties.Data.TxRef,
                    Currency = createRandomCardChargeResponseProperties.Data.Currency,
                    AccountId = createRandomCardChargeResponseProperties.Data.AccountId,
                    Amount = createRandomCardChargeResponseProperties.Data.Amount,
                    AppFee = createRandomCardChargeResponseProperties.Data.AppFee,
                    AuthModel = createRandomCardChargeResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomCardChargeResponseProperties.Data.AuthUrl,

                    Card = new ExternalCardChargeResponse.Card
                    {
                        Country = createRandomCardChargeResponseProperties.Data.Card.Country,
                        Expiry = createRandomCardChargeResponseProperties.Data.Card.Expiry,
                        First6digits = createRandomCardChargeResponseProperties.Data.Card.First6digits,
                        Issuer = createRandomCardChargeResponseProperties.Data.Card.Issuer,
                        Last4digits = createRandomCardChargeResponseProperties.Data.Card.Last4digits,
                        Type = createRandomCardChargeResponseProperties.Data.Card.Type,

                    },
                    ChargedAmount = createRandomCardChargeResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomCardChargeResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomCardChargeResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomCardChargeResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomCardChargeResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomCardChargeResponseProperties.Data.FraudStatus,
                    Id = createRandomCardChargeResponseProperties.Data.Id,
                    Ip = createRandomCardChargeResponseProperties.Data.Ip,
                    MerchantFee = createRandomCardChargeResponseProperties.Data.MerchantFee,
                    Narration = createRandomCardChargeResponseProperties.Data.Narration,
                    PaymentType = createRandomCardChargeResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomCardChargeResponseProperties.Data.ProcessorResponse,
                    Status = createRandomCardChargeResponseProperties.Data.Status,

                    Customer = new ExternalCardChargeResponse.Customer
                    {
                        Id = createRandomCardChargeResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomCardChargeResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomCardChargeResponseProperties.Data.Customer.Email,
                        Name = createRandomCardChargeResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomCardChargeResponseProperties.Data.Customer.PhoneNumber,


                    }
                },
                Meta = new ExternalCardChargeResponse.ExternalCardChargeMeta
                {
                    Authorization = new ExternalCardChargeResponse.Authorization
                    {
                        Endpoint = createRandomCardChargeResponseProperties.Meta.Authorization.Endpoint,
                        Mode = createRandomCardChargeResponseProperties.Meta.Authorization.Mode

                    }
                },
                Message = createRandomCardChargeResponseProperties.Message,
                Status = createRandomCardChargeResponseProperties.Status,

            };

            var randomEncryptedChargeRequest = new EncryptedChargeRequest
            {
                Client = createRandomEncryptedChargeRequestProperties.Client,
            };

            var randomCardChargeRequest = new CardChargeRequest
            {
                Amount = createRandomCardChargeRequestProperties.Amount,
                Currency = createRandomCardChargeRequestProperties.Currency,
                Email = createRandomCardChargeRequestProperties.Email,
                CardNumber = createRandomCardChargeRequestProperties.CardNumber,
                ClientIp = createRandomCardChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCardChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCardChargeRequestProperties.PaymentPlan,
                Authorization = new CardChargeRequest.AuthorizationData
                {
                    Address = createRandomCardChargeRequestProperties.Authorization.Address,
                    City = createRandomCardChargeRequestProperties.Authorization.City,
                    Country = createRandomCardChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCardChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCardChargeRequestProperties.Authorization.Pin,
                    State = createRandomCardChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCardChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCardChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCardChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCardChargeRequestProperties.ExpiryYear,
                FullName = createRandomCardChargeRequestProperties.FullName,
                Meta = new CardChargeRequest.CardMeta
                {
                    SideNote = createRandomCardChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCardChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCardChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCardChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCardChargeRequestProperties.TxRef



            };

            var randomCardChargeResponse = new CardChargeResponse
            {
                Data = new CardChargeResponse.CardChargeData
                {
                    TxRef = createRandomCardChargeResponseProperties.Data.TxRef,
                    Currency = createRandomCardChargeResponseProperties.Data.Currency,
                    AccountId = createRandomCardChargeResponseProperties.Data.AccountId,
                    Amount = createRandomCardChargeResponseProperties.Data.Amount,
                    AppFee = createRandomCardChargeResponseProperties.Data.AppFee,
                    AuthModel = createRandomCardChargeResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomCardChargeResponseProperties.Data.AuthUrl,

                    Card = new CardChargeResponse.Card
                    {
                        Country = createRandomCardChargeResponseProperties.Data.Card.Country,
                        Expiry = createRandomCardChargeResponseProperties.Data.Card.Expiry,
                        First6digits = createRandomCardChargeResponseProperties.Data.Card.First6digits,
                        Issuer = createRandomCardChargeResponseProperties.Data.Card.Issuer,
                        Last4digits = createRandomCardChargeResponseProperties.Data.Card.Last4digits,
                        Type = createRandomCardChargeResponseProperties.Data.Card.Type,

                    },
                    ChargedAmount = createRandomCardChargeResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomCardChargeResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomCardChargeResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomCardChargeResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomCardChargeResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomCardChargeResponseProperties.Data.FraudStatus,
                    Id = createRandomCardChargeResponseProperties.Data.Id,
                    Ip = createRandomCardChargeResponseProperties.Data.Ip,
                    MerchantFee = createRandomCardChargeResponseProperties.Data.MerchantFee,
                    Narration = createRandomCardChargeResponseProperties.Data.Narration,
                    PaymentType = createRandomCardChargeResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomCardChargeResponseProperties.Data.ProcessorResponse,
                    Status = createRandomCardChargeResponseProperties.Data.Status,

                    Customer = new CardChargeResponse.Customer
                    {
                        Id = createRandomCardChargeResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomCardChargeResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomCardChargeResponseProperties.Data.Customer.Email,
                        Name = createRandomCardChargeResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomCardChargeResponseProperties.Data.Customer.PhoneNumber,

                    }
                },
                Meta = new CardChargeResponse.CardChargeMeta
                {
                    Authorization = new CardChargeResponse.Authorization
                    {
                        Endpoint = createRandomCardChargeResponseProperties.Meta.Authorization.Endpoint,
                        Mode = createRandomCardChargeResponseProperties.Meta.Authorization.Mode,

                    }
                },
                Message = createRandomCardChargeResponseProperties.Message,
                Status = createRandomCardChargeResponseProperties.Status,

            };

            var randomCardCharge = new CardCharge
            {
                Request = randomCardChargeRequest,
            };


            CardCharge inputCardCharge = randomCardCharge;
            CardCharge expectedCardCharge = inputCardCharge.DeepClone();
            expectedCardCharge.Response = randomCardChargeResponse;

            ExternalEncryptedChargeRequest mappedExternalEncryptedChargeRequest =
               randomExternalEncryptedChargeRequest;


            ExternalCardChargeResponse returnedExternalCardChargeResponse =
                randomExternalCardChargeResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                     .ReturnsAsync(returnedExternalCardChargeResponse);

            // when
            CardCharge actualCreateCardCharge =
               await this.chargeService.PostChargeCardRequestAsync(inputCardCharge, mappedExternalEncryptedChargeRequest.Client);

            // then
            actualCreateCardCharge.Should().BeEquivalentTo(expectedCardCharge);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}