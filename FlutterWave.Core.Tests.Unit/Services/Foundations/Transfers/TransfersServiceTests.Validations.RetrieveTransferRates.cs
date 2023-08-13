



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Theory]
        [InlineData(null, 0, null)]
        [InlineData("", 0, "")]
        [InlineData(" ", 0, " ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveTransferRatesIfDeleteTransferRequestIsNullAsync(
            string invalidDestinationCurrency, int invalidAmount, string invalidSourceCurrency)
        {
            // given
            var invalidTransfersException =
                new InvalidTransfersException();

            invalidTransfersException.AddData(
                key: nameof(TransferRates),
                values: "Value is required");

            var expectedTransfersValidationException =
                new TransfersValidationException(invalidTransfersException);

            // when
            ValueTask<TransferRates> retrieveTransfersTask =
                this.transfersService.GetTransferRatesAsync(invalidDestinationCurrency, invalidAmount, invalidSourceCurrency);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(expectedTransfersValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransferRatesAsync(
                    It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



    }
}