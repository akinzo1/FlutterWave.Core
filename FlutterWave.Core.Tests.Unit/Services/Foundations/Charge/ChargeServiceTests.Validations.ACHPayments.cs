using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnApplePayIfChargeIsNullAsync()
        {
            // given
            ApplePay? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<ApplePay> PaymentsTask =
                this.chargeService.PostChargeApplePayRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeApplePayAsync(
                    It.IsAny<ExternalApplePayRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnApplePayIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new ApplePay();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ApplePayRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<ApplePay> ApplePayTask =
                this.chargeService.PostChargeApplePayRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    ApplePayTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeApplePayAsync(
                    It.IsAny<ExternalApplePayRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null, null)]
        [InlineData(0, "", "", "", "")]
        [InlineData(0, "  ", "  ", "  ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostApplePayIfParametersIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef, string invalidPhoneNumber)
        {
            // given
            var ApplePay = new ApplePay
            {
                Request = new ApplePayRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    Currency = invalidCurrency,
                    TxRef = invalidTxRef,
                    PhoneNumber = invalidPhoneNumber


                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ApplePayRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(ApplePayRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(ApplePayRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(ApplePayRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(ApplePayRequest.PhoneNumber),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<ApplePay> ApplePayTask =
                this.chargeService.PostChargeApplePayRequestAsync(ApplePay);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(ApplePayTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostApplePayIfPostParametersIsEmptyAsync()
        {
            // given
            var ApplePay = new ApplePay
            {
                Request = new ApplePayRequest
                {

                    TxRef = string.Empty,
                    Currency = string.Empty,
                    Email = string.Empty,
                    PhoneNumber = string.Empty,
                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ApplePayRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(ApplePayRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(ApplePayRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(ApplePayRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(ApplePayRequest.PhoneNumber),
               values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<ApplePay> ApplePayTask =
                this.chargeService.PostChargeApplePayRequestAsync(ApplePay);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    ApplePayTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}