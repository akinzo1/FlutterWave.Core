



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        public async Task ShouldThrowValidationExceptionOnRetrievePayoutSubaccountAvailableBalanceWitSubaccountIdDataIsInvalidAsync(
            string invalidSubaccountId, string invalidCurrency)
        {
            // given
            var invalidPayoutSubaccountsException =
                new InvalidPayoutSubaccountsException();

            invalidPayoutSubaccountsException.AddData(
                key: nameof(FetchSubaccountAvailableBalance),
                values: "Value is required");

            var expectedPayoutSubaccountsValidationException =
                new PayoutSubaccountsValidationException(invalidPayoutSubaccountsException);

            // when
            ValueTask<FetchSubaccountAvailableBalance> retrievePayoutSubaccountsTask =
                this.payoutSubaccountService.GetPayoutSubaccountsAvailableBalanceRequestAsync(invalidSubaccountId, invalidCurrency);

            PayoutSubaccountsValidationException actualPayoutSubaccountsValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsValidationException>(
                    retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsValidationException.Should()
                .BeEquivalentTo(expectedPayoutSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountsAvailableBalanceAsync(
                    It.IsAny<string>(), It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}