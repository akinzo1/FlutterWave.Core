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
        public async Task ShouldPostFrancophoneMobileMoneyWithFrancophoneMobileMoneyRequestAsync()
        {
            // given 



            dynamic createRandomFrancophoneMobileMoneyRequestProperties =
              CreateRandomFrancophoneMobileMoneyRequestProperties();

            dynamic createRandomFrancophoneMobileMoneyResponseProperties =
                CreateRandomFrancophoneMobileMoneyResponseProperties();


            var randomExternalFrancophoneMobileMoneyRequest = new ExternalFrancophoneMobileMoneyRequest
            {
                Amount = createRandomFrancophoneMobileMoneyRequestProperties.Amount,
                Currency = createRandomFrancophoneMobileMoneyRequestProperties.Currency,
                Email = createRandomFrancophoneMobileMoneyRequestProperties.Email,
                TxRef = createRandomFrancophoneMobileMoneyRequestProperties.TxRef,
                Country = createRandomFrancophoneMobileMoneyRequestProperties.Country,
                FullName = createRandomFrancophoneMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomFrancophoneMobileMoneyRequestProperties.PhoneNumber

            };

            var randomExternalFrancophoneMobileMoneyResponse = new ExternalFrancophoneMobileMoneyResponse
            {
                Data = new ExternalFrancophoneMobileMoneyResponse.ExternalFrancophoneMobileMoneyData
                {
                    TxRef = createRandomFrancophoneMobileMoneyResponseProperties.Data.TxRef,
                    Currency = createRandomFrancophoneMobileMoneyResponseProperties.Data.Currency,
                    AccountId = createRandomFrancophoneMobileMoneyResponseProperties.Data.AccountId,
                    Amount = createRandomFrancophoneMobileMoneyResponseProperties.Data.Amount,
                    AppFee = createRandomFrancophoneMobileMoneyResponseProperties.Data.AppFee,
                    AuthModel = createRandomFrancophoneMobileMoneyResponseProperties.Data.AuthModel,
                    OrderId = createRandomFrancophoneMobileMoneyResponseProperties.Data.OrderId,
                    ChargedAmount = createRandomFrancophoneMobileMoneyResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomFrancophoneMobileMoneyResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomFrancophoneMobileMoneyResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomFrancophoneMobileMoneyResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomFrancophoneMobileMoneyResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomFrancophoneMobileMoneyResponseProperties.Data.FraudStatus,
                    Id = createRandomFrancophoneMobileMoneyResponseProperties.Data.Id,
                    Ip = createRandomFrancophoneMobileMoneyResponseProperties.Data.Ip,
                    MerchantFee = createRandomFrancophoneMobileMoneyResponseProperties.Data.MerchantFee,
                    Narration = createRandomFrancophoneMobileMoneyResponseProperties.Data.Narration,
                    PaymentType = createRandomFrancophoneMobileMoneyResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomFrancophoneMobileMoneyResponseProperties.Data.ProcessorResponse,
                    Status = createRandomFrancophoneMobileMoneyResponseProperties.Data.Status,
                    Customer = new ExternalFrancophoneMobileMoneyResponse.Customer
                    {
                        Id = createRandomFrancophoneMobileMoneyResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomFrancophoneMobileMoneyResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomFrancophoneMobileMoneyResponseProperties.Data.Customer.Email,
                        Name = createRandomFrancophoneMobileMoneyResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomFrancophoneMobileMoneyResponseProperties.Data.Customer.PhoneNumber
                    }
                },
                Meta = new ExternalFrancophoneMobileMoneyResponse.ExternalFrancophoneMobileMoneyMeta
                {
                    Authorization = new ExternalFrancophoneMobileMoneyResponse.Authorization
                    {
                        RedirectUrl = createRandomFrancophoneMobileMoneyResponseProperties.Meta.Authorization.RedirectUrl,
                        Mode = createRandomFrancophoneMobileMoneyResponseProperties.Meta.Authorization.Mode

                    }
                },
                Message = createRandomFrancophoneMobileMoneyResponseProperties.Message,
                Status = createRandomFrancophoneMobileMoneyResponseProperties.Status,

            };


            var randomFrancophoneMobileMoneyRequest = new FrancophoneMobileMoneyRequest
            {
                Amount = createRandomFrancophoneMobileMoneyRequestProperties.Amount,
                Currency = createRandomFrancophoneMobileMoneyRequestProperties.Currency,
                Email = createRandomFrancophoneMobileMoneyRequestProperties.Email,
                TxRef = createRandomFrancophoneMobileMoneyRequestProperties.TxRef,
                Country = createRandomFrancophoneMobileMoneyRequestProperties.Country,
                FullName = createRandomFrancophoneMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomFrancophoneMobileMoneyRequestProperties.PhoneNumber

            };

            var randomFrancophoneMobileMoneyResponse = new FrancophoneMobileMoneyResponse
            {
                Data = new FrancophoneMobileMoneyResponse.FrancophoneMobileMoneyData
                {
                    TxRef = createRandomFrancophoneMobileMoneyResponseProperties.Data.TxRef,
                    Currency = createRandomFrancophoneMobileMoneyResponseProperties.Data.Currency,
                    AccountId = createRandomFrancophoneMobileMoneyResponseProperties.Data.AccountId,
                    Amount = createRandomFrancophoneMobileMoneyResponseProperties.Data.Amount,
                    AppFee = createRandomFrancophoneMobileMoneyResponseProperties.Data.AppFee,
                    AuthModel = createRandomFrancophoneMobileMoneyResponseProperties.Data.AuthModel,
                    OrderId = createRandomFrancophoneMobileMoneyResponseProperties.Data.OrderId,
                    ChargedAmount = createRandomFrancophoneMobileMoneyResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomFrancophoneMobileMoneyResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomFrancophoneMobileMoneyResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomFrancophoneMobileMoneyResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomFrancophoneMobileMoneyResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomFrancophoneMobileMoneyResponseProperties.Data.FraudStatus,
                    Id = createRandomFrancophoneMobileMoneyResponseProperties.Data.Id,
                    Ip = createRandomFrancophoneMobileMoneyResponseProperties.Data.Ip,
                    MerchantFee = createRandomFrancophoneMobileMoneyResponseProperties.Data.MerchantFee,
                    Narration = createRandomFrancophoneMobileMoneyResponseProperties.Data.Narration,
                    PaymentType = createRandomFrancophoneMobileMoneyResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomFrancophoneMobileMoneyResponseProperties.Data.ProcessorResponse,
                    Status = createRandomFrancophoneMobileMoneyResponseProperties.Data.Status,
                    Customer = new FrancophoneMobileMoneyResponse.Customer
                    {
                        Id = createRandomFrancophoneMobileMoneyResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomFrancophoneMobileMoneyResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomFrancophoneMobileMoneyResponseProperties.Data.Customer.Email,
                        Name = createRandomFrancophoneMobileMoneyResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomFrancophoneMobileMoneyResponseProperties.Data.Customer.PhoneNumber
                    }
                },
                Meta = new FrancophoneMobileMoneyResponse.FrancophoneMobileMoneyMeta
                {
                    Authorization = new FrancophoneMobileMoneyResponse.Authorization
                    {
                        RedirectUrl = createRandomFrancophoneMobileMoneyResponseProperties.Meta.Authorization.RedirectUrl,
                        Mode = createRandomFrancophoneMobileMoneyResponseProperties.Meta.Authorization.Mode

                    }
                },
                Message = createRandomFrancophoneMobileMoneyResponseProperties.Message,
                Status = createRandomFrancophoneMobileMoneyResponseProperties.Status,

            };


            var randomFrancophoneMobileMoney = new FrancophoneMobileMoney
            {
                Request = randomFrancophoneMobileMoneyRequest,
            };

            FrancophoneMobileMoney inputFrancophoneMobileMoney = randomFrancophoneMobileMoney;
            FrancophoneMobileMoney expectedFrancophoneMobileMoney = inputFrancophoneMobileMoney.DeepClone();
            expectedFrancophoneMobileMoney.Response = randomFrancophoneMobileMoneyResponse;

            ExternalFrancophoneMobileMoneyRequest mappedExternalFrancophoneMobileMoneyRequest =
               randomExternalFrancophoneMobileMoneyRequest;

            ExternalFrancophoneMobileMoneyResponse returnedExternalFrancophoneMobileMoneyResponse =
                randomExternalFrancophoneMobileMoneyResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeFrancophoneMobileMoneyAsync(It.Is(
                      SameExternalFrancophoneMobileMoneyRequestAs(mappedExternalFrancophoneMobileMoneyRequest))))
                     .ReturnsAsync(returnedExternalFrancophoneMobileMoneyResponse);

            // when
            FrancophoneMobileMoney actualCreateFrancophoneMobileMoney =
               await this.chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(inputFrancophoneMobileMoney);

            // then
            actualCreateFrancophoneMobileMoney.Should().BeEquivalentTo(expectedFrancophoneMobileMoney);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeFrancophoneMobileMoneyAsync(It.Is(
                   SameExternalFrancophoneMobileMoneyRequestAs(mappedExternalFrancophoneMobileMoneyRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}