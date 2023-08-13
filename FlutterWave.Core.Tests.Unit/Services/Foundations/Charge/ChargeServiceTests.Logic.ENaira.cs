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
        public async Task ShouldPostENairaWithENairaRequestAsync()
        {
            // given 



            dynamic createRandomENairaRequestProperties =
              CreateRandomENairaRequestProperties();

            dynamic createRandomENairaResponseProperties =
                CreateRandomENairaResponseProperties();


            var randomExternalENairaRequest = new ExternalENairaRequest
            {
                Amount = createRandomENairaRequestProperties.Amount,
                Fullname = createRandomENairaRequestProperties.Fullname,
                Currency = createRandomENairaRequestProperties.Currency,
                PhoneNumber = createRandomENairaRequestProperties.PhoneNumber,
                Email = createRandomENairaRequestProperties.Email,
                RedirectUrl = createRandomENairaRequestProperties.RedirectUrl,
                TxRef = createRandomENairaRequestProperties.TxRef,

            };

            var randomExternalENairaResponse = new ExternalENairaResponse
            {
                Data = new ExternalENairaResponse.ExternalENairaData
                {
                    TxRef = createRandomENairaResponseProperties.Data.TxRef,
                    Currency = createRandomENairaResponseProperties.Data.Currency,
                    AccountId = createRandomENairaResponseProperties.Data.AccountId,
                    Amount = createRandomENairaResponseProperties.Data.Amount,
                    AppFee = createRandomENairaResponseProperties.Data.AppFee,
                    AuthModel = createRandomENairaResponseProperties.Data.AuthModel,
                    Meta = new ExternalENairaResponse.Meta
                    {
                        Authorization = new ExternalENairaResponse.Authorization
                        {
                            Redirect = createRandomENairaResponseProperties.Data.Meta.Authorization.Redirect,
                            Mode = createRandomENairaResponseProperties.Data.Meta.Authorization.Mode
                        }
                    },
                    ChargedAmount = createRandomENairaResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomENairaResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomENairaResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomENairaResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomENairaResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomENairaResponseProperties.Data.FraudStatus,
                    Id = createRandomENairaResponseProperties.Data.Id,
                    Ip = createRandomENairaResponseProperties.Data.Ip,
                    MerchantFee = createRandomENairaResponseProperties.Data.MerchantFee,
                    Narration = createRandomENairaResponseProperties.Data.Narration,
                    PaymentType = createRandomENairaResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomENairaResponseProperties.Data.ProcessorResponse,
                    Status = createRandomENairaResponseProperties.Data.Status,
                    Customer = new ExternalENairaResponse.Customer
                    {
                        Id = createRandomENairaResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomENairaResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomENairaResponseProperties.Data.Customer.Email,
                        Name = createRandomENairaResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomENairaResponseProperties.Data.Customer.PhoneNumber
                    }
                },

                Message = createRandomENairaResponseProperties.Message,
                Status = createRandomENairaResponseProperties.Status,

            };


            var randomENairaRequest = new ENairaRequest
            {

                Amount = createRandomENairaRequestProperties.Amount,
                FullName = createRandomENairaRequestProperties.Fullname,
                Currency = createRandomENairaRequestProperties.Currency,
                PhoneNumber = createRandomENairaRequestProperties.PhoneNumber,
                Email = createRandomENairaRequestProperties.Email,
                RedirectUrl = createRandomENairaRequestProperties.RedirectUrl,
                TxRef = createRandomENairaRequestProperties.TxRef,

            };

            var randomENairaResponse = new ENairaResponse
            {
                Data = new ENairaResponse.ENairaData
                {
                    TxRef = createRandomENairaResponseProperties.Data.TxRef,
                    Currency = createRandomENairaResponseProperties.Data.Currency,
                    AccountId = createRandomENairaResponseProperties.Data.AccountId,
                    Amount = createRandomENairaResponseProperties.Data.Amount,
                    AppFee = createRandomENairaResponseProperties.Data.AppFee,
                    AuthModel = createRandomENairaResponseProperties.Data.AuthModel,
                    Meta = new ENairaResponse.Meta
                    {
                        Authorization = new ENairaResponse.Authorization
                        {
                            Redirect = createRandomENairaResponseProperties.Data.Meta.Authorization.Redirect,
                            Mode = createRandomENairaResponseProperties.Data.Meta.Authorization.Mode
                        }
                    },
                    ChargedAmount = createRandomENairaResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomENairaResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomENairaResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomENairaResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomENairaResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomENairaResponseProperties.Data.FraudStatus,
                    Id = createRandomENairaResponseProperties.Data.Id,
                    Ip = createRandomENairaResponseProperties.Data.Ip,
                    MerchantFee = createRandomENairaResponseProperties.Data.MerchantFee,
                    Narration = createRandomENairaResponseProperties.Data.Narration,
                    PaymentType = createRandomENairaResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomENairaResponseProperties.Data.ProcessorResponse,
                    Status = createRandomENairaResponseProperties.Data.Status,
                    Customer = new ENairaResponse.Customer
                    {
                        Id = createRandomENairaResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomENairaResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomENairaResponseProperties.Data.Customer.Email,
                        Name = createRandomENairaResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomENairaResponseProperties.Data.Customer.PhoneNumber
                    }
                },

                Message = createRandomENairaResponseProperties.Message,
                Status = createRandomENairaResponseProperties.Status,

            };


            var randomENaira = new ENaira
            {
                Request = randomENairaRequest,
            };

            ENaira inputENaira = randomENaira;
            ENaira expectedENaira = inputENaira.DeepClone();
            expectedENaira.Response = randomENairaResponse;

            ExternalENairaRequest mappedExternalENairaRequest =
               randomExternalENairaRequest;

            ExternalENairaResponse returnedExternalENairaResponse =
                randomExternalENairaResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeENairaAsync(It.Is(
                      SameExternalENairaRequestAs(mappedExternalENairaRequest))))
                     .ReturnsAsync(returnedExternalENairaResponse);

            // when
            ENaira actualCreateENaira =
               await this.chargeService.PostChargeENairaRequestAsync(inputENaira);

            // then
            actualCreateENaira.Should().BeEquivalentTo(expectedENaira);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeENairaAsync(It.Is(
                   SameExternalENairaRequestAs(mappedExternalENairaRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}