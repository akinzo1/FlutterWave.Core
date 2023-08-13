



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveMultipleTransactionsWithFromAndToAsync()
        {

            // given 

            DateTime randomFromDate = GetRandomDate();
            string randomFrom = randomFromDate.ToString();
            string inputFromDate = randomFrom;

            DateTime randomToDate = GetRandomDate();
            string randomTo = randomToDate.ToString();
            string inputToDate = randomTo;

            dynamic createMultipleTransactionProperties =
                CreateRandomMultipleTransactionProperties();

            var randomExternalMultipleTransactionResponse = new ExternalMultipleTransactionResponse
            {

                Message = createMultipleTransactionProperties.Message,
                Data = ((List<dynamic>)createMultipleTransactionProperties.Data).Select(items =>
                {
                    return new ExternalMultipleTransactionResponse.Datum
                    {
                        Id = items.Id,
                        TxRef = items.TxRef,
                        FlwRef = items.FlwRef,
                        DeviceFingerprint = items.DeviceFingerprint,
                        Amount = items.Amount,
                        Currency = items.Currency,
                        ChargedAmount = items.ChargedAmount,
                        AppFee = items.AppFee,
                        MerchantFee = items.MerchantFee,
                        ProcessorResponse = items.ProcessorResponse,
                        AuthModel = items.AuthModel,
                        Ip = items.Ip,
                        Narration = items.Narration,
                        Status = items.Status,
                        PaymentType = items.PaymentType,
                        CreatedAt = items.CreatedAt,
                        AmountSettled = items.AmountSettled,
                        Account = new ExternalMultipleTransactionResponse.Account
                        {
                            Bank = items.Account.Bank,
                            Nuban = items.Account.Nuban
                        },
                        CustomerName = items.CustomerName,
                        CustomerEmail = items.CustomerEmail,
                        AccountId = items.AccountId
                    };
                }).ToList(),

                Meta = new ExternalMultipleTransactionResponse.ExternalMultipleTransactionsMetaModel
                {
                    PageInfo = new ExternalMultipleTransactionResponse.PageInfo
                    {
                        CurrentPage = createMultipleTransactionProperties.Meta.CurrentPage,
                        Total = createMultipleTransactionProperties.Meta.Total,
                        TotalPages = createMultipleTransactionProperties.Meta.TotalPages,
                    }
                },
                Status = createMultipleTransactionProperties.Status,
            };

            var expectedMultipleTransactionsResponse = new FetchMultipleTransactionResponse
            {

                Message = createMultipleTransactionProperties.Message,
                Data = ((List<dynamic>)createMultipleTransactionProperties.Data).Select(items =>
                {
                    return new FetchMultipleTransactionResponse.Datum
                    {
                        Id = items.Id,
                        TxRef = items.TxRef,
                        FlwRef = items.FlwRef,
                        DeviceFingerprint = items.DeviceFingerprint,
                        Amount = items.Amount,
                        Currency = items.Currency,
                        ChargedAmount = items.ChargedAmount,
                        AppFee = items.AppFee,
                        MerchantFee = items.MerchantFee,
                        ProcessorResponse = items.ProcessorResponse,
                        AuthModel = items.AuthModel,
                        Ip = items.Ip,
                        Narration = items.Narration,
                        Status = items.Status,
                        PaymentType = items.PaymentType,
                        CreatedAt = items.CreatedAt,
                        AmountSettled = items.AmountSettled,
                        Account = new FetchMultipleTransactionResponse.Account
                        {
                            Bank = items.Account.Bank,
                            Nuban = items.Account.Nuban
                        },
                        CustomerName = items.CustomerName,
                        CustomerEmail = items.CustomerEmail,
                        AccountId = items.AccountId
                    };
                }).ToList(),

                Meta = new FetchMultipleTransactionResponse.MultipleTransactionMetaModel
                {
                    PageInfo = new FetchMultipleTransactionResponse.PageInfo
                    {
                        CurrentPage = createMultipleTransactionProperties.Meta.CurrentPage,
                        Total = createMultipleTransactionProperties.Meta.Total,
                        TotalPages = createMultipleTransactionProperties.Meta.TotalPages,
                    }
                },
                Status = createMultipleTransactionProperties.Status,

            };

            var expectedMultipleTransaction = new MultipleTransaction
            {
                Response = expectedMultipleTransactionsResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                   broker.GetMultipleTransactionAsync(inputFromDate, inputToDate))
                       .ReturnsAsync(randomExternalMultipleTransactionResponse);

            // when
            MultipleTransaction actualBankBranches =
                await this.transactionsService.GetMultipleTransactionAsync(inputFromDate, inputToDate);

            // then
            actualBankBranches.Should().BeEquivalentTo(expectedMultipleTransaction);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleTransactionAsync(inputFromDate, inputToDate),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}