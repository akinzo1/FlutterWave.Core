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
        public async Task ShouldPostGooglePayWithGooglePayRequestAsync()
        {
            // given 



            dynamic createRandomGooglePayRequestProperties =
              CreateRandomGooglePayRequestProperties();

            dynamic createRandomGooglePayResponseProperties =
                CreateRandomGooglePayResponseProperties();


            var randomExternalGooglePayRequest = new ExternalGooglePayRequest
            {
                Amount = createRandomGooglePayRequestProperties.Amount,
                Currency = createRandomGooglePayRequestProperties.Currency,
                BillingAddress = createRandomGooglePayRequestProperties.BillingAddress,
                Narration = createRandomGooglePayRequestProperties.Narration,
                Fullname = createRandomGooglePayRequestProperties.Fullname,
                BillingZip = createRandomGooglePayRequestProperties.BillingZip,
                BillingCountry = createRandomGooglePayRequestProperties.BillingCountry,
                BillingCity = createRandomGooglePayRequestProperties.BillingCity,
                BillingState = createRandomGooglePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomGooglePayRequestProperties.DeviceFingerprint,

                Meta = new ExternalGooglePayRequest.ExternalGooglePayMeta
                {
                    MetaName = createRandomGooglePayRequestProperties.Meta.Metaname,
                    MetaValue = createRandomGooglePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomGooglePayRequestProperties.ClientIp,
                Email = createRandomGooglePayRequestProperties.Email,
                RedirectUrl = createRandomGooglePayRequestProperties.RedirectUrl,
                TxRef = createRandomGooglePayRequestProperties.TxRef,

            };

            var randomExternalGooglePayResponse = new ExternalGooglePayResponse
            {
                Data = new ExternalGooglePayResponse.ExternalGooglePayData
                {
                    TxRef = createRandomGooglePayResponseProperties.Data.TxRef,
                    Currency = createRandomGooglePayResponseProperties.Data.Currency,
                    AccountId = createRandomGooglePayResponseProperties.Data.AccountId,
                    Amount = createRandomGooglePayResponseProperties.Data.Amount,
                    AppFee = createRandomGooglePayResponseProperties.Data.AppFee,
                    AuthModel = createRandomGooglePayResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomGooglePayResponseProperties.Data.AuthUrl,
                    Meta = new ExternalGooglePayResponse.Meta
                    {
                        Authorization = new ExternalGooglePayResponse.Authorization
                        {
                            Redirect = createRandomGooglePayResponseProperties.Meta.Authorization.RedirectUrl,
                            Mode = createRandomGooglePayResponseProperties.Meta.Authorization.Mode

                        }
                    },
                    ChargedAmount = createRandomGooglePayResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomGooglePayResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomGooglePayResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomGooglePayResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomGooglePayResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomGooglePayResponseProperties.Data.FraudStatus,
                    Id = createRandomGooglePayResponseProperties.Data.Id,
                    Ip = createRandomGooglePayResponseProperties.Data.Ip,
                    MerchantFee = createRandomGooglePayResponseProperties.Data.MerchantFee,
                    Narration = createRandomGooglePayResponseProperties.Data.Narration,
                    PaymentType = createRandomGooglePayResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomGooglePayResponseProperties.Data.ProcessorResponse,
                    Status = createRandomGooglePayResponseProperties.Data.Status,
                    Customer = new ExternalGooglePayResponse.Customer
                    {
                        Id = createRandomGooglePayResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomGooglePayResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomGooglePayResponseProperties.Data.Customer.Email,
                        Name = createRandomGooglePayResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomGooglePayResponseProperties.Data.Customer.PhoneNumber
                    }
                },

                Message = createRandomGooglePayResponseProperties.Message,
                Status = createRandomGooglePayResponseProperties.Status,

            };


            var randomGooglePayRequest = new GooglePayRequest
            {
                Amount = createRandomGooglePayRequestProperties.Amount,
                Currency = createRandomGooglePayRequestProperties.Currency,
                BillingAddress = createRandomGooglePayRequestProperties.BillingAddress,
                Narration = createRandomGooglePayRequestProperties.Narration,
                FullName = createRandomGooglePayRequestProperties.Fullname,
                BillingZip = createRandomGooglePayRequestProperties.BillingZip,
                BillingCountry = createRandomGooglePayRequestProperties.BillingCountry,
                BillingCity = createRandomGooglePayRequestProperties.BillingCity,
                BillingState = createRandomGooglePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomGooglePayRequestProperties.DeviceFingerprint,

                Meta = new GooglePayRequest.GooglePayMeta
                {
                    MetaName = createRandomGooglePayRequestProperties.Meta.Metaname,
                    MetaValue = createRandomGooglePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomGooglePayRequestProperties.ClientIp,
                Email = createRandomGooglePayRequestProperties.Email,
                RedirectUrl = createRandomGooglePayRequestProperties.RedirectUrl,
                TxRef = createRandomGooglePayRequestProperties.TxRef,

            };

            var randomGooglePayResponse = new GooglePayResponse
            {
                Data = new GooglePayResponse.GooglePayData
                {
                    TxRef = createRandomGooglePayResponseProperties.Data.TxRef,
                    Currency = createRandomGooglePayResponseProperties.Data.Currency,
                    AccountId = createRandomGooglePayResponseProperties.Data.AccountId,
                    Amount = createRandomGooglePayResponseProperties.Data.Amount,
                    AppFee = createRandomGooglePayResponseProperties.Data.AppFee,
                    AuthModel = createRandomGooglePayResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomGooglePayResponseProperties.Data.AuthUrl,
                    Meta = new GooglePayResponse.Meta
                    {
                        Authorization = new GooglePayResponse.Authorization
                        {
                            Redirect = createRandomGooglePayResponseProperties.Meta.Authorization.RedirectUrl,
                            Mode = createRandomGooglePayResponseProperties.Meta.Authorization.Mode

                        }
                    },
                    ChargedAmount = createRandomGooglePayResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomGooglePayResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomGooglePayResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomGooglePayResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomGooglePayResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomGooglePayResponseProperties.Data.FraudStatus,
                    Id = createRandomGooglePayResponseProperties.Data.Id,
                    Ip = createRandomGooglePayResponseProperties.Data.Ip,
                    MerchantFee = createRandomGooglePayResponseProperties.Data.MerchantFee,
                    Narration = createRandomGooglePayResponseProperties.Data.Narration,
                    PaymentType = createRandomGooglePayResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomGooglePayResponseProperties.Data.ProcessorResponse,
                    Status = createRandomGooglePayResponseProperties.Data.Status,
                    Customer = new GooglePayResponse.Customer
                    {
                        Id = createRandomGooglePayResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomGooglePayResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomGooglePayResponseProperties.Data.Customer.Email,
                        Name = createRandomGooglePayResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomGooglePayResponseProperties.Data.Customer.PhoneNumber
                    }
                },

                Message = createRandomGooglePayResponseProperties.Message,
                Status = createRandomGooglePayResponseProperties.Status,

            };


            var randomGooglePay = new GooglePay
            {
                Request = randomGooglePayRequest,
            };

            GooglePay inputGooglePay = randomGooglePay;
            GooglePay expectedGooglePay = inputGooglePay.DeepClone();
            expectedGooglePay.Response = randomGooglePayResponse;

            ExternalGooglePayRequest mappedExternalGooglePayRequest =
               randomExternalGooglePayRequest;

            ExternalGooglePayResponse returnedExternalGooglePayResponse =
                randomExternalGooglePayResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeGooglePayAsync(It.Is(
                      SameExternalGooglePayRequestAs(mappedExternalGooglePayRequest))))
                     .ReturnsAsync(returnedExternalGooglePayResponse);

            // when
            GooglePay actualCreateGooglePay =
               await this.chargeService.PostChargeGooglePayRequestAsync(inputGooglePay);

            // then
            actualCreateGooglePay.Should().BeEquivalentTo(expectedGooglePay);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeGooglePayAsync(It.Is(
                   SameExternalGooglePayRequestAs(mappedExternalGooglePayRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}