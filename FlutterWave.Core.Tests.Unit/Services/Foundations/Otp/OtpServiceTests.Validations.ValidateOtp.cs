



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Otp
{
    public partial class OtpServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnValidateOtpIfValidateOtpRequestIsNullAsync()
        {
            // given
            string inputOtpReference = GetRandomString();
            string inputOtp = GetRandomString();

            ValidateOtp? nullValidateOtp = null;
            var nullValidateOtpException = new NullOtpException();

            var exceptedOtpValidationException =
                new OtpValidationException(nullValidateOtpException);

            // when
            ValueTask<ValidateOtp> OtpTask =
                this.otpService.PostValidateOtpAsync(inputOtpReference, nullValidateOtp);

            OtpValidationException actualOtpValidationException =
                await Assert.ThrowsAsync<OtpValidationException>(
                    OtpTask.AsTask);

            // then
            actualOtpValidationException.Should()
                .BeEquivalentTo(exceptedOtpValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateOtpAsync(inputOtpReference,
                    It.IsAny<ExternalValidateOtpRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnValidateOtpIfRequestIsNullAsync()
        {
            // given
            string inputOtpReference = GetRandomString();

            var invalidOtp = new ValidateOtp();
            invalidOtp.Request = null;

            var invalidOtpException =
                new InvalidOtpException();

            invalidOtpException.AddData(
                key: nameof(ValidateOtpRequest),
                values: "Value is required");


            var expectedOtpValidationException =
                new OtpValidationException(
                    invalidOtpException);

            // when
            ValueTask<ValidateOtp> ValidateOtpTask =
                this.otpService.PostValidateOtpAsync(inputOtpReference, invalidOtp);

            OtpValidationException actualOtpValidationException =
                await Assert.ThrowsAsync<OtpValidationException>(
                    ValidateOtpTask.AsTask);

            // then
            actualOtpValidationException.Should()
                .BeEquivalentTo(expectedOtpValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateOtpAsync(inputOtpReference,
                    It.IsAny<ExternalValidateOtpRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnPostValidateOtpIfValidateOtpRequestIsInvalidAsync(
            string invalidOtp

            )
        {
            // given
            string inputOtpReference = GetRandomString();

            var validateOtp = new ValidateOtp
            {
                Request = new ValidateOtpRequest
                {

                    Otp = invalidOtp

                }
            };

            var invalidOtpException = new InvalidOtpException();

            invalidOtpException.AddData(
                   key: nameof(ValidateOtpRequest.Otp),
                   values: "Value is required");



            var expectedOtpValidationException =
                new OtpValidationException(invalidOtpException);

            // when
            ValueTask<ValidateOtp> ValidateOtpTask =
                this.otpService.PostValidateOtpAsync(inputOtpReference, validateOtp);

            OtpValidationException actualOtpValidationException =
                await Assert.ThrowsAsync<OtpValidationException>(ValidateOtpTask.AsTask);

            // then
            actualOtpValidationException.Should().BeEquivalentTo(
                expectedOtpValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


    }
}