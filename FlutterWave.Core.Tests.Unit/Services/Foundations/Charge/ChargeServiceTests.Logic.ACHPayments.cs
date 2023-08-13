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
        public async Task ShouldPostACHPaymentsWithACHPaymentsRequestAsync()
        {
            // given 



            dynamic createRandomACHPaymentsRequestProperties =
              CreateRandomACHPaymentsRequestProperties();

            dynamic createRandomACHPaymentsResponseProperties =
                CreateRandomACHPaymentsResponseProperties();


            var randomExternalACHPaymentsRequest = new ExternalACHPaymentsRequest
            {
                Amount = createRandomACHPaymentsRequestProperties.Amount,
                Meta = new ExternalACHPaymentsRequest.ExternalACHPaymentsMeta
                {
                    FlightID = createRandomACHPaymentsRequestProperties.Meta.FlightID,
                },
                ClientIp = createRandomACHPaymentsRequestProperties.ClientIp,
                Country = createRandomACHPaymentsRequestProperties.Country,
                Currency = createRandomACHPaymentsRequestProperties.Currency,
                DeviceFingerprint = createRandomACHPaymentsRequestProperties.DeviceFingerprint,
                Email = createRandomACHPaymentsRequestProperties.Email,
                FullName = createRandomACHPaymentsRequestProperties.Fullname,
                PhoneNumber = createRandomACHPaymentsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomACHPaymentsRequestProperties.RedirectUrl,
                TxRef = createRandomACHPaymentsRequestProperties.TxRef,

            };

            var randomExternalACHPaymentsResponse = new ExternalACHPaymentsResponse
            {
                Data = new ExternalACHPaymentsResponse.ExternalACHPaymentsData
                {
                    TxRef = createRandomACHPaymentsResponseProperties.Data.TxRef,
                    Currency = createRandomACHPaymentsResponseProperties.Data.Currency,
                    AccountId = createRandomACHPaymentsResponseProperties.Data.AccountId,
                    Amount = createRandomACHPaymentsResponseProperties.Data.Amount,
                    AppFee = createRandomACHPaymentsResponseProperties.Data.AppFee,
                    AuthModel = createRandomACHPaymentsResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomACHPaymentsResponseProperties.Data.AuthUrl,
                    RedirectUrl = createRandomACHPaymentsResponseProperties.Data.RedirectUrl,
                    ChargedAmount = createRandomACHPaymentsResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomACHPaymentsResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomACHPaymentsResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomACHPaymentsResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomACHPaymentsResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomACHPaymentsResponseProperties.Data.FraudStatus,
                    Id = createRandomACHPaymentsResponseProperties.Data.Id,
                    Ip = createRandomACHPaymentsResponseProperties.Data.Ip,
                    MerchantFee = createRandomACHPaymentsResponseProperties.Data.MerchantFee,
                    Narration = createRandomACHPaymentsResponseProperties.Data.Narration,
                    PaymentType = createRandomACHPaymentsResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomACHPaymentsResponseProperties.Data.ProcessorResponse,
                    Status = createRandomACHPaymentsResponseProperties.Data.Status,
                    Customer = new ExternalACHPaymentsResponse.Customer
                    {
                        Id = createRandomACHPaymentsResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomACHPaymentsResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomACHPaymentsResponseProperties.Data.Customer.Email,
                        Name = createRandomACHPaymentsResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomACHPaymentsResponseProperties.Data.Customer.PhoneNumber,

                    }
                },

                Message = createRandomACHPaymentsResponseProperties.Message,
                Status = createRandomACHPaymentsResponseProperties.Status,

            };


            var randomACHPaymentsRequest = new ACHPaymentsRequest
            {
                Amount = createRandomACHPaymentsRequestProperties.Amount,
                Meta = new ACHPaymentsRequest.ACHPaymentsMeta
                {
                    FlightID = createRandomACHPaymentsRequestProperties.Meta.FlightID,
                },
                ClientIp = createRandomACHPaymentsRequestProperties.ClientIp,
                Country = createRandomACHPaymentsRequestProperties.Country,
                Currency = createRandomACHPaymentsRequestProperties.Currency,
                DeviceFingerprint = createRandomACHPaymentsRequestProperties.DeviceFingerprint,
                Email = createRandomACHPaymentsRequestProperties.Email,
                FullName = createRandomACHPaymentsRequestProperties.Fullname,
                PhoneNumber = createRandomACHPaymentsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomACHPaymentsRequestProperties.RedirectUrl,
                TxRef = createRandomACHPaymentsRequestProperties.TxRef,

            };

            var randomACHPaymentsResponse = new ACHPaymentsResponse
            {
                Data = new ACHPaymentsResponse.ACHPaymentsData
                {
                    TxRef = createRandomACHPaymentsResponseProperties.Data.TxRef,
                    Currency = createRandomACHPaymentsResponseProperties.Data.Currency,
                    AccountId = createRandomACHPaymentsResponseProperties.Data.AccountId,
                    Amount = createRandomACHPaymentsResponseProperties.Data.Amount,
                    AppFee = createRandomACHPaymentsResponseProperties.Data.AppFee,
                    AuthModel = createRandomACHPaymentsResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomACHPaymentsResponseProperties.Data.AuthUrl,
                    RedirectUrl = createRandomACHPaymentsResponseProperties.Data.RedirectUrl,
                    ChargedAmount = createRandomACHPaymentsResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomACHPaymentsResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomACHPaymentsResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomACHPaymentsResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomACHPaymentsResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomACHPaymentsResponseProperties.Data.FraudStatus,
                    Id = createRandomACHPaymentsResponseProperties.Data.Id,
                    Ip = createRandomACHPaymentsResponseProperties.Data.Ip,
                    MerchantFee = createRandomACHPaymentsResponseProperties.Data.MerchantFee,
                    Narration = createRandomACHPaymentsResponseProperties.Data.Narration,
                    PaymentType = createRandomACHPaymentsResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomACHPaymentsResponseProperties.Data.ProcessorResponse,
                    Status = createRandomACHPaymentsResponseProperties.Data.Status,
                    Customer = new ACHPaymentsResponse.Customer
                    {
                        Id = createRandomACHPaymentsResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomACHPaymentsResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomACHPaymentsResponseProperties.Data.Customer.Email,
                        Name = createRandomACHPaymentsResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomACHPaymentsResponseProperties.Data.Customer.PhoneNumber,

                    }
                },

                Message = createRandomACHPaymentsResponseProperties.Message,
                Status = createRandomACHPaymentsResponseProperties.Status,

            };


            var randomACHPayments = new ACHPayments
            {
                Request = randomACHPaymentsRequest,
            };

            ACHPayments inputACHPayments = randomACHPayments;
            ACHPayments expectedACHPayments = inputACHPayments.DeepClone();
            expectedACHPayments.Response = randomACHPaymentsResponse;

            ExternalACHPaymentsRequest mappedExternalACHPaymentsRequest =
               randomExternalACHPaymentsRequest;

            ExternalACHPaymentsResponse returnedExternalACHPaymentsResponse =
                randomExternalACHPaymentsResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeACHPaymentsAsync(It.Is(
                      SameExternalACHPaymentsRequestAs(mappedExternalACHPaymentsRequest))))
                     .ReturnsAsync(returnedExternalACHPaymentsResponse);

            // when
            ACHPayments actualCreateACHPayments =
               await this.chargeService.PostChargeACHPaymentsRequestAsync(inputACHPayments);

            // then
            actualCreateACHPayments.Should().BeEquivalentTo(expectedACHPayments);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeACHPaymentsAsync(It.Is(
                   SameExternalACHPaymentsRequestAs(mappedExternalACHPaymentsRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}