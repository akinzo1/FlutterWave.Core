



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveVoidChargeWithReferenceDataIsInvalidAsync(
            string invalidFlwRef)
        {
            // given
            var invalidPreauthorizationException =
                new InvalidPreauthorizationException();

            invalidPreauthorizationException.AddData(
                key: nameof(VoidCharge),
                values: "Value is required");

            var expectedPreauthorizationValidationException =
                new PreauthorizationValidationException(invalidPreauthorizationException);

            // when
            ValueTask<VoidCharge> retrievePreauthorizationTask =
                this.preauthorizationService.PostVoidChargeRequestAsync(invalidFlwRef);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(
                    retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should()
                .BeEquivalentTo(expectedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVoidChargeAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}