



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnTerminateVirtualCardWithVirtualCardIdDataIsInvalidAsync(
            string invalidVirtualCardId)
        {
            // given
            var invalidVirtualCardsException =
                new InvalidVirtualCardsException();

            invalidVirtualCardsException.AddData(
                key: nameof(TerminateVirtualCard),
                values: "Value is required");

            var expectedVirtualCardsValidationException =
                new VirtualCardsValidationException(invalidVirtualCardsException);

            // when
            ValueTask<TerminateVirtualCard> retrieveVirtualCardsTask =
                this.virtualCardsService.PostTerminateVirtualCardRequestAsync(invalidVirtualCardId);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should()
                .BeEquivalentTo(expectedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostTerminateVirtualCardAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}