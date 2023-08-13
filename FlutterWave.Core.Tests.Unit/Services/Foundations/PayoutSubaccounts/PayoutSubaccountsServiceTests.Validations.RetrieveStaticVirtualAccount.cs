



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
        public async Task ShouldThrowValidationExceptionOnRetrieveStaticVirtualAccountWitSubaccountIdDataIsInvalidAsync(
            string invalidAccountReference, string invalidCurrency)
        {
            // given
            var invalidPayoutSubaccountsException =
                new InvalidPayoutSubaccountsException();

            invalidPayoutSubaccountsException.AddData(
                key: nameof(FetchStaticVirtualAccounts),
                values: "Value is required");

            var expectedPayoutSubaccountsValidationException =
                new PayoutSubaccountsValidationException(invalidPayoutSubaccountsException);

            // when
            ValueTask<FetchStaticVirtualAccounts> retrievePayoutSubaccountsTask =
                this.payoutSubaccountService.GetStaticVirtualAccountRequestAsync(invalidAccountReference, invalidCurrency);

            PayoutSubaccountsValidationException actualPayoutSubaccountsValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsValidationException>(
                    retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsValidationException.Should()
                .BeEquivalentTo(expectedPayoutSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetStaticVirtualAccountAsync(
                    It.IsAny<string>(), It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}