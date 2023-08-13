



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Theory]
        [InlineData(0)]
        public async Task ShouldThrowValidationExceptionOnRetrieveTransferFeesIfInvalidAmountAsync(
            int invalidAmount)
        {
            // given
            var invalidTransfersException =
                new InvalidTransfersException();

            invalidTransfersException.AddData(
                key: nameof(TransferFees),
                values: "Value is required");

            var expectedTransfersValidationException =
                new TransfersValidationException(invalidTransfersException);

            // when
            ValueTask<TransferFees> retrieveTransfersTask =
                this.transfersService.GetAllTransferFeesAsync(invalidAmount);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(expectedTransfersValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllTransferFeesAsync(
                   It.IsAny<int>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



    }
}