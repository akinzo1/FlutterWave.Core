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
        public async Task ShouldPostUSSDWithUSSDRequestAsync()
        {
            // given 



            dynamic createRandomUSSDRequestProperties =
              CreateRandomUSSDRequestProperties();

            dynamic createRandomUSSDResponseProperties =
                CreateRandomUSSDResponseProperties();


            var randomExternalUSSDRequest = new ExternalUSSDRequest
            {
                Amount = createRandomUSSDRequestProperties.Amount,
                PhoneNumber = createRandomUSSDRequestProperties.PhoneNumber,
                Currency = createRandomUSSDRequestProperties.Currency,
                FullName = createRandomUSSDRequestProperties.Fullname,
                Email = createRandomUSSDRequestProperties.Email,
                AccountBank = createRandomUSSDRequestProperties.AccountBank,
                TxRef = createRandomUSSDRequestProperties.TxRef,

            };

            var randomExternalUSSDResponse = new ExternalUSSDResponse
            {
                Data = new ExternalUSSDResponse.ExternalUSSDData
                {
                    TxRef = createRandomUSSDResponseProperties.Data.TxRef,
                    Currency = createRandomUSSDResponseProperties.Data.Currency,
                    AccountId = createRandomUSSDResponseProperties.Data.AccountId,
                    Amount = createRandomUSSDResponseProperties.Data.Amount,
                    AppFee = createRandomUSSDResponseProperties.Data.AppFee,
                    AuthModel = createRandomUSSDResponseProperties.Data.AuthModel,
                    PaymentCode = createRandomUSSDResponseProperties.Data.PaymentCode,
                    ChargedAmount = createRandomUSSDResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomUSSDResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomUSSDResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomUSSDResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomUSSDResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomUSSDResponseProperties.Data.FraudStatus,
                    Id = createRandomUSSDResponseProperties.Data.Id,
                    Ip = createRandomUSSDResponseProperties.Data.Ip,
                    MerchantFee = createRandomUSSDResponseProperties.Data.MerchantFee,
                    Narration = createRandomUSSDResponseProperties.Data.Narration,
                    PaymentType = createRandomUSSDResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomUSSDResponseProperties.Data.ProcessorResponse,
                    Status = createRandomUSSDResponseProperties.Data.Status,
                    Customer = new ExternalUSSDResponse.Customer
                    {
                        Id = createRandomUSSDResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomUSSDResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomUSSDResponseProperties.Data.Customer.Email,
                        Name = createRandomUSSDResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomUSSDResponseProperties.Data.Customer.PhoneNumber
                    }
                },
                Meta = new ExternalUSSDResponse.ExternalUSSDMeta
                {
                    Authorization = new ExternalUSSDResponse.Authorization
                    {
                        Note = createRandomUSSDResponseProperties.Meta.Authorization.Note,
                        Mode = createRandomUSSDResponseProperties.Meta.Authorization.Mode

                    }
                },
                Message = createRandomUSSDResponseProperties.Message,
                Status = createRandomUSSDResponseProperties.Status,

            };


            var randomUSSDRequest = new USSDRequest
            {
                Amount = createRandomUSSDRequestProperties.Amount,
                PhoneNumber = createRandomUSSDRequestProperties.PhoneNumber,
                Currency = createRandomUSSDRequestProperties.Currency,
                FullName = createRandomUSSDRequestProperties.Fullname,
                Email = createRandomUSSDRequestProperties.Email,
                AccountBank = createRandomUSSDRequestProperties.AccountBank,
                TxRef = createRandomUSSDRequestProperties.TxRef,

            };

            var randomUSSDResponse = new USSDResponse
            {
                Data = new USSDResponse.USSDData
                {
                    TxRef = createRandomUSSDResponseProperties.Data.TxRef,
                    Currency = createRandomUSSDResponseProperties.Data.Currency,
                    AccountId = createRandomUSSDResponseProperties.Data.AccountId,
                    Amount = createRandomUSSDResponseProperties.Data.Amount,
                    AppFee = createRandomUSSDResponseProperties.Data.AppFee,
                    AuthModel = createRandomUSSDResponseProperties.Data.AuthModel,
                    PaymentCode = createRandomUSSDResponseProperties.Data.PaymentCode,
                    ChargedAmount = createRandomUSSDResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomUSSDResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomUSSDResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomUSSDResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomUSSDResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomUSSDResponseProperties.Data.FraudStatus,
                    Id = createRandomUSSDResponseProperties.Data.Id,
                    Ip = createRandomUSSDResponseProperties.Data.Ip,
                    MerchantFee = createRandomUSSDResponseProperties.Data.MerchantFee,
                    Narration = createRandomUSSDResponseProperties.Data.Narration,
                    PaymentType = createRandomUSSDResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomUSSDResponseProperties.Data.ProcessorResponse,
                    Status = createRandomUSSDResponseProperties.Data.Status,
                    Customer = new USSDResponse.Customer
                    {
                        Id = createRandomUSSDResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomUSSDResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomUSSDResponseProperties.Data.Customer.Email,
                        Name = createRandomUSSDResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomUSSDResponseProperties.Data.Customer.PhoneNumber
                    }
                },
                Meta = new USSDResponse.USSDMeta
                {
                    Authorization = new USSDResponse.Authorization
                    {
                        Note = createRandomUSSDResponseProperties.Meta.Authorization.Note,
                        Mode = createRandomUSSDResponseProperties.Meta.Authorization.Mode

                    }
                },
                Message = createRandomUSSDResponseProperties.Message,
                Status = createRandomUSSDResponseProperties.Status,

            };


            var randomUSSD = new USSD
            {
                Request = randomUSSDRequest,
            };

            USSD inputUSSD = randomUSSD;
            USSD expectedUSSD = inputUSSD.DeepClone();
            expectedUSSD.Response = randomUSSDResponse;

            ExternalUSSDRequest mappedExternalUSSDRequest =
               randomExternalUSSDRequest;

            ExternalUSSDResponse returnedExternalUSSDResponse =
                randomExternalUSSDResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeUSSDAsync(It.Is(
                      SameExternalUSSDRequestAs(mappedExternalUSSDRequest))))
                     .ReturnsAsync(returnedExternalUSSDResponse);

            // when
            USSD actualCreateUSSD =
               await this.chargeService.PostChargeUSSDRequestAsync(inputUSSD);

            // then
            actualCreateUSSD.Should().BeEquivalentTo(expectedUSSD);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeUSSDAsync(It.Is(
                   SameExternalUSSDRequestAs(mappedExternalUSSDRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}