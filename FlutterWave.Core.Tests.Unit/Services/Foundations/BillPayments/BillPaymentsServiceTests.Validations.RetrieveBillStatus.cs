using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.BillPayment
{
    public partial class BillPaymentsServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveBillStatusWithBillPaymentReferenceDataIsInvalidAsync(
            string invalidBillPaymentReference)
        {
            // given
            var invalidBillPaymentsException =
                new InvalidBillPaymentException();

            invalidBillPaymentsException.AddData(
                key: nameof(BillPaymentsStatus),
                values: "Value is required");

            var expectedBillPaymentsValidationException =
                new BillPaymentValidationException(invalidBillPaymentsException);

            // when
            ValueTask<BillPaymentsStatus> retrieveBillPaymentsTask =
                this.billPaymentsService.GetBillStatusPaymentAsync(invalidBillPaymentReference);

            BillPaymentValidationException actualBillPaymentsValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    retrieveBillPaymentsTask.AsTask);

            // then
            actualBillPaymentsValidationException.Should()
                .BeEquivalentTo(expectedBillPaymentsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRefundDetailsAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}