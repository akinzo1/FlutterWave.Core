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
        public async Task ShouldPostTanzaniaMobileMoneyWithTanzaniaMobileMoneyRequestAsync()
        {
            // given 



            dynamic createRandomTanzaniaMobileMoneyRequestProperties =
              CreateRandomTanzaniaMobileMoneyRequestProperties();

            dynamic createRandomTanzaniaMobileMoneyResponseProperties =
                CreateRandomTanzaniaMobileMoneyResponseProperties();


            var randomExternalTanzaniaMobileMoneyRequest = new ExternalTanzaniaMobileMoneyRequest
            {
                Amount = createRandomTanzaniaMobileMoneyRequestProperties.Amount,
                Currency = createRandomTanzaniaMobileMoneyRequestProperties.Currency,
                Email = createRandomTanzaniaMobileMoneyRequestProperties.Email,
                TxRef = createRandomTanzaniaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomTanzaniaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomTanzaniaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomTanzaniaMobileMoneyRequestProperties.Network,
                Meta = new ExternalTanzaniaMobileMoneyRequest.ExternalTanzaniaMobileMoneyMeta
                {
                    FlightID = createRandomTanzaniaMobileMoneyRequestProperties.Meta.FlightID
                },
                Fullname = createRandomTanzaniaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomTanzaniaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomExternalTanzaniaMobileMoneyResponse = new ExternalTanzaniaMobileMoneyResponse
            {
                Data = new ExternalTanzaniaMobileMoneyResponse.ExternalTanzaniaMobileMoneyData
                {
                    TxRef = createRandomTanzaniaMobileMoneyResponseProperties.Data.TxRef,
                    Currency = createRandomTanzaniaMobileMoneyResponseProperties.Data.Currency,
                    AccountId = createRandomTanzaniaMobileMoneyResponseProperties.Data.AccountId,
                    Amount = createRandomTanzaniaMobileMoneyResponseProperties.Data.Amount,
                    AppFee = createRandomTanzaniaMobileMoneyResponseProperties.Data.AppFee,
                    AuthModel = createRandomTanzaniaMobileMoneyResponseProperties.Data.AuthModel,
                    ChargedAmount = createRandomTanzaniaMobileMoneyResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomTanzaniaMobileMoneyResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomTanzaniaMobileMoneyResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomTanzaniaMobileMoneyResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomTanzaniaMobileMoneyResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomTanzaniaMobileMoneyResponseProperties.Data.FraudStatus,
                    Id = createRandomTanzaniaMobileMoneyResponseProperties.Data.Id,
                    Ip = createRandomTanzaniaMobileMoneyResponseProperties.Data.Ip,
                    MerchantFee = createRandomTanzaniaMobileMoneyResponseProperties.Data.MerchantFee,
                    Narration = createRandomTanzaniaMobileMoneyResponseProperties.Data.Narration,
                    PaymentType = createRandomTanzaniaMobileMoneyResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomTanzaniaMobileMoneyResponseProperties.Data.ProcessorResponse,
                    Status = createRandomTanzaniaMobileMoneyResponseProperties.Data.Status,
                    Customer = new ExternalTanzaniaMobileMoneyResponse.Customer
                    {
                        Id = createRandomTanzaniaMobileMoneyResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomTanzaniaMobileMoneyResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomTanzaniaMobileMoneyResponseProperties.Data.Customer.Email,
                        Name = createRandomTanzaniaMobileMoneyResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomTanzaniaMobileMoneyResponseProperties.Data.Customer.PhoneNumber

                    }
                },

                Message = createRandomTanzaniaMobileMoneyResponseProperties.Message,
                Status = createRandomTanzaniaMobileMoneyResponseProperties.Status,

            };


            var randomTanzaniaMobileMoneyRequest = new TanzaniaMobileMoneyRequest
            {
                Amount = createRandomTanzaniaMobileMoneyRequestProperties.Amount,
                Currency = createRandomTanzaniaMobileMoneyRequestProperties.Currency,
                Email = createRandomTanzaniaMobileMoneyRequestProperties.Email,
                TxRef = createRandomTanzaniaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomTanzaniaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomTanzaniaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomTanzaniaMobileMoneyRequestProperties.Network,
                Meta = new TanzaniaMobileMoneyRequest.TanzaniaMobileMoneyMeta
                {
                    FlightID = createRandomTanzaniaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomTanzaniaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomTanzaniaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomTanzaniaMobileMoneyResponse = new TanzaniaMobileMoneyResponse
            {
                Data = new TanzaniaMobileMoneyResponse.TanzaniaMobileMoneyData
                {
                    TxRef = createRandomTanzaniaMobileMoneyResponseProperties.Data.TxRef,
                    Currency = createRandomTanzaniaMobileMoneyResponseProperties.Data.Currency,
                    AccountId = createRandomTanzaniaMobileMoneyResponseProperties.Data.AccountId,
                    Amount = createRandomTanzaniaMobileMoneyResponseProperties.Data.Amount,
                    AppFee = createRandomTanzaniaMobileMoneyResponseProperties.Data.AppFee,
                    AuthModel = createRandomTanzaniaMobileMoneyResponseProperties.Data.AuthModel,
                    ChargedAmount = createRandomTanzaniaMobileMoneyResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomTanzaniaMobileMoneyResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomTanzaniaMobileMoneyResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomTanzaniaMobileMoneyResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomTanzaniaMobileMoneyResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomTanzaniaMobileMoneyResponseProperties.Data.FraudStatus,
                    Id = createRandomTanzaniaMobileMoneyResponseProperties.Data.Id,
                    Ip = createRandomTanzaniaMobileMoneyResponseProperties.Data.Ip,
                    MerchantFee = createRandomTanzaniaMobileMoneyResponseProperties.Data.MerchantFee,
                    Narration = createRandomTanzaniaMobileMoneyResponseProperties.Data.Narration,
                    PaymentType = createRandomTanzaniaMobileMoneyResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomTanzaniaMobileMoneyResponseProperties.Data.ProcessorResponse,
                    Status = createRandomTanzaniaMobileMoneyResponseProperties.Data.Status,
                    Customer = new TanzaniaMobileMoneyResponse.Customer
                    {
                        Id = createRandomTanzaniaMobileMoneyResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomTanzaniaMobileMoneyResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomTanzaniaMobileMoneyResponseProperties.Data.Customer.Email,
                        Name = createRandomTanzaniaMobileMoneyResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomTanzaniaMobileMoneyResponseProperties.Data.Customer.PhoneNumber

                    }
                },

                Message = createRandomTanzaniaMobileMoneyResponseProperties.Message,
                Status = createRandomTanzaniaMobileMoneyResponseProperties.Status,
            };


            var randomTanzaniaMobileMoney = new TanzaniaMobileMoney
            {
                Request = randomTanzaniaMobileMoneyRequest,
            };

            TanzaniaMobileMoney inputTanzaniaMobileMoney = randomTanzaniaMobileMoney;
            TanzaniaMobileMoney expectedTanzaniaMobileMoney = inputTanzaniaMobileMoney.DeepClone();
            expectedTanzaniaMobileMoney.Response = randomTanzaniaMobileMoneyResponse;

            ExternalTanzaniaMobileMoneyRequest mappedExternalTanzaniaMobileMoneyRequest =
               randomExternalTanzaniaMobileMoneyRequest;

            ExternalTanzaniaMobileMoneyResponse returnedExternalTanzaniaMobileMoneyResponse =
                randomExternalTanzaniaMobileMoneyResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeTanzaniaMobileMoneyAsync(It.Is(
                      SameExternalTanzaniaMobileMoneyRequestAs(mappedExternalTanzaniaMobileMoneyRequest))))
                     .ReturnsAsync(returnedExternalTanzaniaMobileMoneyResponse);

            // when
            TanzaniaMobileMoney actualCreateTanzaniaMobileMoney =
               await this.chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(inputTanzaniaMobileMoney);

            // then
            actualCreateTanzaniaMobileMoney.Should().BeEquivalentTo(expectedTanzaniaMobileMoney);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeTanzaniaMobileMoneyAsync(It.Is(
                   SameExternalTanzaniaMobileMoneyRequestAs(mappedExternalTanzaniaMobileMoneyRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}