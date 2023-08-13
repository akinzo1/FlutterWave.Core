



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldPostCreateRefundWithCreateRefundRequestAsync()
        {
            // given 



            dynamic createRandomCreatePreauthorizationRefundRequestProperties =
              CreateRandomCreatePreauthorizationRefundRequestProperties();

            dynamic createRandomCreatePreauthorizationRefundResponseProperties =
                CreateRandomCreatePreauthorizationRefundResponseProperties();


            var randomExternalCreateRefundRequest = new ExternalCreatePreauthorizationRefundRequest
            {

                Amount = createRandomCreatePreauthorizationRefundRequestProperties.Amount,

            };

            var randomExternalCreateRefundResponse = new ExternalCreatePreauthorizationRefundResponse
            {
                Data = new ExternalCreatePreauthorizationRefundResponse.ExternalCreatePreauthorizationRefundData
                {
                    CreatedAt = createRandomCreatePreauthorizationRefundResponseProperties.Data.CreatedAt,
                    Amount = createRandomCreatePreauthorizationRefundResponseProperties.Data.Amount,
                    AccountId = createRandomCreatePreauthorizationRefundResponseProperties.Data.AccountId,
                    AppFee = createRandomCreatePreauthorizationRefundResponseProperties.Data.AppFee,
                    AuthModel = createRandomCreatePreauthorizationRefundResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomCreatePreauthorizationRefundResponseProperties.Data.AuthUrl,
                    Card = new ExternalCreatePreauthorizationRefundResponse.Card
                    {
                        Country = createRandomCreatePreauthorizationRefundResponseProperties.Data.Card.Country,
                        Expiry = createRandomCreatePreauthorizationRefundResponseProperties.Data.Card.Expiry,
                        First6digits = createRandomCreatePreauthorizationRefundResponseProperties.Data.Card.First6digits,
                        Issuer = createRandomCreatePreauthorizationRefundResponseProperties.Data.Card.Issuer,
                        Last4digits = createRandomCreatePreauthorizationRefundResponseProperties.Data.Card.Last4digits,
                        Type = createRandomCreatePreauthorizationRefundResponseProperties.Data.Card.Type,
                    },
                    ChargedAmount = createRandomCreatePreauthorizationRefundResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomCreatePreauthorizationRefundResponseProperties.Data.ChargeType,
                    Currency = createRandomCreatePreauthorizationRefundResponseProperties.Data.Currency,
                    DeviceFingerprint = createRandomCreatePreauthorizationRefundResponseProperties.Data.DeviceFingerprint,
                    Customer = new ExternalCreatePreauthorizationRefundResponse.Customer
                    {
                        CreatedAt = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.Email,
                        Id = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.Id,
                        AccountId = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.AccountId,
                        Customertoken = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.Customertoken,
                        DeletedAt = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.DeletedAt,
                        FullName = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.FullName,
                        Phone = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.Phone,
                        UpdatedAt = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.UpdatedAt,



                    },
                    Id = createRandomCreatePreauthorizationRefundResponseProperties.Data.Id,
                    FlwRef = createRandomCreatePreauthorizationRefundResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomCreatePreauthorizationRefundResponseProperties.Data.FraudStatus,
                    Ip = createRandomCreatePreauthorizationRefundResponseProperties.Data.Ip,
                    MerchantFee = createRandomCreatePreauthorizationRefundResponseProperties.Data.MerchantFee,
                    Narration = createRandomCreatePreauthorizationRefundResponseProperties.Data.Narration,
                    PaymentType = createRandomCreatePreauthorizationRefundResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomCreatePreauthorizationRefundResponseProperties.Data.ProcessorResponse,
                    Status = createRandomCreatePreauthorizationRefundResponseProperties.Data.Status,
                    TxRef = createRandomCreatePreauthorizationRefundResponseProperties.Data.TxRef



                },
                Message = createRandomCreatePreauthorizationRefundResponseProperties.Message,
                Status = createRandomCreatePreauthorizationRefundResponseProperties.Status,

            };


            var randomCreateRefundRequest = new CreatePreauthorizationRefundRequest
            {
                Amount = createRandomCreatePreauthorizationRefundRequestProperties.Amount,


            };

            var randomCreateRefundResponse = new CreatePreauthorizationRefundResponse
            {

                Data = new CreatePreauthorizationRefundResponse.CreatePreauthorizationRefundData
                {
                    CreatedAt = createRandomCreatePreauthorizationRefundResponseProperties.Data.CreatedAt,
                    Amount = createRandomCreatePreauthorizationRefundResponseProperties.Data.Amount,
                    AccountId = createRandomCreatePreauthorizationRefundResponseProperties.Data.AccountId,
                    AppFee = createRandomCreatePreauthorizationRefundResponseProperties.Data.AppFee,
                    AuthModel = createRandomCreatePreauthorizationRefundResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomCreatePreauthorizationRefundResponseProperties.Data.AuthUrl,
                    Card = new CreatePreauthorizationRefundResponse.Card
                    {
                        Country = createRandomCreatePreauthorizationRefundResponseProperties.Data.Card.Country,
                        Expiry = createRandomCreatePreauthorizationRefundResponseProperties.Data.Card.Expiry,
                        First6digits = createRandomCreatePreauthorizationRefundResponseProperties.Data.Card.First6digits,
                        Issuer = createRandomCreatePreauthorizationRefundResponseProperties.Data.Card.Issuer,
                        Last4digits = createRandomCreatePreauthorizationRefundResponseProperties.Data.Card.Last4digits,
                        Type = createRandomCreatePreauthorizationRefundResponseProperties.Data.Card.Type,

                    },
                    ChargedAmount = createRandomCreatePreauthorizationRefundResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomCreatePreauthorizationRefundResponseProperties.Data.ChargeType,
                    Currency = createRandomCreatePreauthorizationRefundResponseProperties.Data.Currency,
                    DeviceFingerprint = createRandomCreatePreauthorizationRefundResponseProperties.Data.DeviceFingerprint,
                    Customer = new CreatePreauthorizationRefundResponse.Customer
                    {
                        CreatedAt = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.Email,
                        Id = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.Id,
                        AccountId = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.AccountId,
                        Customertoken = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.Customertoken,
                        DeletedAt = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.DeletedAt,
                        FullName = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.FullName,
                        Phone = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.Phone,
                        UpdatedAt = createRandomCreatePreauthorizationRefundResponseProperties.Data.Customer.UpdatedAt,



                    },
                    Id = createRandomCreatePreauthorizationRefundResponseProperties.Data.Id,
                    FlwRef = createRandomCreatePreauthorizationRefundResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomCreatePreauthorizationRefundResponseProperties.Data.FraudStatus,
                    Ip = createRandomCreatePreauthorizationRefundResponseProperties.Data.Ip,
                    MerchantFee = createRandomCreatePreauthorizationRefundResponseProperties.Data.MerchantFee,
                    Narration = createRandomCreatePreauthorizationRefundResponseProperties.Data.Narration,
                    PaymentType = createRandomCreatePreauthorizationRefundResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomCreatePreauthorizationRefundResponseProperties.Data.ProcessorResponse,
                    Status = createRandomCreatePreauthorizationRefundResponseProperties.Data.Status,
                    TxRef = createRandomCreatePreauthorizationRefundResponseProperties.Data.TxRef



                },
                Message = createRandomCreatePreauthorizationRefundResponseProperties.Message,
                Status = createRandomCreatePreauthorizationRefundResponseProperties.Status,
            };


            var randomCreateRefund = new CreatePreauthorizationRefund
            {
                Request = randomCreateRefundRequest,
            };

            var randomSubaccountId = GetRandomString();

            CreatePreauthorizationRefund inputCreatePreauthorizationRefund = randomCreateRefund;
            CreatePreauthorizationRefund expectedCreatePreauthorizationRefund = inputCreatePreauthorizationRefund.DeepClone();
            expectedCreatePreauthorizationRefund.Response = randomCreateRefundResponse;

            ExternalCreatePreauthorizationRefundRequest mappedExternalCreatePreauthorizationRefundRequest =
               randomExternalCreateRefundRequest;

            ExternalCreatePreauthorizationRefundResponse returnedExternalCreatePreauthorizationRefundResponse =
                randomExternalCreateRefundResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateRefundAsync(It.IsAny<string>(), It.Is(
                      SameExternalCreatePreauthorizationRefundRequestAs(mappedExternalCreatePreauthorizationRefundRequest))))
                     .ReturnsAsync(returnedExternalCreatePreauthorizationRefundResponse);

            // when
            CreatePreauthorizationRefund actualCreateCreateRefund =
               await this.preauthorizationService.PostCreateRefundRequestAsync(randomSubaccountId, inputCreatePreauthorizationRefund);

            // then
            actualCreateCreateRefund.Should().BeEquivalentTo(expectedCreatePreauthorizationRefund);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreateRefundAsync(It.IsAny<string>(), It.Is(
                   SameExternalCreatePreauthorizationRefundRequestAs(mappedExternalCreatePreauthorizationRefundRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}