



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalBalance;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveStatementOfAccountAsync()
        {
            // given 


            dynamic createRandomStatementOfAccountProperties =
                     CreateRandomStatementOfAccountProperties();

            var randomExternalStatementResponse = new ExternalStatementResponse
            {
                Status = createRandomStatementOfAccountProperties.Status,
                Message = createRandomStatementOfAccountProperties.Message,
                Data = new ExternalStatementResponse.ExternalStatementResult
                {
                    PageInfo = new ExternalStatementResponse.ExternalStatementsPageInfo
                    {
                        CurrentPage = createRandomStatementOfAccountProperties.Data.PageInfo.CurrentPage,
                        Total = createRandomStatementOfAccountProperties.Data.PageInfo.Total,
                        TotalPages = createRandomStatementOfAccountProperties.Data.PageInfo.TotalPages
                    },
                    Transactions = ((List<dynamic>)createRandomStatementOfAccountProperties.Data.Transactions).Select(transactions =>
                    {
                        return new ExternalStatementResponse.ExternalTansactionStatement
                        {
                            Amount = transactions.Amount,
                            BalanceAfter = transactions.BalanceAfter,
                            BalanceBefore = transactions.BalanceBefore,
                            Currency = transactions.Currency,
                            Date = transactions.Date,
                            RateUsed = transactions.RateUsed,
                            Reference = transactions.Reference,
                            Remarks = transactions.Remarks,
                            SentAmount = transactions.SentAmount,
                            SentCurrency = transactions.SentCurrency,
                            StatementType = transactions.StatementType,
                            Type = transactions.Type,

                        };
                    }).ToList()
                },
            };

            var randomExpectedStatementResponse = new StatementResponse
            {
                Status = createRandomStatementOfAccountProperties.Status,
                Message = createRandomStatementOfAccountProperties.Message,
                Data = new StatementResponse.StatementResult
                {
                    PageInfo = new StatementResponse.StatementsPageInfo
                    {
                        CurrentPage = createRandomStatementOfAccountProperties.Data.PageInfo.CurrentPage,
                        Total = createRandomStatementOfAccountProperties.Data.PageInfo.Total,
                        TotalPages = createRandomStatementOfAccountProperties.Data.PageInfo.TotalPages
                    },
                    Transactions = ((List<dynamic>)createRandomStatementOfAccountProperties.Data.Transactions).Select(transactions =>
                    {
                        return new StatementResponse.TansactionStatement
                        {
                            Amount = transactions.Amount,
                            BalanceAfter = transactions.BalanceAfter,
                            BalanceBefore = transactions.BalanceBefore,
                            Currency = transactions.Currency,
                            Date = transactions.Date,
                            RateUsed = transactions.RateUsed,
                            Reference = transactions.Reference,
                            Remarks = transactions.Remarks,
                            SentAmount = transactions.SentAmount,
                            SentCurrency = transactions.SentCurrency,
                            StatementType = transactions.StatementType,
                            Type = transactions.Type,

                        };
                    }).ToList()
                },
            };

            var expectedStatement = new Statement
            {
                Response = randomExpectedStatementResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetStatementAsync())
                    .ReturnsAsync(randomExternalStatementResponse);

            // when
            Statement actualStatement =
               await this.miscellaneousService.GetStatementAsync();

            // then
            actualStatement.Should().BeEquivalentTo(expectedStatement);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetStatementAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}