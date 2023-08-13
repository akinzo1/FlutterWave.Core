



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldVerifyTransactionRequestWithTransactionIdAsync()
        {
            // given 
            int randomNumber = GetRandomNumber();
            int randomTransactionId = randomNumber;
            int inputTransactionId = randomTransactionId;

            dynamic verifyTransactionRandomProperties =
                CreateRandomVerifyTransactionProperties();

            var randomExternalVerifyTransactionResponse = new ExternalVerifyTransactionResponse
            {

                Message = verifyTransactionRandomProperties.Message,
                Data = new ExternalVerifyTransactionResponse.ExternalVerifyTransactionDataModel
                {
                    Id = verifyTransactionRandomProperties.Data.Id,
                    TxRef = verifyTransactionRandomProperties.Data.TxRef,
                    FlwRef = verifyTransactionRandomProperties.Data.FlwRef,
                    DeviceFingerprint = verifyTransactionRandomProperties.Data.DeviceFingerprint,
                    Amount = verifyTransactionRandomProperties.Data.Amount,
                    Currency = verifyTransactionRandomProperties.Data.Currency,
                    ChargedAmount = verifyTransactionRandomProperties.Data.ChargedAmount,
                    AppFee = verifyTransactionRandomProperties.Data.AppFee,
                    MerchantFee = verifyTransactionRandomProperties.Data.MerchantFee,
                    ProcessorResponse = verifyTransactionRandomProperties.Data.ProcessorResponse,
                    AuthModel = verifyTransactionRandomProperties.Data.AuthModel,
                    Ip = verifyTransactionRandomProperties.Data.Ip,
                    Narration = verifyTransactionRandomProperties.Data.Narration,
                    Status = verifyTransactionRandomProperties.Data.Status,
                    PaymentType = verifyTransactionRandomProperties.Data.PaymentType,
                    CreatedAt = verifyTransactionRandomProperties.Data.CreatedAt,
                    AccountId = verifyTransactionRandomProperties.Data.AccountId,
                    Card = new ExternalVerifyTransactionResponse.ExternalVerifyTransactionCardModel
                    {
                        Country = verifyTransactionRandomProperties.Data.Card.Country,
                        Expiry = verifyTransactionRandomProperties.Data.Card.Expiry,
                        First6digits = verifyTransactionRandomProperties.Data.Card.First6digits,
                        Issuer = verifyTransactionRandomProperties.Data.Card.Issuer,
                        Last4digits = verifyTransactionRandomProperties.Data.Card.Last4digits,
                        Token = verifyTransactionRandomProperties.Data.Card.Token,
                        Type = verifyTransactionRandomProperties.Data.Card.Type,

                    },
                    Meta = verifyTransactionRandomProperties.Data.Meta,
                    AmountSettled = verifyTransactionRandomProperties.Data.AmountSettled,
                    Customer = new ExternalVerifyTransactionResponse.ExternalVerifyTransactionCustomerModel
                    {
                        CreatedAt = verifyTransactionRandomProperties.Data.Customer.CreatedAt,
                        Email = verifyTransactionRandomProperties.Data.Customer.Email,
                        Id = verifyTransactionRandomProperties.Data.Customer.Id,
                        Name = verifyTransactionRandomProperties.Data.Customer.Name,
                        PhoneNumber = verifyTransactionRandomProperties.Data.Customer.PhoneNumber
                    },
                },
                Status = verifyTransactionRandomProperties.Status,
            };

            var randomVerifyTransactionResponse = new VerifyTransactionResponse
            {

                Message = verifyTransactionRandomProperties.Message,
                Data = new VerifyTransactionResponse.VerifyTransactionDataModel
                {
                    Id = verifyTransactionRandomProperties.Data.Id,
                    TxRef = verifyTransactionRandomProperties.Data.TxRef,
                    FlwRef = verifyTransactionRandomProperties.Data.FlwRef,
                    DeviceFingerprint = verifyTransactionRandomProperties.Data.DeviceFingerprint,
                    Amount = verifyTransactionRandomProperties.Data.Amount,
                    Currency = verifyTransactionRandomProperties.Data.Currency,
                    ChargedAmount = verifyTransactionRandomProperties.Data.ChargedAmount,
                    AppFee = verifyTransactionRandomProperties.Data.AppFee,
                    MerchantFee = verifyTransactionRandomProperties.Data.MerchantFee,
                    ProcessorResponse = verifyTransactionRandomProperties.Data.ProcessorResponse,
                    AuthModel = verifyTransactionRandomProperties.Data.AuthModel,
                    Ip = verifyTransactionRandomProperties.Data.Ip,
                    Narration = verifyTransactionRandomProperties.Data.Narration,
                    Status = verifyTransactionRandomProperties.Data.Status,
                    PaymentType = verifyTransactionRandomProperties.Data.PaymentType,
                    CreatedAt = verifyTransactionRandomProperties.Data.CreatedAt,
                    AccountId = verifyTransactionRandomProperties.Data.AccountId,
                    Card = new VerifyTransactionResponse.VerifyTransactionCardModel
                    {
                        Country = verifyTransactionRandomProperties.Data.Card.Country,
                        Expiry = verifyTransactionRandomProperties.Data.Card.Expiry,
                        First6digits = verifyTransactionRandomProperties.Data.Card.First6digits,
                        Issuer = verifyTransactionRandomProperties.Data.Card.Issuer,
                        Last4digits = verifyTransactionRandomProperties.Data.Card.Last4digits,
                        Token = verifyTransactionRandomProperties.Data.Card.Token,
                        Type = verifyTransactionRandomProperties.Data.Card.Type,

                    },
                    Meta = verifyTransactionRandomProperties.Data.Meta,
                    AmountSettled = verifyTransactionRandomProperties.Data.AmountSettled,
                    Customer = new VerifyTransactionResponse.VerifyTransactionCustomerModel
                    {
                        CreatedAt = verifyTransactionRandomProperties.Data.Customer.CreatedAt,
                        Email = verifyTransactionRandomProperties.Data.Customer.Email,
                        Id = verifyTransactionRandomProperties.Data.Customer.Id,
                        Name = verifyTransactionRandomProperties.Data.Customer.Name,
                        PhoneNumber = verifyTransactionRandomProperties.Data.Customer.PhoneNumber
                    },
                },
                Status = verifyTransactionRandomProperties.Status,

            };

            VerifyTransaction expectedVerifyTransaction = new VerifyTransaction
            {
                Response = randomVerifyTransactionResponse,
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVerifyTransactionAsync(inputTransactionId))
                    .ReturnsAsync(randomExternalVerifyTransactionResponse);

            // when
            VerifyTransaction actualVerifyTransactions =
                await this.transactionsService.PostVerifyTransactionAsync(inputTransactionId);

            // then
            actualVerifyTransactions.Should().BeEquivalentTo(expectedVerifyTransaction);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVerifyTransactionAsync(inputTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldVerifyTransactionRequestWithTransactionReferenceAsync()
        {
            // given 
            string randomReference = GetRandomString();
            string randomTransactionReference = randomReference;
            string inputTransactionId = randomTransactionReference;

            dynamic verifyTransactionRandomProperties =
                CreateRandomVerifyTransactionProperties();

            var randomExternalVerifyTransactionResponse = new ExternalVerifyTransactionResponse
            {

                Message = verifyTransactionRandomProperties.Message,
                Data = new ExternalVerifyTransactionResponse.ExternalVerifyTransactionDataModel
                {
                    Id = verifyTransactionRandomProperties.Data.Id,
                    TxRef = verifyTransactionRandomProperties.Data.TxRef,
                    FlwRef = verifyTransactionRandomProperties.Data.FlwRef,
                    DeviceFingerprint = verifyTransactionRandomProperties.Data.DeviceFingerprint,
                    Amount = verifyTransactionRandomProperties.Data.Amount,
                    Currency = verifyTransactionRandomProperties.Data.Currency,
                    ChargedAmount = verifyTransactionRandomProperties.Data.ChargedAmount,
                    AppFee = verifyTransactionRandomProperties.Data.AppFee,
                    MerchantFee = verifyTransactionRandomProperties.Data.MerchantFee,
                    ProcessorResponse = verifyTransactionRandomProperties.Data.ProcessorResponse,
                    AuthModel = verifyTransactionRandomProperties.Data.AuthModel,
                    Ip = verifyTransactionRandomProperties.Data.Ip,
                    Narration = verifyTransactionRandomProperties.Data.Narration,
                    Status = verifyTransactionRandomProperties.Data.Status,
                    PaymentType = verifyTransactionRandomProperties.Data.PaymentType,
                    CreatedAt = verifyTransactionRandomProperties.Data.CreatedAt,
                    AccountId = verifyTransactionRandomProperties.Data.AccountId,
                    Card = new ExternalVerifyTransactionResponse.ExternalVerifyTransactionCardModel
                    {
                        Country = verifyTransactionRandomProperties.Data.Card.Country,
                        Expiry = verifyTransactionRandomProperties.Data.Card.Expiry,
                        First6digits = verifyTransactionRandomProperties.Data.Card.First6digits,
                        Issuer = verifyTransactionRandomProperties.Data.Card.Issuer,
                        Last4digits = verifyTransactionRandomProperties.Data.Card.Last4digits,
                        Token = verifyTransactionRandomProperties.Data.Card.Token,
                        Type = verifyTransactionRandomProperties.Data.Card.Type,

                    },
                    Meta = verifyTransactionRandomProperties.Data.Meta,
                    AmountSettled = verifyTransactionRandomProperties.Data.AmountSettled,
                    Customer = new ExternalVerifyTransactionResponse.ExternalVerifyTransactionCustomerModel
                    {
                        CreatedAt = verifyTransactionRandomProperties.Data.Customer.CreatedAt,
                        Email = verifyTransactionRandomProperties.Data.Customer.Email,
                        Id = verifyTransactionRandomProperties.Data.Customer.Id,
                        Name = verifyTransactionRandomProperties.Data.Customer.Name,
                        PhoneNumber = verifyTransactionRandomProperties.Data.Customer.PhoneNumber
                    },
                },
                Status = verifyTransactionRandomProperties.Status,
            };

            var randomVerifyTransactionResponse = new VerifyTransactionResponse
            {

                Message = verifyTransactionRandomProperties.Message,
                Data = new VerifyTransactionResponse.VerifyTransactionDataModel
                {
                    Id = verifyTransactionRandomProperties.Data.Id,
                    TxRef = verifyTransactionRandomProperties.Data.TxRef,
                    FlwRef = verifyTransactionRandomProperties.Data.FlwRef,
                    DeviceFingerprint = verifyTransactionRandomProperties.Data.DeviceFingerprint,
                    Amount = verifyTransactionRandomProperties.Data.Amount,
                    Currency = verifyTransactionRandomProperties.Data.Currency,
                    ChargedAmount = verifyTransactionRandomProperties.Data.ChargedAmount,
                    AppFee = verifyTransactionRandomProperties.Data.AppFee,
                    MerchantFee = verifyTransactionRandomProperties.Data.MerchantFee,
                    ProcessorResponse = verifyTransactionRandomProperties.Data.ProcessorResponse,
                    AuthModel = verifyTransactionRandomProperties.Data.AuthModel,
                    Ip = verifyTransactionRandomProperties.Data.Ip,
                    Narration = verifyTransactionRandomProperties.Data.Narration,
                    Status = verifyTransactionRandomProperties.Data.Status,
                    PaymentType = verifyTransactionRandomProperties.Data.PaymentType,
                    CreatedAt = verifyTransactionRandomProperties.Data.CreatedAt,
                    AccountId = verifyTransactionRandomProperties.Data.AccountId,
                    Card = new VerifyTransactionResponse.VerifyTransactionCardModel
                    {
                        Country = verifyTransactionRandomProperties.Data.Card.Country,
                        Expiry = verifyTransactionRandomProperties.Data.Card.Expiry,
                        First6digits = verifyTransactionRandomProperties.Data.Card.First6digits,
                        Issuer = verifyTransactionRandomProperties.Data.Card.Issuer,
                        Last4digits = verifyTransactionRandomProperties.Data.Card.Last4digits,
                        Token = verifyTransactionRandomProperties.Data.Card.Token,
                        Type = verifyTransactionRandomProperties.Data.Card.Type,

                    },
                    Meta = verifyTransactionRandomProperties.Data.Meta,
                    AmountSettled = verifyTransactionRandomProperties.Data.AmountSettled,
                    Customer = new VerifyTransactionResponse.VerifyTransactionCustomerModel
                    {
                        CreatedAt = verifyTransactionRandomProperties.Data.Customer.CreatedAt,
                        Email = verifyTransactionRandomProperties.Data.Customer.Email,
                        Id = verifyTransactionRandomProperties.Data.Customer.Id,
                        Name = verifyTransactionRandomProperties.Data.Customer.Name,
                        PhoneNumber = verifyTransactionRandomProperties.Data.Customer.PhoneNumber
                    },
                },
                Status = verifyTransactionRandomProperties.Status,

            };

            VerifyTransaction expectedVerifyTransaction = new VerifyTransaction
            {
                Response = randomVerifyTransactionResponse,
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVerifyTransactionAsync(inputTransactionId))
                    .ReturnsAsync(randomExternalVerifyTransactionResponse);

            // when
            VerifyTransaction actualVerifyTransactions =
                await this.transactionsService.PostVerifyTransactionAsync(inputTransactionId);

            // then
            actualVerifyTransactions.Should().BeEquivalentTo(expectedVerifyTransaction);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVerifyTransactionAsync(inputTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}