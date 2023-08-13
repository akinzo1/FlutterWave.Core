



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnBulkCreateTransfersIfBulkCreateTransferIsNullAsync()
        {
            // given



            BulkCreateTransfers? nullBulkCreateTransfers = null;
            var nullBulkCreateTransfersException = new NullTransfersException();

            var exceptedTransfersValidationException =
                new TransfersValidationException(nullBulkCreateTransfersException);

            // when
            ValueTask<BulkCreateTransfers> TransfersTask =
                this.transfersService.PostCreateBulkTransferAsync(nullBulkCreateTransfers);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    TransfersTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(exceptedTransfersValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTransferAsync(
                    It.IsAny<ExternalCreateBulkTransferRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnBulkCreateTransfersIfRequestIsNullAsync()
        {
            // given


            var invalidTransfers = new BulkCreateTransfers();
            invalidTransfers.Request = null;

            var invalidTransfersException =
                new InvalidTransfersException();

            invalidTransfersException.AddData(
                key: nameof(CreateBulkTransferRequest),
                values: "Value is required");


            var expectedTransfersValidationException =
                new TransfersValidationException(
                    invalidTransfersException);

            // when
            ValueTask<BulkCreateTransfers> BulkCreateTransfersTask =
                this.transfersService.PostCreateBulkTransferAsync(invalidTransfers);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    BulkCreateTransfersTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(expectedTransfersValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTransferAsync(
                    It.IsAny<ExternalCreateBulkTransferRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnPostBulkCreateTransfersIfInitiateTransferRequestIsInvalidAsync(
            string invalidTitle

            )
        {
            // given


            var validateTransfers = new BulkCreateTransfers
            {
                Request = new CreateBulkTransferRequest
                {

                    Title = invalidTitle



                }
            };

            var invalidTransfersException = new InvalidTransfersException();

            invalidTransfersException.AddData(
                   key: nameof(CreateBulkTransferRequest.Title),
                   values: "Value is required");

            invalidTransfersException.AddData(
                  key: nameof(CreateBulkTransferRequest.BulkData),
                  values: "Value is required");



            var expectedTransfersValidationException =
                new TransfersValidationException(invalidTransfersException);

            // when
            ValueTask<BulkCreateTransfers> BulkCreateTransfersTask =
                this.transfersService.PostCreateBulkTransferAsync(validateTransfers);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(BulkCreateTransfersTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostBulkCreateTransfersIfInitiateTransferRequestIsEmptyAsync()
        {
            // given


            var validateTransfers = new BulkCreateTransfers
            {
                Request = new CreateBulkTransferRequest
                {
                    Title = string.Empty
                }
            };

            var invalidTransfersException = new InvalidTransfersException();


            invalidTransfersException.AddData(
                  key: nameof(CreateBulkTransferRequest.Title),
                  values: "Value is required");

            invalidTransfersException.AddData(
                      key: nameof(CreateBulkTransferRequest.BulkData),
                      values: "Value is required");



            var expectedTransfersValidationException =
                new TransfersValidationException(invalidTransfersException);

            // when
            ValueTask<BulkCreateTransfers> BulkCreateTransfersTask =
                this.transfersService.PostCreateBulkTransferAsync(validateTransfers);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    BulkCreateTransfersTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}