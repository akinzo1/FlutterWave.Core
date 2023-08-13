using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.ChargeBacks
{
    public partial class ChargeBackServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveChargeBackWithChargeBackReferenceDataIsInvalidAsync(
            string invalidChargeBackReference)
        {
            // given
            var invalidChargeBacksException =
                new InvalidChargeBackException();

            invalidChargeBacksException.AddData(
                key: nameof(ChargeBack),
                values: "Value is required");

            var expectedChargeBacksValidationException =
                new ChargeBackValidationException(invalidChargeBacksException);

            // when
            ValueTask<ChargeBack> retrieveChargeBacksTask =
                this.chargeBackService.GetChargeBackAsync(invalidChargeBackReference);

            ChargeBackValidationException actualChargeBacksValidationException =
                await Assert.ThrowsAsync<ChargeBackValidationException>(
                    retrieveChargeBacksTask.AsTask);

            // then
            actualChargeBacksValidationException.Should()
                .BeEquivalentTo(expectedChargeBacksValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRefundDetailsAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}