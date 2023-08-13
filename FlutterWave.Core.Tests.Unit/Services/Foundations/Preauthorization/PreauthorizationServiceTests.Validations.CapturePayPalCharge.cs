



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCapturePayPalChargeIfCaptureChargeRequestIsNullAsync()
        {
            // given
            CapturePayPalCharge? nullPreauthorization = null;
            var nullPreauthorizationException = new NullPreauthorizationException();

            var exceptedPreauthorizationValidationException =
                new PreauthorizationValidationException(nullPreauthorizationException);

            // when
            ValueTask<CapturePayPalCharge> PaymentsTask =
                this.preauthorizationService.PostCapturePayPalChargeRequestAsync(nullPreauthorization);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should()
                .BeEquivalentTo(exceptedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCapturePayPalChargeAsync(
                    It.IsAny<ExternalCapturePayPalChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCapturePayPalChargeIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new CapturePayPalCharge();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidPreauthorizationException();

            invalidPaymentsException.AddData(
                key: nameof(CapturePayPalChargeRequest),
                values: "Value is required");

            var expectedPreauthorizationValidationException =
                new PreauthorizationValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<CapturePayPalCharge> CapturePayPalChargeTask =
                this.preauthorizationService.PostCapturePayPalChargeRequestAsync(invalidPayments);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(
                    CapturePayPalChargeTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should()
                .BeEquivalentTo(expectedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCapturePayPalChargeAsync(
                    It.IsAny<ExternalCapturePayPalChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnPostCapturePayPalChargeIfCapturePayPalChargeIsInvalidAsync(
            string invalidAccountName)
        {
            // given
            var CapturePayPalCharge = new CapturePayPalCharge
            {
                Request = new CapturePayPalChargeRequest
                {
                    FlwRef = invalidAccountName



                }
            };

            var invalidPaymentsException = new InvalidPreauthorizationException();

            invalidPaymentsException.AddData(
                key: nameof(CapturePayPalChargeRequest.FlwRef),
                values: "Value is required");





            var expectedPreauthorizationValidationException =
                new PreauthorizationValidationException(invalidPaymentsException);

            // when
            ValueTask<CapturePayPalCharge> CapturePayPalChargeTask =
                this.preauthorizationService.PostCapturePayPalChargeRequestAsync(CapturePayPalCharge);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(CapturePayPalChargeTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCapturePayPalChargeIfPostCapturePayPalChargeIsEmptyAsync()
        {
            // given
            var CapturePayPalCharge = new CapturePayPalCharge
            {
                Request = new CapturePayPalChargeRequest
                {

                    FlwRef = string.Empty,

                }
            };

            var invalidPaymentsException = new InvalidPreauthorizationException();

            invalidPaymentsException.AddData(
                key: nameof(CapturePayPalChargeRequest.FlwRef),
                values: "Value is required");


            var expectedPreauthorizationValidationException =
                new PreauthorizationValidationException(invalidPaymentsException);

            // when
            ValueTask<CapturePayPalCharge> CapturePayPalChargeTask =
                this.preauthorizationService.PostCapturePayPalChargeRequestAsync(CapturePayPalCharge);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(
                    CapturePayPalChargeTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}