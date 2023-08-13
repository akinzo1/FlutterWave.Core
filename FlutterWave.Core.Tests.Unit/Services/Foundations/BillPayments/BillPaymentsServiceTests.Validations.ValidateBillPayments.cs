using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.BillPayment
{
    public partial class BillPaymentsServiceTests
    {
        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "", "")]
        [InlineData(" ", " ", " ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveFeesWithAmountAndCurrencyDataIsInvalidAsync(
            string invalidItemCode, string invalidCode, string invalidCustomer)
        {
            // given
            var invalidBillPaymentException =
                new InvalidBillPaymentException();

            invalidBillPaymentException.AddData(
             key: nameof(ValidateBillService),
             values: "Value is required");




            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidBillPaymentException);

            // when
            ValueTask<ValidateBillService> retrieveBillPaymentTask =
                this.billPaymentsService.GetValidateBillServiceAsync(invalidItemCode, invalidCode, invalidCustomer);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentValidationException.Should()
                .BeEquivalentTo(expectedBillPaymentValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetValidateBillServiceAsync(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}