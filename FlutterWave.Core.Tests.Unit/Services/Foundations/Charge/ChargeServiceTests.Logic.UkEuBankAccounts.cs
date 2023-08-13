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
        public async Task ShouldPostUkEuBankAccountsWithUkEuBankAccountsRequestAsync()
        {
            // given 



            dynamic createRandomUkEuBankAccountsRequestProperties =
              CreateRandomUkEuBankAccountsRequestProperties();

            dynamic createRandomUkEuBankAccountsResponseProperties =
                CreateRandomUkEuBankAccountsResponseProperties();


            var randomExternalUkEuBankAccountsRequest = new ExternalUkEuBankAccountsRequest
            {
                Amount = createRandomUkEuBankAccountsRequestProperties.Amount,
                IsTokenIo = createRandomUkEuBankAccountsRequestProperties.IsTokenIo,
                Currency = createRandomUkEuBankAccountsRequestProperties.Currency,
                FullName = createRandomUkEuBankAccountsRequestProperties.Fullname,
                Email = createRandomUkEuBankAccountsRequestProperties.Email,
                PhoneNumber = createRandomUkEuBankAccountsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomUkEuBankAccountsRequestProperties.RedirectUrl,
                TxRef = createRandomUkEuBankAccountsRequestProperties.TxRef,

            };

            var randomExternalUkEuBankAccountsResponse = new ExternalUkEuBankAccountsResponse
            {
                Data = new ExternalUkEuBankAccountsResponse.ExternalUkEuBankAccountsData
                {

                    TxRef = createRandomUkEuBankAccountsResponseProperties.Data.TxRef,
                    Currency = createRandomUkEuBankAccountsResponseProperties.Data.Currency,
                    AccountId = createRandomUkEuBankAccountsResponseProperties.Data.AccountId,
                    Amount = createRandomUkEuBankAccountsResponseProperties.Data.Amount,
                    AppFee = createRandomUkEuBankAccountsResponseProperties.Data.AppFee,
                    AuthModel = createRandomUkEuBankAccountsResponseProperties.Data.AuthModel,
                    ChargedAmount = createRandomUkEuBankAccountsResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomUkEuBankAccountsResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomUkEuBankAccountsResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomUkEuBankAccountsResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomUkEuBankAccountsResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomUkEuBankAccountsResponseProperties.Data.FraudStatus,
                    Id = createRandomUkEuBankAccountsResponseProperties.Data.Id,
                    Ip = createRandomUkEuBankAccountsResponseProperties.Data.Ip,
                    MerchantFee = createRandomUkEuBankAccountsResponseProperties.Data.MerchantFee,
                    Narration = createRandomUkEuBankAccountsResponseProperties.Data.Narration,
                    PaymentType = createRandomUkEuBankAccountsResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomUkEuBankAccountsResponseProperties.Data.ProcessorResponse,
                    Status = createRandomUkEuBankAccountsResponseProperties.Data.Status,
                    Customer = new ExternalUkEuBankAccountsResponse.Customer
                    {
                        Id = createRandomUkEuBankAccountsResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomUkEuBankAccountsResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomUkEuBankAccountsResponseProperties.Data.Customer.Email,
                        Name = createRandomUkEuBankAccountsResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomUkEuBankAccountsResponseProperties.Data.Customer.PhoneNumber
                    }
                },
                Meta = new ExternalUkEuBankAccountsResponse.ExternalUkEuBankAccountsMeta
                {
                    Authorization = new ExternalUkEuBankAccountsResponse.Authorization
                    {
                        Redirect = createRandomUkEuBankAccountsResponseProperties.Meta.Authorization.Redirect,
                        Mode = createRandomUkEuBankAccountsResponseProperties.Meta.Authorization.Mode

                    }
                },
                Message = createRandomUkEuBankAccountsResponseProperties.Message,
                Status = createRandomUkEuBankAccountsResponseProperties.Status,

            };


            var randomUkEuBankAccountsRequest = new UkEuBankAccountsRequest
            {
                Amount = createRandomUkEuBankAccountsRequestProperties.Amount,
                IsTokenIo = createRandomUkEuBankAccountsRequestProperties.IsTokenIo,
                Currency = createRandomUkEuBankAccountsRequestProperties.Currency,
                FullName = createRandomUkEuBankAccountsRequestProperties.Fullname,
                Email = createRandomUkEuBankAccountsRequestProperties.Email,
                PhoneNumber = createRandomUkEuBankAccountsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomUkEuBankAccountsRequestProperties.RedirectUrl,
                TxRef = createRandomUkEuBankAccountsRequestProperties.TxRef,

            };

            var randomUkEuBankAccountsResponse = new UkEuBankAccountsResponse
            {
                Data = new UkEuBankAccountsResponse.UkEuBankAccountsData
                {

                    TxRef = createRandomUkEuBankAccountsResponseProperties.Data.TxRef,
                    Currency = createRandomUkEuBankAccountsResponseProperties.Data.Currency,
                    AccountId = createRandomUkEuBankAccountsResponseProperties.Data.AccountId,
                    Amount = createRandomUkEuBankAccountsResponseProperties.Data.Amount,
                    AppFee = createRandomUkEuBankAccountsResponseProperties.Data.AppFee,
                    AuthModel = createRandomUkEuBankAccountsResponseProperties.Data.AuthModel,
                    ChargedAmount = createRandomUkEuBankAccountsResponseProperties.Data.ChargedAmount,
                    ChargeType = createRandomUkEuBankAccountsResponseProperties.Data.ChargeType,
                    CreatedAt = createRandomUkEuBankAccountsResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomUkEuBankAccountsResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomUkEuBankAccountsResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomUkEuBankAccountsResponseProperties.Data.FraudStatus,
                    Id = createRandomUkEuBankAccountsResponseProperties.Data.Id,
                    Ip = createRandomUkEuBankAccountsResponseProperties.Data.Ip,
                    MerchantFee = createRandomUkEuBankAccountsResponseProperties.Data.MerchantFee,
                    Narration = createRandomUkEuBankAccountsResponseProperties.Data.Narration,
                    PaymentType = createRandomUkEuBankAccountsResponseProperties.Data.PaymentType,
                    ProcessorResponse = createRandomUkEuBankAccountsResponseProperties.Data.ProcessorResponse,
                    Status = createRandomUkEuBankAccountsResponseProperties.Data.Status,
                    Customer = new UkEuBankAccountsResponse.Customer
                    {
                        Id = createRandomUkEuBankAccountsResponseProperties.Data.Customer.Id,
                        CreatedAt = createRandomUkEuBankAccountsResponseProperties.Data.Customer.CreatedAt,
                        Email = createRandomUkEuBankAccountsResponseProperties.Data.Customer.Email,
                        Name = createRandomUkEuBankAccountsResponseProperties.Data.Customer.Name,
                        PhoneNumber = createRandomUkEuBankAccountsResponseProperties.Data.Customer.PhoneNumber
                    }
                },
                Meta = new UkEuBankAccountsResponse.UkEuBankAccountsMeta
                {
                    Authorization = new UkEuBankAccountsResponse.Authorization
                    {
                        Redirect = createRandomUkEuBankAccountsResponseProperties.Meta.Authorization.Redirect,
                        Mode = createRandomUkEuBankAccountsResponseProperties.Meta.Authorization.Mode

                    }
                },
                Message = createRandomUkEuBankAccountsResponseProperties.Message,
                Status = createRandomUkEuBankAccountsResponseProperties.Status,

            };


            var randomUkEuBankAccounts = new UkEuBankAccounts
            {
                Request = randomUkEuBankAccountsRequest,
            };

            UkEuBankAccounts inputUkEuBankAccounts = randomUkEuBankAccounts;
            UkEuBankAccounts expectedUkEuBankAccounts = inputUkEuBankAccounts.DeepClone();
            expectedUkEuBankAccounts.Response = randomUkEuBankAccountsResponse;

            ExternalUkEuBankAccountsRequest mappedExternalUkEuBankAccountsRequest =
               randomExternalUkEuBankAccountsRequest;

            ExternalUkEuBankAccountsResponse returnedExternalUkEuBankAccountsResponse =
                randomExternalUkEuBankAccountsResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeUkEuBankAccountsAsync(It.Is(
                      SameExternalUkEuBankAccountsRequestAs(mappedExternalUkEuBankAccountsRequest))))
                     .ReturnsAsync(returnedExternalUkEuBankAccountsResponse);

            // when
            UkEuBankAccounts actualCreateUkEuBankAccounts =
               await this.chargeService.PostChargeUkEuBankAccountsRequestAsync(inputUkEuBankAccounts);

            // then
            actualCreateUkEuBankAccounts.Should().BeEquivalentTo(expectedUkEuBankAccounts);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeUkEuBankAccountsAsync(It.Is(
                   SameExternalUkEuBankAccountsRequestAs(mappedExternalUkEuBankAccountsRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}