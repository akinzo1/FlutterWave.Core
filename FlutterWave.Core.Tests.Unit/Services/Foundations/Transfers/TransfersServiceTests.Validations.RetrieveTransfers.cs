



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Theory]
        [InlineData(0)]
        public async Task ShouldThrowValidationExceptionOnRetrieveTransfersIfInvalidIdAsync(
            int invalidTransactionId)
        {
            // given
            var invalidTransfersException =
                new InvalidTransfersException();

            invalidTransfersException.AddData(
                key: nameof(FetchTransfers),
                values: "Value is required");

            var expectedTransfersValidationException =
                new TransfersValidationException(invalidTransfersException);

            // when
            ValueTask<FetchTransfers> retrieveTransfersTask =
                this.transfersService.GetTransferAsync(invalidTransactionId);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(expectedTransfersValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransferAsync(
                   It.IsAny<int>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



    }
}