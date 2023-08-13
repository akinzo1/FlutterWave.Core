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
        public async Task ShouldPostNGBankAccountsWithNGBankAccountsRequestAsync()
        {
            // given 



            dynamic createRandomNGBankAccountsRequestProperties =
              CreateRandomNGBankAccountsRequestProperties();

            dynamic createRandomNGBankAccountsResponseProperties =
                CreateRandomNGBankAccountsResponseProperties();


            var randomExternalNGBankAccountsRequest = new ExternalNGBankAccountsRequest
            {
                Amount = createRandomNGBankAccountsRequestProperties.Amount,
                AccountBank = createRandomNGBankAccountsRequestProperties.AccountBank,
                AccountNumber = createRandomNGBankAccountsRequestProperties.AccountNumber,
                Currency = createRandomNGBankAccountsRequestProperties.Currency,
                Email = createRandomNGBankAccountsRequestProperties.Email,
                FullName = createRandomNGBankAccountsRequestProperties.Fullname,
                PhoneNumber = createRandomNGBankAccountsRequestProperties.PhoneNumber,
                TxRef = createRandomNGBankAccountsRequestProperties.TxRef,


            };

            var randomExternalNGBankAccountsResponse = new ExternalNGBankAccountsResponse
            {
                Data = new ExternalNGBankAccountsResponse.ExternalNGBankAccountsData
                {
                    TxRef = createRandomNGBankAccountsResponseProperties.Data.TxRef,
                    Currency = createRandomNGBankAccountsResponseProperties.Data.Currency,
                    AccountId = createRandomNGBankAccountsResponseProperties.Data.AccountId,
                    Amount = createRandomNGBankAccountsResponseProperties.Data.Amount,
                    AppFee = createRandomNGBankAccountsResponseProperties.Data.AppFee,
                    AuthModel = createRandomNGBankAccountsResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomNGBankAccountsResponseProperties.Data.AuthUrl,
                    ChargedAmount = createRandomNGBankAccountsResponseProperties.Data.ChargedAmount,
                    Account = new ExternalNGBankAccountsResponse.Account
                    {
                        AccountName = createRandomNGBankAccountsResponseProperties.Data.Account.AccountName,
                        AccountNumber = createRandomNGBankAccountsResponseProperties.Data.Account.AccountNumber,
                        BankCode = createRandomNGBankAccountsResponseProperties.Data.Account.BankCode,

                    },
                    CreatedAt = createRandomNGBankAccountsResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomNGBankAccountsResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomNGBankAccountsResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomNGBankAccountsResponseProperties.Data.FraudStatus,
                    Id = createRandomNGBankAccountsResponseProperties.Data.Id,
                    Ip = createRandomNGBankAccountsResponseProperties.Data.Ip,
                    MerchantFee = createRandomNGBankAccountsResponseProperties.Data.MerchantFee,
                    Narration = createRandomNGBankAccountsResponseProperties.Data.Narration,
                    PaymentType = createRandomNGBankAccountsResponseProperties.Data.PaymentType,
                    Meta = new ExternalNGBankAccountsResponse.Meta
                    {
                        Authorization = new ExternalNGBankAccountsResponse.Authorization
                        {
                            Mode = createRandomNGBankAccountsResponseProperties.Data.Meta.Mode,
                            ValidateInstructions = createRandomNGBankAccountsResponseProperties.Data.Meta.ValidateInstructions
                        }
                    },
                    Status = createRandomNGBankAccountsResponseProperties.Data.Status,
                    Customer = new ExternalNGBankAccountsResponse.Customer
                    {
                        Id = createRandomNGBankAccountsResponseProperties.Data.Customer.Id,
                        Email = createRandomNGBankAccountsResponseProperties.Data.Customer.Email
                    }
                },

                Message = createRandomNGBankAccountsResponseProperties.Message,
                Status = createRandomNGBankAccountsResponseProperties.Status,

            };


            var randomNGBankAccountsRequest = new NGBankAccountsRequest
            {
                Amount = createRandomNGBankAccountsRequestProperties.Amount,
                AccountBank = createRandomNGBankAccountsRequestProperties.AccountBank,
                AccountNumber = createRandomNGBankAccountsRequestProperties.AccountNumber,
                Currency = createRandomNGBankAccountsRequestProperties.Currency,
                Email = createRandomNGBankAccountsRequestProperties.Email,
                FullName = createRandomNGBankAccountsRequestProperties.Fullname,
                PhoneNumber = createRandomNGBankAccountsRequestProperties.PhoneNumber,
                TxRef = createRandomNGBankAccountsRequestProperties.TxRef,

            };

            var randomNGBankAccountsResponse = new NGBankAccountsResponse
            {
                Data = new NGBankAccountsResponse.NGBankAccountsData
                {
                    TxRef = createRandomNGBankAccountsResponseProperties.Data.TxRef,
                    Currency = createRandomNGBankAccountsResponseProperties.Data.Currency,
                    AccountId = createRandomNGBankAccountsResponseProperties.Data.AccountId,
                    Amount = createRandomNGBankAccountsResponseProperties.Data.Amount,
                    AppFee = createRandomNGBankAccountsResponseProperties.Data.AppFee,
                    AuthModel = createRandomNGBankAccountsResponseProperties.Data.AuthModel,
                    AuthUrl = createRandomNGBankAccountsResponseProperties.Data.AuthUrl,
                    ChargedAmount = createRandomNGBankAccountsResponseProperties.Data.ChargedAmount,
                    Account = new NGBankAccountsResponse.Account
                    {
                        AccountName = createRandomNGBankAccountsResponseProperties.Data.Account.AccountName,
                        AccountNumber = createRandomNGBankAccountsResponseProperties.Data.Account.AccountNumber,
                        BankCode = createRandomNGBankAccountsResponseProperties.Data.Account.BankCode,

                    },
                    CreatedAt = createRandomNGBankAccountsResponseProperties.Data.CreatedAt,
                    DeviceFingerprint = createRandomNGBankAccountsResponseProperties.Data.DeviceFingerprint,
                    FlwRef = createRandomNGBankAccountsResponseProperties.Data.FlwRef,
                    FraudStatus = createRandomNGBankAccountsResponseProperties.Data.FraudStatus,
                    Id = createRandomNGBankAccountsResponseProperties.Data.Id,
                    Ip = createRandomNGBankAccountsResponseProperties.Data.Ip,
                    MerchantFee = createRandomNGBankAccountsResponseProperties.Data.MerchantFee,
                    Narration = createRandomNGBankAccountsResponseProperties.Data.Narration,
                    PaymentType = createRandomNGBankAccountsResponseProperties.Data.PaymentType,
                    Meta = new NGBankAccountsResponse.Meta
                    {
                        Authorization = new NGBankAccountsResponse.Authorization
                        {
                            Mode = createRandomNGBankAccountsResponseProperties.Data.Meta.Mode,
                            ValidateInstructions = createRandomNGBankAccountsResponseProperties.Data.Meta.ValidateInstructions
                        }
                    },
                    Status = createRandomNGBankAccountsResponseProperties.Data.Status,
                    Customer = new NGBankAccountsResponse.Customer
                    {
                        Id = createRandomNGBankAccountsResponseProperties.Data.Customer.Id,
                        Email = createRandomNGBankAccountsResponseProperties.Data.Customer.Email
                    }
                },

                Message = createRandomNGBankAccountsResponseProperties.Message,
                Status = createRandomNGBankAccountsResponseProperties.Status,

            };


            var randomNGBankAccounts = new NGBankAccounts
            {
                Request = randomNGBankAccountsRequest,
            };

            NGBankAccounts inputNGBankAccounts = randomNGBankAccounts;
            NGBankAccounts expectedNGBankAccounts = inputNGBankAccounts.DeepClone();
            expectedNGBankAccounts.Response = randomNGBankAccountsResponse;

            ExternalNGBankAccountsRequest mappedExternalNGBankAccountsRequest =
               randomExternalNGBankAccountsRequest;

            ExternalNGBankAccountsResponse returnedExternalNGBankAccountsResponse =
                randomExternalNGBankAccountsResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeNGBankAccountAsync(It.Is(
                      SameExternalNGBankAccountsRequestAs(mappedExternalNGBankAccountsRequest))))
                     .ReturnsAsync(returnedExternalNGBankAccountsResponse);

            // when
            NGBankAccounts actualCreateNGBankAccounts =
               await this.chargeService.PostChargeNGBankAccountRequestAsync(inputNGBankAccounts);

            // then
            actualCreateNGBankAccounts.Should().BeEquivalentTo(expectedNGBankAccounts);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeNGBankAccountAsync(It.Is(
                   SameExternalNGBankAccountsRequestAs(mappedExternalNGBankAccountsRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}