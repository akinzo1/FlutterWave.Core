using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnValidateChargeIfChargeIsNullAsync()
        {
            // given
            ValidateCharge? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<ValidateCharge> PaymentsTask =
                this.chargeService.PostValidateChargeRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateChargeAsync(
                    It.IsAny<ExternalValidateChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnValidateChargeIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new ValidateCharge();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ValidateChargeRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<ValidateCharge> ValidateChargeTask =
                this.chargeService.PostValidateChargeRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    ValidateChargeTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateChargeAsync(
                    It.IsAny<ExternalValidateChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "", "")]
        [InlineData("  ", "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostValidateChargeIfValidateChargeIsInvalidAsync(
            string invalidOtp, string invalidFlwRef, string invalidType)
        {
            // given
            var ValidateCharge = new ValidateCharge
            {
                Request = new ValidateChargeRequest
                {
                    Otp = invalidOtp,
                    FlwRef = invalidFlwRef,
                    Type = invalidType,



                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ValidateChargeRequest.Otp),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(ValidateChargeRequest.FlwRef),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(ValidateChargeRequest.Type),
               values: "Value is required");



            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<ValidateCharge> ValidateChargeTask =
                this.chargeService.PostValidateChargeRequestAsync(ValidateCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(ValidateChargeTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostValidateChargeIfPostValidateChargeIsEmptyAsync()
        {
            // given
            var ValidateCharge = new ValidateCharge
            {
                Request = new ValidateChargeRequest
                {
                    Otp = string.Empty,
                    FlwRef = string.Empty,
                    Type = string.Empty,

                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ValidateChargeRequest.Otp),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(ValidateChargeRequest.FlwRef),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(ValidateChargeRequest.Type),
               values: "Value is required");



            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<ValidateCharge> ValidateChargeTask =
                this.chargeService.PostValidateChargeRequestAsync(ValidateCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    ValidateChargeTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}