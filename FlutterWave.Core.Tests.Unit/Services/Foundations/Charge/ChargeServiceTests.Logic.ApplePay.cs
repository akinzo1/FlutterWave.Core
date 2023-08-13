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
        public async Task ShouldPostApplePayWithApplePayRequestAsync()
        {
            // given 



            dynamic createRandomApplePayRequestProperties =
              CreateRandomApplePayRequestProperties();

            dynamic createRandomApplePayResponseProperties =
                CreateRandomApplePayResponseProperties();


            var randomExternalApplePayRequest = new ExternalApplePayRequest
            {
                Amount = createRandomApplePayRequestProperties.Amount,
                Currency = createRandomApplePayRequestProperties.Currency,
                BillingAddress = createRandomApplePayRequestProperties.BillingAddress,
                Narration = createRandomApplePayRequestProperties.Narration,
                PhoneNumber = createRandomApplePayRequestProperties.PhoneNumber,
                FullName = createRandomApplePayRequestProperties.Fullname,
                BillingZip = createRandomApplePayRequestProperties.BillingZip,
                BillingCountry = createRandomApplePayRequestProperties.BillingCountry,
                BillingCity = createRandomApplePayRequestProperties.BillingCity,
                BillingState = createRandomApplePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomApplePayRequestProperties.DeviceFingerprint,
                Meta = new ExternalApplePayRequest.ExternalApplePayMeta
                {
                    Metaname = createRandomApplePayRequestProperties.Meta.Metaname,
                    Metavalue = createRandomApplePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomApplePayRequestProperties.ClientIp,
                Email = createRandomApplePayRequestProperties.Email,
                RedirectUrl = createRandomApplePayRequestProperties.RedirectUrl,
                TxRef = createRandomApplePayRequestProperties.TxRef,

            };

            var randomExternalApplePayResponse = new ExternalApplePayResponse
            {
                Data = new ExternalApplePayResponse.ExternalApplePayData
                {
                    TxRef = createRandomApplePayResponseProperties.Data.TxRef,
                    Currency = createRandomApplePayResponseProperties.Data.Currency,
                    AccountId = createRandomApplePayResponseProperties.Data.AccountId,
                    Amount = createRandomApplePayResponseProperties.Data.Amount,
                    AppFee = createRandomApplePayResponseProperties.Data.AppFee,
                    AuthModel = createRandomApplePayResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomApplePayResponseProperties.Data.AuthUrl,
                    Meta = new ExternalApplePayResponse.Meta
                    {
                        Authorization = new ExternalApplePayResponse.Authorization
                        {
                            Redirect = createRandomApplePayResponseProperties.Data.Meta.Authorization.Redirect,
                            Mode = createRandomApplePayResponseProperties.Data.Meta.Authorization.Mode

                        }
                    },
                    ChargedAmount = createRandomApplePayResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomApplePayResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomApplePayResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomApplePayResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomApplePayResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomApplePayResponseProperties.Data.FraudStatus,
                    Id = createRandomApplePayResponseProperties.Data.Id,
                    Ip = createRandomApplePayResponseProperties.Data.Ip,
                    MerchantFee = createRandomApplePayResponseProperties.Data.MerchantFee,
                    Narration = createRandomApplePayResponseProperties.Data.Narration,
                    PaymentType = createRandomApplePayResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomApplePayResponseProperties.Data.ProcessorResponse,
                    Status = createRandomApplePayResponseProperties.Data.Status,
                    Customer = new ExternalApplePayResponse.Customer
                    {
                        Id = createRandomApplePayResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomApplePayResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomApplePayResponseProperties.Data.Customer.Email,
                        Name = createRandomApplePayResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomApplePayResponseProperties.Data.Customer.PhoneNumber
                    }
                },

                Message = createRandomApplePayResponseProperties.Message,
                Status = createRandomApplePayResponseProperties.Status,

            };


            var randomApplePayRequest = new ApplePayRequest
            {
                Amount = createRandomApplePayRequestProperties.Amount,
                Currency = createRandomApplePayRequestProperties.Currency,
                BillingAddress = createRandomApplePayRequestProperties.BillingAddress,
                Narration = createRandomApplePayRequestProperties.Narration,
                PhoneNumber = createRandomApplePayRequestProperties.PhoneNumber,
                FullName = createRandomApplePayRequestProperties.Fullname,
                BillingZip = createRandomApplePayRequestProperties.BillingZip,
                BillingCountry = createRandomApplePayRequestProperties.BillingCountry,
                BillingCity = createRandomApplePayRequestProperties.BillingCity,
                BillingState = createRandomApplePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomApplePayRequestProperties.DeviceFingerprint,
                Meta = new ApplePayRequest.ApplePayMeta
                {
                    Metaname = createRandomApplePayRequestProperties.Meta.Metaname,
                    Metavalue = createRandomApplePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomApplePayRequestProperties.ClientIp,
                Email = createRandomApplePayRequestProperties.Email,
                RedirectUrl = createRandomApplePayRequestProperties.RedirectUrl,
                TxRef = createRandomApplePayRequestProperties.TxRef,

            };

            var randomApplePayResponse = new ApplePayResponse
            {
                Data = new ApplePayResponse.ApplePayData
                {
                    TxRef = createRandomApplePayResponseProperties.Data.TxRef,
                    Currency = createRandomApplePayResponseProperties.Data.Currency,
                    AccountId = createRandomApplePayResponseProperties.Data.AccountId,
                    Amount = createRandomApplePayResponseProperties.Data.Amount,
                    AppFee = createRandomApplePayResponseProperties.Data.AppFee,
                    AuthModel = createRandomApplePayResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomApplePayResponseProperties.Data.AuthUrl,
                    Meta = new ApplePayResponse.Meta
                    {
                        Authorization = new ApplePayResponse.Authorization
                        {
                            Redirect = createRandomApplePayResponseProperties.Data.Meta.Authorization.Redirect,
                            Mode = createRandomApplePayResponseProperties.Data.Meta.Authorization.Mode

                        }
                    },
                    ChargedAmount = createRandomApplePayResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomApplePayResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomApplePayResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomApplePayResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomApplePayResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomApplePayResponseProperties.Data.FraudStatus,
                    Id = createRandomApplePayResponseProperties.Data.Id,
                    Ip = createRandomApplePayResponseProperties.Data.Ip,
                    MerchantFee = createRandomApplePayResponseProperties.Data.MerchantFee,
                    Narration = createRandomApplePayResponseProperties.Data.Narration,
                    PaymentType = createRandomApplePayResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomApplePayResponseProperties.Data.ProcessorResponse,
                    Status = createRandomApplePayResponseProperties.Data.Status,
                    Customer = new ApplePayResponse.Customer
                    {
                        Id = createRandomApplePayResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomApplePayResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomApplePayResponseProperties.Data.Customer.Email,
                        Name = createRandomApplePayResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomApplePayResponseProperties.Data.Customer.PhoneNumber
                    }
                },

                Message = createRandomApplePayResponseProperties.Message,
                Status = createRandomApplePayResponseProperties.Status,

            };


            var randomApplePay = new ApplePay
            {
                Request = randomApplePayRequest,
            };

            ApplePay inputApplePay = randomApplePay;
            ApplePay expectedApplePay = inputApplePay.DeepClone();
            expectedApplePay.Response = randomApplePayResponse;

            ExternalApplePayRequest mappedExternalApplePayRequest =
               randomExternalApplePayRequest;

            ExternalApplePayResponse returnedExternalApplePayResponse =
                randomExternalApplePayResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeApplePayAsync(It.Is(
                      SameExternalApplePayRequestAs(mappedExternalApplePayRequest))))
                     .ReturnsAsync(returnedExternalApplePayResponse);

            // when
            ApplePay actualCreateApplePay =
               await this.chargeService.PostChargeApplePayRequestAsync(inputApplePay);

            // then
            actualCreateApplePay.Should().BeEquivalentTo(expectedApplePay);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeApplePayAsync(It.Is(
                   SameExternalApplePayRequestAs(mappedExternalApplePayRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}