



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveMultipleRefundWithFromAndToDataIsInvalidAsync(string invalidFrom, string invalidTo)
        {
            // given
            var invalidTransactionsException =
                new InvalidTransactionsException();

            invalidTransactionsException.AddData(
                key: nameof(MultipleRefundTransaction),
                values: "Value is required");

            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidTransactionsException);

            // when
            ValueTask<MultipleRefundTransaction> retrieveTransactionsTask =
                this.transactionsService.GetMultipleRefundsAsync(invalidFrom, invalidTo);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsValidationException.Should()
                .BeEquivalentTo(expectedTransactionsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleRefundsAsync(
                    It.IsAny<string>(), It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}