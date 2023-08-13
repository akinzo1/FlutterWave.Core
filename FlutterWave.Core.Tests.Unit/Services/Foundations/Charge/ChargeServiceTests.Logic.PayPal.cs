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
        public async Task ShouldPostPayPalWithPayPalRequestAsync()
        {
            // given 



            dynamic createRandomPayPalRequestProperties =
              CreateRandomPayPalRequestProperties();

            dynamic createRandomPayPalResponseProperties =
                CreateRandomPayPalResponseProperties();


            var randomExternalPayPalRequest = new ExternalPayPalRequest
            {
                Amount = createRandomPayPalRequestProperties.Amount,
                Currency = createRandomPayPalRequestProperties.Currency,
                Email = createRandomPayPalRequestProperties.Email,
                BillingAddress = createRandomPayPalRequestProperties.BillingAddress,
                BillingCity = createRandomPayPalRequestProperties.BillingCity,
                BillingCountry = createRandomPayPalRequestProperties.BillingCountry,
                BillingState = createRandomPayPalRequestProperties.BillingState,
                BillingZip = createRandomPayPalRequestProperties.BillingZip,
                ClientIp = createRandomPayPalRequestProperties.ClientIp,
                Country = createRandomPayPalRequestProperties.Country,
                DeviceFingerprint = createRandomPayPalRequestProperties.DeviceFingerprint,
                Fullname = createRandomPayPalRequestProperties.Fullname,
                PhoneNumber = createRandomPayPalRequestProperties.PhoneNumber,
                ShippingAddress = createRandomPayPalRequestProperties.ShippingAddress,
                ShippingCity = createRandomPayPalRequestProperties.ShippingCity,
                ShippingCountry = createRandomPayPalRequestProperties.ShippingCountry,
                ShippingName = createRandomPayPalRequestProperties.ShippingName,
                ShippingState = createRandomPayPalRequestProperties.ShippingState,
                ShippingZip = createRandomPayPalRequestProperties.ShippingZip,
                RedirectUrl = createRandomPayPalRequestProperties.RedirectUrl,
                TxRef = createRandomPayPalRequestProperties.TxRef,

            };

            var randomExternalPayPalResponse = new ExternalPayPalResponse
            {

                Data = new ExternalPayPalResponse.ExternalPayPalData
                {
                    TxRef = createRandomPayPalResponseProperties.Data.TxRef,
                    Currency = createRandomPayPalResponseProperties.Data.Currency,
                    AccountId = createRandomPayPalResponseProperties.Data.AccountId,
                    Amount = createRandomPayPalResponseProperties.Data.Amount,
                    AppFee = createRandomPayPalResponseProperties.Data.AppFee,
                    AuthModel = createRandomPayPalResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomPayPalResponseProperties.Data.AuthUrl,
                    Meta = new ExternalPayPalResponse.Meta
                    {
                        Authorization = new ExternalPayPalResponse.Authorization
                        {
                            Mode = createRandomPayPalResponseProperties.Data.Meta.Mode,
                            Redirect = createRandomPayPalResponseProperties.Data.Meta.Redirect
                        }
                    },
                    ChargedAmount = createRandomPayPalResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomPayPalResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomPayPalResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomPayPalResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomPayPalResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomPayPalResponseProperties.Data.FraudStatus,
                    Id = createRandomPayPalResponseProperties.Data.Id,
                    Ip = createRandomPayPalResponseProperties.Data.Ip,
                    MerchantFee = createRandomPayPalResponseProperties.Data.MerchantFee,
                    Narration = createRandomPayPalResponseProperties.Data.Narration,
                    PaymentType = createRandomPayPalResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomPayPalResponseProperties.Data.ProcessorResponse,
                    Status = createRandomPayPalResponseProperties.Data.Status,

                    Customer = new ExternalPayPalResponse.Customer
                    {
                        Id = createRandomPayPalResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomPayPalResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomPayPalResponseProperties.Data.Customer.Email,
                        Name = createRandomPayPalResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomPayPalResponseProperties.Data.Customer.PhoneNumber
                    }
                },

                Message = createRandomPayPalResponseProperties.Message,
                Status = createRandomPayPalResponseProperties.Status,

            };


            var randomPayPalRequest = new PayPalRequest
            {
                Amount = createRandomPayPalRequestProperties.Amount,
                Currency = createRandomPayPalRequestProperties.Currency,
                Email = createRandomPayPalRequestProperties.Email,
                BillingAddress = createRandomPayPalRequestProperties.BillingAddress,
                BillingCity = createRandomPayPalRequestProperties.BillingCity,
                BillingCountry = createRandomPayPalRequestProperties.BillingCountry,
                BillingState = createRandomPayPalRequestProperties.BillingState,
                BillingZip = createRandomPayPalRequestProperties.BillingZip,
                ClientIp = createRandomPayPalRequestProperties.ClientIp,
                Country = createRandomPayPalRequestProperties.Country,
                DeviceFingerprint = createRandomPayPalRequestProperties.DeviceFingerprint,
                FullName = createRandomPayPalRequestProperties.Fullname,
                PhoneNumber = createRandomPayPalRequestProperties.PhoneNumber,
                ShippingAddress = createRandomPayPalRequestProperties.ShippingAddress,
                ShippingCity = createRandomPayPalRequestProperties.ShippingCity,
                ShippingCountry = createRandomPayPalRequestProperties.ShippingCountry,
                ShippingName = createRandomPayPalRequestProperties.ShippingName,
                ShippingState = createRandomPayPalRequestProperties.ShippingState,
                ShippingZip = createRandomPayPalRequestProperties.ShippingZip,
                RedirectUrl = createRandomPayPalRequestProperties.RedirectUrl,
                TxRef = createRandomPayPalRequestProperties.TxRef,

            };

            var randomPayPalResponse = new PayPalResponse
            {
                Data = new PayPalResponse.PayPalData
                {
                    TxRef = createRandomPayPalResponseProperties.Data.TxRef,
                    Currency = createRandomPayPalResponseProperties.Data.Currency,
                    AccountId = createRandomPayPalResponseProperties.Data.AccountId,
                    Amount = createRandomPayPalResponseProperties.Data.Amount,
                    AppFee = createRandomPayPalResponseProperties.Data.AppFee,
                    AuthModel = createRandomPayPalResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomPayPalResponseProperties.Data.AuthUrl,
                    Meta = new PayPalResponse.Meta
                    {
                        Authorization = new PayPalResponse.Authorization
                        {
                            Mode = createRandomPayPalResponseProperties.Data.Meta.Mode,
                            Redirect = createRandomPayPalResponseProperties.Data.Meta.Redirect
                        }
                    },
                    ChargedAmount = createRandomPayPalResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomPayPalResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomPayPalResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomPayPalResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomPayPalResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomPayPalResponseProperties.Data.FraudStatus,
                    Id = createRandomPayPalResponseProperties.Data.Id,
                    Ip = createRandomPayPalResponseProperties.Data.Ip,
                    MerchantFee = createRandomPayPalResponseProperties.Data.MerchantFee,
                    Narration = createRandomPayPalResponseProperties.Data.Narration,
                    PaymentType = createRandomPayPalResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomPayPalResponseProperties.Data.ProcessorResponse,
                    Status = createRandomPayPalResponseProperties.Data.Status,

                    Customer = new PayPalResponse.Customer
                    {
                        Id = createRandomPayPalResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomPayPalResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomPayPalResponseProperties.Data.Customer.Email,
                        Name = createRandomPayPalResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomPayPalResponseProperties.Data.Customer.PhoneNumber,

                    }
                },

                Message = createRandomPayPalResponseProperties.Message,
                Status = createRandomPayPalResponseProperties.Status,

            };


            var randomPayPal = new PayPal
            {
                Request = randomPayPalRequest,
            };

            PayPal inputPayPal = randomPayPal;
            PayPal expectedPayPal = inputPayPal.DeepClone();
            expectedPayPal.Response = randomPayPalResponse;

            ExternalPayPalRequest mappedExternalPayPalRequest =
               randomExternalPayPalRequest;

            ExternalPayPalResponse returnedExternalPayPalResponse =
                randomExternalPayPalResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargePayPalAsync(It.Is(
                      SameExternalPayPalRequestAs(mappedExternalPayPalRequest))))
                     .ReturnsAsync(returnedExternalPayPalResponse);

            // when
            PayPal actualCreatePayPal =
               await this.chargeService.PostChargePayPalRequestAsync(inputPayPal);

            // then
            actualCreatePayPal.Should().BeEquivalentTo(expectedPayPal);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargePayPalAsync(It.Is(
                   SameExternalPayPalRequestAs(mappedExternalPayPalRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}