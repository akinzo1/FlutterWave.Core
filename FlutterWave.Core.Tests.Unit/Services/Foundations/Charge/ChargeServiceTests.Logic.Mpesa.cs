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
        public async Task ShouldPostMpesaWithMpesaRequestAsync()
        {
            // given 



            dynamic createRandomMpesaRequestProperties =
              CreateRandomMpesaRequestProperties();

            dynamic createRandomMpesaResponseProperties =
                CreateRandomMpesaResponseProperties();


            var randomExternalMpesaRequest = new ExternalMpesaRequest
            {
                Amount = createRandomMpesaRequestProperties.Amount,
                Currency = createRandomMpesaRequestProperties.Currency,
                FullName = createRandomMpesaRequestProperties.Fullname,
                Email = createRandomMpesaRequestProperties.Email,
                PhoneNumber = createRandomMpesaRequestProperties.PhoneNumber,
                TxRef = createRandomMpesaRequestProperties.TxRef,

            };

            var randomExternalMpesaResponse = new ExternalMpesaResponse
            {
                Data = new ExternalMpesaResponse.ExternalMpesaData
                {
                    TxRef = createRandomMpesaResponseProperties.Data.TxRef,
                    Currency = createRandomMpesaResponseProperties.Data.Currency,
                    AccountId = createRandomMpesaResponseProperties.Data.AccountId,
                    Amount = createRandomMpesaResponseProperties.Data.Amount,
                    AppFee = createRandomMpesaResponseProperties.Data.AppFee,
                    AuthModel = createRandomMpesaResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomMpesaResponseProperties.Data.AuthUrl,
                    ChargedAmount = createRandomMpesaResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomMpesaResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomMpesaResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomMpesaResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomMpesaResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomMpesaResponseProperties.Data.FraudStatus,
                    Id = createRandomMpesaResponseProperties.Data.Id,
                    Ip = createRandomMpesaResponseProperties.Data.Ip,
                    MerchantFee = createRandomMpesaResponseProperties.Data.MerchantFee,
                    Narration = createRandomMpesaResponseProperties.Data.Narration,
                    PaymentType = createRandomMpesaResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomMpesaResponseProperties.Data.ProcessorResponse,
                    Status = createRandomMpesaResponseProperties.Data.Status,
                    Customer = new ExternalMpesaResponse.Customer
                    {
                        Id = createRandomMpesaResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomMpesaResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomMpesaResponseProperties.Data.Customer.Email,
                        Name = createRandomMpesaResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomMpesaResponseProperties.Data.Customer.PhoneNumber,

                    }
                },

                Message = createRandomMpesaResponseProperties.Message,
                Status = createRandomMpesaResponseProperties.Status,

            };


            var randomMpesaRequest = new MpesaRequest
            {
                Amount = createRandomMpesaRequestProperties.Amount,
                Currency = createRandomMpesaRequestProperties.Currency,
                FullName = createRandomMpesaRequestProperties.Fullname,
                Email = createRandomMpesaRequestProperties.Email,
                PhoneNumber = createRandomMpesaRequestProperties.PhoneNumber,
                TxRef = createRandomMpesaRequestProperties.TxRef,

            };

            var randomMpesaResponse = new MpesaResponse
            {
                Data = new MpesaResponse.MpesaData
                {
                    TxRef = createRandomMpesaResponseProperties.Data.TxRef,
                    Currency = createRandomMpesaResponseProperties.Data.Currency,
                    AccountId = createRandomMpesaResponseProperties.Data.AccountId,
                    Amount = createRandomMpesaResponseProperties.Data.Amount,
                    AppFee = createRandomMpesaResponseProperties.Data.AppFee,
                    AuthModel = createRandomMpesaResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomMpesaResponseProperties.Data.AuthUrl,
                    ChargedAmount = createRandomMpesaResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomMpesaResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomMpesaResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomMpesaResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomMpesaResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomMpesaResponseProperties.Data.FraudStatus,
                    Id = createRandomMpesaResponseProperties.Data.Id,
                    Ip = createRandomMpesaResponseProperties.Data.Ip,
                    MerchantFee = createRandomMpesaResponseProperties.Data.MerchantFee,
                    Narration = createRandomMpesaResponseProperties.Data.Narration,
                    PaymentType = createRandomMpesaResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomMpesaResponseProperties.Data.ProcessorResponse,
                    Status = createRandomMpesaResponseProperties.Data.Status,
                    Customer = new MpesaResponse.Customer
                    {
                        Id = createRandomMpesaResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomMpesaResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomMpesaResponseProperties.Data.Customer.Email,
                        Name = createRandomMpesaResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomMpesaResponseProperties.Data.Customer.PhoneNumber,

                    }
                },

                Message = createRandomMpesaResponseProperties.Message,
                Status = createRandomMpesaResponseProperties.Status,

            };


            var randomMpesa = new Mpesa
            {
                Request = randomMpesaRequest,
            };

            Mpesa inputMpesa = randomMpesa;
            Mpesa expectedMpesa = inputMpesa.DeepClone();
            expectedMpesa.Response = randomMpesaResponse;

            ExternalMpesaRequest mappedExternalMpesaRequest =
               randomExternalMpesaRequest;

            ExternalMpesaResponse returnedExternalMpesaResponse =
                randomExternalMpesaResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeMpesaAsync(It.Is(
                      SameExternalMpesaRequestAs(mappedExternalMpesaRequest))))
                     .ReturnsAsync(returnedExternalMpesaResponse);

            // when
            Mpesa actualCreateMpesa =
               await this.chargeService.PostChargeMpesaRequestAsync(inputMpesa);

            // then
            actualCreateMpesa.Should().BeEquivalentTo(expectedMpesa);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeMpesaAsync(It.Is(
                   SameExternalMpesaRequestAs(mappedExternalMpesaRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}