



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCaptureChargeIfCaptureChargeIsNullAsync()
        {
            // given
            CaptureCharge? nullPreauthorization = null;
            var nullPreauthorizationException = new NullPreauthorizationException();

            var exceptedPreauthorizationValidationException =
                new PreauthorizationValidationException(nullPreauthorizationException);

            // when
            ValueTask<CaptureCharge> PaymentsTask =
                this.preauthorizationService.PostCaptureChargeRequestAsync(It.IsAny<string>(), nullPreauthorization);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should()
                .BeEquivalentTo(exceptedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCaptureChargeAsync(It.IsAny<string>(),
                    It.IsAny<ExternalCaptureChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCaptureChargeIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new CaptureCharge();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidPreauthorizationException();

            invalidPaymentsException.AddData(
                key: nameof(CaptureChargeRequest),
                values: "Value is required");

            var expectedPreauthorizationValidationException =
                new PreauthorizationValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<CaptureCharge> CaptureChargeTask =
                this.preauthorizationService.PostCaptureChargeRequestAsync(It.IsAny<string>(), invalidPayments);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(
                    CaptureChargeTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should()
                .BeEquivalentTo(expectedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCaptureChargeAsync(It.IsAny<string>(),
                    It.IsAny<ExternalCaptureChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null)]
        [InlineData(0, "")]
        [InlineData(0, " ")]
        public async Task ShouldThrowValidationExceptionOnPostCaptureChargeIfCaptureChargeIsInvalidAsync(
            int invalidAmount, string invalidFlwRef)
        {
            // given
            var captureCharge = new CaptureCharge
            {
                Request = new CaptureChargeRequest
                {
                    Amount = invalidAmount,


                }
            };



            var invalidPaymentsException = new InvalidPreauthorizationException();



            invalidPaymentsException.AddData(
                    key: nameof(CaptureChargeRequest.Amount),
                    values: "Value is required");







            var expectedPreauthorizationValidationException =
                new PreauthorizationValidationException(invalidPaymentsException);

            // when
            ValueTask<CaptureCharge> CaptureChargeTask =
                this.preauthorizationService.PostCaptureChargeRequestAsync(invalidFlwRef, captureCharge);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(CaptureChargeTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


    }
}