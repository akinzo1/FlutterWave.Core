



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        public async Task ShouldThrowValidationExceptionOnBlockUnblockVirtualCardWithVirtualCardIdDataIsInvalidAsync(
            string invalidVirtualCardId, string invalidStatusAction)
        {
            // given


            var invalidVirtualCardsException =
                new InvalidVirtualCardsException();

            invalidVirtualCardsException.AddData(
                key: nameof(BlockUnblockVirtualCard),
                values: "Value is required");

            var expectedVirtualCardsValidationException =
                new VirtualCardsValidationException(invalidVirtualCardsException);

            // when
            ValueTask<BlockUnblockVirtualCard> retrieveVirtualCardsTask =
                this.virtualCardsService.PostBlockUnblockVirtualCardRequestAsync(invalidVirtualCardId, invalidStatusAction);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should()
                .BeEquivalentTo(expectedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBlockUnblockVirtualCardAsync(
                    It.IsAny<string>(), It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}