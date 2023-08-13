



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnRetrievePayoutSubaccountWitSubaccountIdDataIsInvalidAsync(
            string invalidFetchPayoutSubaccountId)
        {
            // given
            var invalidPayoutSubaccountsException =
                new InvalidPayoutSubaccountsException();

            invalidPayoutSubaccountsException.AddData(
                key: nameof(FetchPayoutSubaccount),
                values: "Value is required");

            var expectedPayoutSubaccountsValidationException =
                new PayoutSubaccountsValidationException(invalidPayoutSubaccountsException);

            // when
            ValueTask<FetchPayoutSubaccount> retrievePayoutSubaccountsTask =
                this.payoutSubaccountService.GetPayoutSubaccountRequestAsync(invalidFetchPayoutSubaccountId);

            PayoutSubaccountsValidationException actualPayoutSubaccountsValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsValidationException>(
                    retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsValidationException.Should()
                .BeEquivalentTo(expectedPayoutSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}