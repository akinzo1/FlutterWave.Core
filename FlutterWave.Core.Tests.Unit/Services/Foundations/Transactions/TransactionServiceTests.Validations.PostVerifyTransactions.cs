



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Theory]
        [InlineData(0)]
        public async Task ShouldThrowValidationExceptionOnVerifyTransactionsWithTransactionIdIsInvalidAsync(
            int invalidTransactionId)
        {
            // given
            var invalidTransactionsException =
                new InvalidTransactionsException();

            invalidTransactionsException.AddData(
                key: nameof(VerifyTransaction),
                values: "A valid number is required");

            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidTransactionsException);

            // when
            ValueTask<VerifyTransaction> retrieveTransactionsByCountryTask =
                this.transactionsService.PostVerifyTransactionAsync(invalidTransactionId);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(
                    retrieveTransactionsByCountryTask.AsTask);

            // then
            actualTransactionsValidationException.Should()
                .BeEquivalentTo(expectedTransactionsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBankBranchesByIdAsync(
                    It.IsAny<int>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public async Task ShouldThrowValidationExceptionOnVerifyTransactionsWithTransactionReferenceIsInvalidAsync(
          string invalidTransactionId)
        {
            // given
            var invalidTransactionsException =
                new InvalidTransactionsException();

            invalidTransactionsException.AddData(
                key: nameof(VerifyTransaction),
                values: "Value is required");

            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidTransactionsException);

            // when
            ValueTask<VerifyTransaction> retrieveTransactionsByCountryTask =
                this.transactionsService.PostVerifyTransactionAsync(invalidTransactionId);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(
                    retrieveTransactionsByCountryTask.AsTask);

            // then
            actualTransactionsValidationException.Should()
                .BeEquivalentTo(expectedTransactionsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBankBranchesByIdAsync(
                    It.IsAny<int>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}