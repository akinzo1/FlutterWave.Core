



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData("", "", "", "")]
        [InlineData(" ", " ", " ", " ")]
        public async Task ShouldThrowValidationExceptionOnRetrievePayoutSubaccountTransactionsWitSubaccountIdDataIsInvalidAsync(
            string invalidSubaccountId, string invalidCurrency, string invalidFrom, string invalidTo)
        {
            // given
            var invalidPayoutSubaccountsException =
                new InvalidPayoutSubaccountsException();

            invalidPayoutSubaccountsException.AddData(
                key: nameof(FetchPayoutSubaccountTransactions),
                values: "Value is required");

            var expectedPayoutSubaccountsValidationException =
                new PayoutSubaccountsValidationException(invalidPayoutSubaccountsException);

            // when
            ValueTask<FetchPayoutSubaccountTransactions> retrievePayoutSubaccountsTask =
                this.payoutSubaccountService.GetPayoutSubaccountTransactionsRequestAsync(invalidSubaccountId, invalidFrom, invalidTo, invalidCurrency);

            PayoutSubaccountsValidationException actualPayoutSubaccountsValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsValidationException>(
                    retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsValidationException.Should()
                .BeEquivalentTo(expectedPayoutSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}