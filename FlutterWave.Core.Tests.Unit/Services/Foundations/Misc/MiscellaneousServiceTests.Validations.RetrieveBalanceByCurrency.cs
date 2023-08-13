



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
        public async Task ShouldThrowValidationExceptionOnRetrieveBalanceByCurrencyWithCurrencyCodeDataIsInvalidAsync(
            string invalidMiscellaneousReference)
        {
            // given
            var invalidMiscellaneousException =
                new InvalidMiscellaneousException();

            invalidMiscellaneousException.AddData(
                key: nameof(BalanceByCurrency),
                values: "Value is required");

            var expectedMiscellaneousValidationException =
                new MiscellaneousValidationException(invalidMiscellaneousException);

            // when
            ValueTask<BalanceByCurrency> retrieveMiscellaneousTask =
                this.miscellaneousService.GetBalanceByCurrencyAsync(invalidMiscellaneousReference);

            MiscellaneousValidationException actualMiscellaneousValidationException =
                await Assert.ThrowsAsync<MiscellaneousValidationException>(
                    retrieveMiscellaneousTask.AsTask);

            // then
            actualMiscellaneousValidationException.Should()
                .BeEquivalentTo(expectedMiscellaneousValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceByCurrencyAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}