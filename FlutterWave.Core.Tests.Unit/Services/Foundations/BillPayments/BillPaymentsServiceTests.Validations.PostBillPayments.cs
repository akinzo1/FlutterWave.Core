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
        public async Task ShouldThrowValidationExceptionOnPostBillPaymentsIfBillPaymentsIsNullAsync()
        {
            // given
            PostBillPayments? nullBillPayments = null;
            var nullBillPaymentsException = new NullBillPaymentException();

            var exceptedBillPaymentValidationException =
                new BillPaymentValidationException(nullBillPaymentsException);

            // when
            ValueTask<PostBillPayments> PaymentsTask =
                this.billPaymentsService.PostCreateBillPaymentAsync(nullBillPayments);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualBillPaymentValidationException.Should()
                .BeEquivalentTo(exceptedBillPaymentValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBillPaymentAsync(
                    It.IsAny<ExternalCreateBillPaymentRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPaymentsIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new PostBillPayments();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidBillPaymentException();

            invalidPaymentsException.AddData(
                key: nameof(CreateBillPaymentRequest),
                values: "Value is required");

            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<PostBillPayments> PostBillPaymentsTask =
                this.billPaymentsService.PostCreateBillPaymentAsync(invalidPayments);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    PostBillPaymentsTask.AsTask);

            // then
            actualBillPaymentValidationException.Should()
                .BeEquivalentTo(expectedBillPaymentValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBillPaymentAsync(
                    It.IsAny<ExternalCreateBillPaymentRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null, null, null, null, null)]
        [InlineData("", "", "", "", "", "", "")]
        [InlineData("  ", "  ", "  ", "  ", "  ", "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostPaymentsIfPaymentsIsInvalidAsync(
            string invalidAmount, string invalidBillerName, string invalidCountry,
            string invalidCustomer, string invalidRecurrence, string invalidType, string invalidReference)
        {
            // given
            var PostBillPayments = new PostBillPayments
            {
                Request = new CreateBillPaymentRequest
                {
                    Amount = invalidAmount,
                    BillerName = invalidBillerName,
                    Country = invalidCountry,
                    Customer = invalidCustomer,
                    Recurrence = invalidRecurrence,
                    Type = invalidType,
                    Reference = invalidReference,

                }
            };

            var invalidPaymentsException = new InvalidBillPaymentException();

            invalidPaymentsException.AddData(
                key: nameof(CreateBillPaymentRequest.Reference),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateBillPaymentRequest.Customer),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(CreateBillPaymentRequest.Type),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(CreateBillPaymentRequest.BillerName),
             values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateBillPaymentRequest.Country),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(CreateBillPaymentRequest.Amount),
               values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(CreateBillPaymentRequest.Recurrence),
              values: "Value is required");

            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidPaymentsException);

            // when
            ValueTask<PostBillPayments> PostBillPaymentsTask =
                this.billPaymentsService.PostCreateBillPaymentAsync(PostBillPayments);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(PostBillPaymentsTask.AsTask);

            // then
            actualBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostPaymentsIfPostPaymentsIsEmptyAsync()
        {
            // given
            var PostBillPayments = new PostBillPayments
            {
                Request = new CreateBillPaymentRequest
                {
                    Amount = string.Empty,
                    BillerName = string.Empty,
                    Country = string.Empty,
                    Customer = string.Empty,
                    Recurrence = string.Empty,
                    Type = string.Empty,
                    Reference = string.Empty,
                }
            };

            var invalidPaymentsException = new InvalidBillPaymentException();
            invalidPaymentsException.AddData(
                          key: nameof(CreateBillPaymentRequest.Reference),
                          values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateBillPaymentRequest.Customer),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(CreateBillPaymentRequest.Type),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(CreateBillPaymentRequest.BillerName),
             values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateBillPaymentRequest.Country),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(CreateBillPaymentRequest.Amount),
               values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(CreateBillPaymentRequest.Recurrence),
              values: "Value is required");

            var expectedBillPaymentValidationException =
                new BillPaymentValidationException(invalidPaymentsException);

            // when
            ValueTask<PostBillPayments> PostBillPaymentsTask =
                this.billPaymentsService.PostCreateBillPaymentAsync(PostBillPayments);

            BillPaymentValidationException actualBillPaymentValidationException =
                await Assert.ThrowsAsync<BillPaymentValidationException>(
                    PostBillPaymentsTask.AsTask);

            // then
            actualBillPaymentValidationException.Should().BeEquivalentTo(
                expectedBillPaymentValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}