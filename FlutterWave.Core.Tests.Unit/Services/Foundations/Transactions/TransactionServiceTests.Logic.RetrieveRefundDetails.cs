



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveRefundDetailsWithTransactionIdAsync()
        {
            // given 
            string randomNumber = GetRandomString();
            string randomTransactionId = randomNumber;
            string inputTransactionId = randomTransactionId;

            dynamic createRefundDetailsRandomProperties =
                CreateRandomRefundDetailsProperties();

            var externalRefundDetailsResponse = new ExternalFetchRefundDetailsResponse
            {

                Data = new ExternalFetchRefundDetailsResponse.ExternalFetchRefundDetailsData
                {
                    SettlementId = createRefundDetailsRandomProperties.Data.SettlementId,
                    TransactionId = createRefundDetailsRandomProperties.Data.TransactionId,
                    AccountId = createRefundDetailsRandomProperties.Data.AccountId,
                    AmountRefunded = createRefundDetailsRandomProperties.Data.AmountRefunded,
                    Comment = new object(),
                    CreatedAt = createRefundDetailsRandomProperties.Data.CreatedAt,
                    FlwRef = createRefundDetailsRandomProperties.Data.FlwRef,
                    Id = createRefundDetailsRandomProperties.Data.Id
                },
                Status = createRefundDetailsRandomProperties.Status,
                Message = createRefundDetailsRandomProperties.Message
            };

            var expectedRefundDetailsResponse = new FetchRefundDetailsResponse
            {
                Data = new FetchRefundDetailsResponse.FetchRefundDetailsData
                {
                    SettlementId = createRefundDetailsRandomProperties.Data.SettlementId,
                    TransactionId = createRefundDetailsRandomProperties.Data.TransactionId,
                    AccountId = createRefundDetailsRandomProperties.Data.AccountId,
                    AmountRefunded = createRefundDetailsRandomProperties.Data.AmountRefunded,
                    Comment = new object(),
                    CreatedAt = createRefundDetailsRandomProperties.Data.CreatedAt,
                    FlwRef = createRefundDetailsRandomProperties.Data.FlwRef,
                    Id = createRefundDetailsRandomProperties.Data.Id
                },
                Status = createRefundDetailsRandomProperties.Status,
                Message = createRefundDetailsRandomProperties.Message

            };

            var expectedRefundDetails = new RefundDetails
            {
                Response = expectedRefundDetailsResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetRefundDetailsAsync(inputTransactionId))
                    .ReturnsAsync(externalRefundDetailsResponse);

            // when
            RefundDetails actualBankBranches =
                await this.transactionsService.GetRefundDetailsAsync(inputTransactionId);

            // then
            actualBankBranches.Should().BeEquivalentTo(expectedRefundDetails);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRefundDetailsAsync(inputTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}