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
        public async Task ShouldPostFawryWithFawryRequestAsync()
        {
            // given 



            dynamic createRandomFawryRequestProperties =
              CreateRandomFawryRequestProperties();

            dynamic createRandomFawryResponseProperties =
                CreateRandomFawryResponseProperties();


            var randomExternalFawryRequest = new ExternalFawryRequest
            {
                Amount = createRandomFawryRequestProperties.Amount,
                Meta = new ExternalFawryRequest.ExternalFawryMeta
                {
                    Name = createRandomFawryRequestProperties.Meta.Name,
                    Tools = createRandomFawryRequestProperties.Meta.Tools
                },

                Currency = createRandomFawryRequestProperties.Currency,
                Email = createRandomFawryRequestProperties.Email,
                PhoneNumber = createRandomFawryRequestProperties.PhoneNumber,
                RedirectUrl = createRandomFawryRequestProperties.RedirectUrl,
                TxRef = createRandomFawryRequestProperties.TxRef,

            };

            var randomExternalFawryResponse = new ExternalFawryResponse
            {
                Data = new ExternalFawryResponse.ExternalFawryData
                {
                    TxRef = createRandomFawryResponseProperties.Data.TxRef,
                    Currency = createRandomFawryResponseProperties.Data.Currency,
                    AccountId = createRandomFawryResponseProperties.Data.AccountId,
                    Amount = createRandomFawryResponseProperties.Data.Amount,
                    AppFee = createRandomFawryResponseProperties.Data.AppFee,
                    AuthUrl = createRandomFawryResponseProperties.Data.AuthUrl,
                    OrderRef = createRandomFawryResponseProperties.Data.OrderRef,
                    ChargedAmount = createRandomFawryResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomFawryResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomFawryResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomFawryResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomFawryResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomFawryResponseProperties.Data.FraudStatus,
                    Id = createRandomFawryResponseProperties.Data.Id,
                    MerchantFee = createRandomFawryResponseProperties.Data.MerchantFee,
                    Narration = createRandomFawryResponseProperties.Data.Narration,
                    PaymentType = createRandomFawryResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomFawryResponseProperties.Data.ProcessorResponse,
                    Status = createRandomFawryResponseProperties.Data.Status,

                    Customer = new ExternalFawryResponse.Customer
                    {
                        Id = createRandomFawryResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomFawryResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomFawryResponseProperties.Data.Customer.Email,
                        Name = createRandomFawryResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomFawryResponseProperties.Data.Customer.PhoneNumber,

                    }
                },
                Meta = new ExternalFawryResponse.ExternalFawryMeta
                {
                    Authorization = new ExternalFawryResponse.Authorization
                    {
                        Instruction = createRandomFawryResponseProperties.Meta.Authorization.Instruction,
                        Mode = createRandomFawryResponseProperties.Meta.Authorization.Mode

                    }
                },
                Message = createRandomFawryResponseProperties.Message,
                Status = createRandomFawryResponseProperties.Status,

            };


            var randomFawryRequest = new FawryRequest
            {
                Amount = createRandomFawryRequestProperties.Amount,
                Meta = new FawryRequest.FawryMeta
                {
                    Name = createRandomFawryRequestProperties.Meta.Name,
                    Tools = createRandomFawryRequestProperties.Meta.Tools
                },

                Currency = createRandomFawryRequestProperties.Currency,
                Email = createRandomFawryRequestProperties.Email,
                PhoneNumber = createRandomFawryRequestProperties.PhoneNumber,
                RedirectUrl = createRandomFawryRequestProperties.RedirectUrl,
                TxRef = createRandomFawryRequestProperties.TxRef,

            };

            var randomFawryResponse = new FawryResponse
            {
                Data = new FawryResponse.FawryData
                {
                    TxRef = createRandomFawryResponseProperties.Data.TxRef,
                    Currency = createRandomFawryResponseProperties.Data.Currency,
                    AccountId = createRandomFawryResponseProperties.Data.AccountId,
                    Amount = createRandomFawryResponseProperties.Data.Amount,
                    AppFee = createRandomFawryResponseProperties.Data.AppFee,
                    AuthUrl = createRandomFawryResponseProperties.Data.AuthUrl,
                    OrderRef = createRandomFawryResponseProperties.Data.OrderRef,
                    ChargedAmount = createRandomFawryResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomFawryResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomFawryResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomFawryResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomFawryResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomFawryResponseProperties.Data.FraudStatus,
                    Id = createRandomFawryResponseProperties.Data.Id,
                    MerchantFee = createRandomFawryResponseProperties.Data.MerchantFee,
                    Narration = createRandomFawryResponseProperties.Data.Narration,
                    PaymentType = createRandomFawryResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomFawryResponseProperties.Data.ProcessorResponse,
                    Status = createRandomFawryResponseProperties.Data.Status,

                    Customer = new FawryResponse.Customer
                    {
                        Id = createRandomFawryResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomFawryResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomFawryResponseProperties.Data.Customer.Email,
                        Name = createRandomFawryResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomFawryResponseProperties.Data.Customer.PhoneNumber,

                    }
                },
                Meta = new FawryResponse.FawryMeta
                {
                    Authorization = new FawryResponse.Authorization
                    {
                        Instruction = createRandomFawryResponseProperties.Meta.Authorization.Instruction,
                        Mode = createRandomFawryResponseProperties.Meta.Authorization.Mode

                    }
                },
                Message = createRandomFawryResponseProperties.Message,
                Status = createRandomFawryResponseProperties.Status,

            };


            var randomFawry = new Fawry
            {
                Request = randomFawryRequest,
            };

            Fawry inputFawry = randomFawry;
            Fawry expectedFawry = inputFawry.DeepClone();
            expectedFawry.Response = randomFawryResponse;

            ExternalFawryRequest mappedExternalFawryRequest =
               randomExternalFawryRequest;

            ExternalFawryResponse returnedExternalFawryResponse =
                randomExternalFawryResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeFawryAsync(It.Is(
                      SameExternalFawryRequestAs(mappedExternalFawryRequest))))
                     .ReturnsAsync(returnedExternalFawryResponse);

            // when
            Fawry actualCreateFawry =
               await this.chargeService.PostChargeFawryRequestAsync(inputFawry);

            // then
            actualCreateFawry.Should().BeEquivalentTo(expectedFawry);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeFawryAsync(It.Is(
                   SameExternalFawryRequestAs(mappedExternalFawryRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}