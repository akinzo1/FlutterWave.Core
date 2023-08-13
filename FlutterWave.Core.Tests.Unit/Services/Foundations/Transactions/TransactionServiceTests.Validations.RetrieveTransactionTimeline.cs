



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveTransactionTimelineWithTransactionIdDataIsInvalidAsync(string invalidTransactionId)
        {
            // given
            var invalidTransactionsException =
                new InvalidTransactionsException();

            invalidTransactionsException.AddData(
                key: nameof(TransactionTimeline),
                values: "Value is required");

            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidTransactionsException);

            // when
            ValueTask<TransactionTimeline> retrieveTransactionsTask =
                this.transactionsService.GetTransactionTimelineAsync(invalidTransactionId);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsValidationException.Should()
                .BeEquivalentTo(expectedTransactionsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionTimelineAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}