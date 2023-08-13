using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.BillPayment
{
    public partial class BillPaymentsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostBulkPaymentsIfBulkPaymentsIsNullAsync()
        {
            // given
            BulkBillPayments? nullBulkPayments = null;
            var nullBulkPaymentsException = new NullBillPaymentException();

            var exceptedBillPaymentValidationException =
                new BillPaymentValidationException(nullBulkPaymentsException);

            // when
            ValueTask<BulkBillPayments> BulkPaymentsTask =
                this.billPaymentsService.PostCreateBulkBillAsync(nullBulkPayments);

            BillPaymentValidationException actualBulkBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    BulkPaymentsTask.AsTask);

            // then
            actualBulkBillPaymentValidationException.Should()
                .BeEquivalentTo(exceptedBillPaymentValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkBillAsync(
                    It.IsAny<ExternalBulkBillPaymentsRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnBulkPaymentsIfRequestIsNullAsync()
        {
            // given
            var invalidBulkPayments = new BulkBillPayments();
            invalidBulkPayments.Request = null;

            var invalidBulkPaymentsException =
                new InvalidBillPaymentException();

            invalidBulkPaymentsException.AddData(
                key: nameof(BulkBillPaymentsRequest),
                values: "Value is required");

            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(
                    invalidBulkPaymentsException);

            // when
            ValueTask<BulkBillPayments> bulkBillPaymentsTask =
                this.billPaymentsService.PostCreateBulkBillAsync(invalidBulkPayments);

            BillPaymentValidationException actualBulkBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    bulkBillPaymentsTask.AsTask);

            // then
            actualBulkBillPaymentValidationException.Should()
                .BeEquivalentTo(expectedBillPaymentValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkBillAsync(
                    It.IsAny<ExternalBulkBillPaymentsRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostBulkPaymentsIfBulkPaymentsIsInvalidAsync(string invalidCallBackUrl, string invalidBulkReference)
        {
            // given
            var bulkBillPayments = new BulkBillPayments
            {
                Request = new BulkBillPaymentsRequest
                {
                    BulkData = null,
                    CallbackUrl = invalidCallBackUrl,
                    BulkReference = invalidBulkReference
                }
            };

            var invalidBulkPaymentsException = new InvalidBillPaymentException();

            invalidBulkPaymentsException.AddData(
                key: nameof(BulkBillPayments.Request.BulkReference),
                values: "Value is required");

            invalidBulkPaymentsException.AddData(
                key: nameof(BulkBillPayments.Request.CallbackUrl),
                values: "Value is required");

            invalidBulkPaymentsException.AddData(
               key: nameof(BulkBillPayments.Request.BulkData),
               values: "Value is required");

            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidBulkPaymentsException);

            // when
            ValueTask<BulkBillPayments> bulkBillPaymentsTask =
                this.billPaymentsService.PostCreateBulkBillAsync(bulkBillPayments);

            BillPaymentValidationException actualBulkBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(bulkBillPaymentsTask.AsTask);

            // then
            actualBulkBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostBulkPaymentsIfPostBulkPaymentsIsEmptyAsync()
        {
            // given
            var bulkBillPayments = new BulkBillPayments
            {
                Request = new BulkBillPaymentsRequest
                {
                    BulkData = null,
                    BulkReference = string.Empty,
                    CallbackUrl = string.Empty,
                }
            };

            var invalidBulkPaymentsException = new InvalidBillPaymentException();

            invalidBulkPaymentsException.AddData(
                key: nameof(BulkBillPaymentsRequest.BulkReference),
                values: "Value is required");

            invalidBulkPaymentsException.AddData(
                key: nameof(BulkBillPaymentsRequest.CallbackUrl),
                values: "Value is required");

            invalidBulkPaymentsException.AddData(
             key: nameof(BulkBillPaymentsRequest.BulkData),
             values: "Value is required");

            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidBulkPaymentsException);

            // when
            ValueTask<BulkBillPayments> bulkBillPaymentsTask =
                this.billPaymentsService.PostCreateBulkBillAsync(bulkBillPayments);

            BillPaymentValidationException actualBulkBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    bulkBillPaymentsTask.AsTask);

            // then
            actualBulkBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}