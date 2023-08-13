



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
        public async Task ShouldThrowValidationExceptionOnRetrieveRefundDetailsWithTransactionIdDataIsInvalidAsync(string invalidTransactionId)
        {
            // given
            var invalidTransactionsException =
                new InvalidTransactionsException();

            invalidTransactionsException.AddData(
                key: nameof(RefundDetails),
                values: "Value is required");

            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidTransactionsException);

            // when
            ValueTask<RefundDetails> retrieveTransactionsTask =
                this.transactionsService.GetRefundDetailsAsync(invalidTransactionId);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsValidationException.Should()
                .BeEquivalentTo(expectedTransactionsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRefundDetailsAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}