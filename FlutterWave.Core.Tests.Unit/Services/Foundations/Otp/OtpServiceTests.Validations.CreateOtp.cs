



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using Moq;
using static FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp.CreateOtpRequest;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Otp
{
    public partial class OtpServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateOtpIfCreateOtpRequestIsNullAsync()
        {
            // given
            CreateOtp? nullCreateOtp = null;
            var nullCreateOtpException = new NullOtpException();

            var exceptedOtpValidationException =
                new OtpValidationException(nullCreateOtpException);

            // when
            ValueTask<CreateOtp> OtpTask =
                this.otpService.PostCreateOtpAsync(nullCreateOtp);

            OtpValidationException actualOtpValidationException =
                await Assert.ThrowsAsync<OtpValidationException>(
                    OtpTask.AsTask);

            // then
            actualOtpValidationException.Should()
                .BeEquivalentTo(exceptedOtpValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateOtpAsync(
                    It.IsAny<ExternalCreateOtpRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateOtpIfRequestIsNullAsync()
        {
            // given
            var invalidOtp = new CreateOtp();
            invalidOtp.Request = null;

            var invalidOtpException =
                new InvalidOtpException();

            invalidOtpException.AddData(
                key: nameof(CreateOtpRequest),
                values: "Value is required");


            var expectedOtpValidationException =
                new OtpValidationException(
                    invalidOtpException);

            // when
            ValueTask<CreateOtp> CreateOtpTask =
                this.otpService.PostCreateOtpAsync(invalidOtp);

            OtpValidationException actualOtpValidationException =
                await Assert.ThrowsAsync<OtpValidationException>(
                    CreateOtpTask.AsTask);

            // then
            actualOtpValidationException.Should()
                .BeEquivalentTo(expectedOtpValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateOtpAsync(
                    It.IsAny<ExternalCreateOtpRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, 0, null, false, null, null)]
        public async Task ShouldThrowValidationExceptionOnPostCreateOtpIfCreateOtpRequestIsInvalidAsync(
            int invalidExpiry, int invalidLength,
            List<string> invalidMedium, bool invalidSend, string invalidSender, CustomerModel invalidCustomer
            )
        {
            // given
            var CreateOtp = new CreateOtp
            {
                Request = new CreateOtpRequest
                {

                    Customer = invalidCustomer,
                    Expiry = invalidExpiry,
                    Length = invalidLength,
                    Medium = invalidMedium,
                    Send = invalidSend,
                    Sender = invalidSender

                }
            };

            var invalidOtpException = new InvalidOtpException();

            invalidOtpException.AddData(
                   key: nameof(CreateOtpRequest.Customer),
                   values: "Value is required");

            invalidOtpException.AddData(
               key: nameof(CreateOtpRequest.Medium),
               values: "Value is required");

            invalidOtpException.AddData(
               key: nameof(CreateOtpRequest.Send),
               values: "Value is required");

            invalidOtpException.AddData(
              key: nameof(CreateOtpRequest.Sender),
              values: "Value is required");


            invalidOtpException.AddData(
              key: nameof(CreateOtpRequest.Expiry),
              values: "Value is required");

            invalidOtpException.AddData(
        key: nameof(CreateOtpRequest.Length),
        values: "Value is required");

            var expectedOtpValidationException =
                new OtpValidationException(invalidOtpException);

            // when
            ValueTask<CreateOtp> CreateOtpTask =
                this.otpService.PostCreateOtpAsync(CreateOtp);

            OtpValidationException actualOtpValidationException =
                await Assert.ThrowsAsync<OtpValidationException>(CreateOtpTask.AsTask);

            // then
            actualOtpValidationException.Should().BeEquivalentTo(
                expectedOtpValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


    }
}