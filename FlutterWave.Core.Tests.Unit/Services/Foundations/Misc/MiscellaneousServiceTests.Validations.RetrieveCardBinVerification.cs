



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveCardBinVerificationWithBinDataIsInvalidAsync(
            string invalidMiscReference)
        {
            // given
            var invalidMiscException =
                new InvalidMiscellaneousException();

            invalidMiscException.AddData(
                key: nameof(BinVerification),
                values: "Value is required");

            var expectedMiscValidationException =
                new MiscellaneousValidationException(invalidMiscException);

            // when
            ValueTask<BinVerification> retrieveMiscTask =
                this.miscellaneousService.GetCardBinVerificationAsync(invalidMiscReference);

            MiscellaneousValidationException actualMiscValidationException =
                await Assert.ThrowsAsync<MiscellaneousValidationException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscValidationException.Should()
                .BeEquivalentTo(expectedMiscValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetCardBinVerificationAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}