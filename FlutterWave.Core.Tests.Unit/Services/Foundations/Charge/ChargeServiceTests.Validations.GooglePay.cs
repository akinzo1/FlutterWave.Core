using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnGooglePayIfChargeIsNullAsync()
        {
            // given
            GooglePay? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<GooglePay> PaymentsTask =
                this.chargeService.PostChargeGooglePayRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGooglePayAsync(
                    It.IsAny<ExternalGooglePayRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnGooglePayIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new GooglePay();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(GooglePayRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<GooglePay> GooglePayTask =
                this.chargeService.PostChargeGooglePayRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    GooglePayTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGooglePayAsync(
                    It.IsAny<ExternalGooglePayRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null)]
        [InlineData(0, "", "", "")]
        [InlineData(0, "  ", "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostGooglePayIfGooglePayIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef)
        {
            // given
            var GooglePay = new GooglePay
            {
                Request = new GooglePayRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    Currency = invalidCurrency,
                    TxRef = invalidTxRef,



                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(GooglePayRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(GooglePayRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(GooglePayRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(GooglePayRequest.Amount),
             values: "Value is required");


            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<GooglePay> GooglePayTask =
                this.chargeService.PostChargeGooglePayRequestAsync(GooglePay);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(GooglePayTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostGooglePayIfPostGooglePayIsEmptyAsync()
        {
            // given
            var GooglePay = new GooglePay
            {
                Request = new GooglePayRequest
                {

                    TxRef = string.Empty,
                    Currency = string.Empty,
                    Email = string.Empty,

                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(GooglePayRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(GooglePayRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(GooglePayRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(GooglePayRequest.Amount),
             values: "Value is required");




            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<GooglePay> GooglePayTask =
                this.chargeService.PostChargeGooglePayRequestAsync(GooglePay);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    GooglePayTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}