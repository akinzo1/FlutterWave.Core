



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Theory]
        [InlineData(0)]
        public async Task ShouldThrowValidationExceptionOnRetrieveRetryTransfersIfInvalidAsync(
            int invalidTransactionId)
        {
            // given
            var invalidTransfersException =
                new InvalidTransfersException();

            invalidTransfersException.AddData(
                key: nameof(RetryTransfers),
                values: "Value is required");

            var expectedTransfersValidationException =
                new TransfersValidationException(invalidTransfersException);

            // when
            ValueTask<RetryTransfers> retrieveTransfersTask =
                this.transfersService.GetRetryTransfersAsync(invalidTransactionId);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(expectedTransfersValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRetryTransfersAsync(
                   It.IsAny<int>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



    }
}