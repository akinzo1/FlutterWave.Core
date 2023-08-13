



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveMultipleRefundRequestWithFromAndToDateAsync()
        {
            // given 
            DateTime randomFromDate = GetRandomDate();
            string randomFrom = randomFromDate.ToString();
            string inputFromDate = randomFrom;

            DateTime randomToDate = GetRandomDate();
            string randomTo = randomToDate.ToString();
            string inputToDate = randomTo;

            dynamic createMultipleRefundRandomProperties =
                CreateRandomMultipleRefundsProperties();

            var externalMultipleRefundsResponse = new ExternalFetchMultipleTransactionsResponse
            {

                Message = createMultipleRefundRandomProperties.Message,
                Data = ((List<dynamic>)createMultipleRefundRandomProperties.Data).Select(items =>
                {
                    return new ExternalFetchMultipleTransactionsResponse.Datum
                    {
                        Id = items.Id,
                        AccountId = items.AccountId,
                        AmountRefunded = items.AmountRefunded,
                        Comment = items.Comment,
                        CreatedAt = items.CreatedAt,
                        FlwRef = items.FlwRef,
                        Meta = items.Meta,
                        SettlementId = items.SettlementId,
                        Status = items.Status,
                        TransactionId = items.TransactionId,


                    };
                }).ToList(),
                Status = createMultipleRefundRandomProperties.Status,
                Meta = new ExternalFetchMultipleTransactionsResponse.ExternalFetchMultpleRefundTransactionMetaModel
                {
                    PageInfo = new ExternalFetchMultipleTransactionsResponse.PageInfo
                    {
                        CurrentPage = createMultipleRefundRandomProperties.Meta.CurrentPage,
                        PageSize = createMultipleRefundRandomProperties.Meta.PageSize,
                        Total = createMultipleRefundRandomProperties.Meta.Total,
                        TotalPages = createMultipleRefundRandomProperties.Meta.TotalPages
                    }
                }
            };

            var expectedMultipleRefundsResponse = new FetchMultipleRefundTransactionResponse
            {

                Message = createMultipleRefundRandomProperties.Message,
                Data = ((List<dynamic>)createMultipleRefundRandomProperties.Data).Select(items =>
                {
                    return new FetchMultipleRefundTransactionResponse.Datum
                    {
                        Id = items.Id,
                        AccountId = items.AccountId,
                        AmountRefunded = items.AmountRefunded,
                        Comment = items.Comment,
                        CreatedAt = items.CreatedAt,
                        FlwRef = items.FlwRef,
                        Meta = items.Meta,
                        SettlementId = items.SettlementId,
                        Status = items.Status,
                        TransactionId = items.TransactionId,


                    };
                }).ToList(),
                Status = createMultipleRefundRandomProperties.Status,
                Meta = new FetchMultipleRefundTransactionResponse.FetchMultipleRefundTransactionMetaModel
                {
                    PageInfo = new FetchMultipleRefundTransactionResponse.PageInfo
                    {
                        CurrentPage = createMultipleRefundRandomProperties.Meta.CurrentPage,
                        PageSize = createMultipleRefundRandomProperties.Meta.PageSize,
                        Total = createMultipleRefundRandomProperties.Meta.Total,
                        TotalPages = createMultipleRefundRandomProperties.Meta.TotalPages
                    }
                }

            };

            var expectedMultipleRefunds = new MultipleRefundTransaction
            {
                Response = expectedMultipleRefundsResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetMultipleRefundsAsync(inputFromDate, inputToDate))
                    .ReturnsAsync(externalMultipleRefundsResponse);

            // when
            MultipleRefundTransaction actualBankBranches =
                await this.transactionsService.GetMultipleRefundsAsync(inputFromDate, inputToDate);

            // then
            actualBankBranches.Should().BeEquivalentTo(expectedMultipleRefunds);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleRefundsAsync(inputFromDate, inputToDate),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}