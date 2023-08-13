



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
        [InlineData("  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPromptIfTransactionsIsInvalidAsync(string invalidFromDate, string invalidToDate)
        {
            // given


            var invalidTransactionsException = new InvalidTransactionsException();

            invalidTransactionsException.AddData(
                key: nameof(MultipleTransaction),
                values: "Value is required");


            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidTransactionsException);

            // when
            ValueTask<MultipleTransaction> multipleTransactionsTask =
                this.transactionsService.GetMultipleTransactionAsync(invalidFromDate, invalidToDate);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(multipleTransactionsTask.AsTask);

            // then
            actualTransactionsValidationException.Should().BeEquivalentTo(
                expectedTransactionsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.GetMultipleTransactionAsync(
                   It.IsAny<string>(), It.IsAny<string>()),
                       Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


    }
}