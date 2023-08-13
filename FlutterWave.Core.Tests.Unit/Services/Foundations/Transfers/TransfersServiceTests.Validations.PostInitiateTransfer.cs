



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnInitiateTransfersIfInitiateTransferRequestIsNullAsync()
        {
            // given



            InitiateTransfers? nullInitiateTransfers = null;
            var nullInitiateTransfersException = new NullTransfersException();

            var exceptedTransfersValidationException =
                new TransfersValidationException(nullInitiateTransfersException);

            // when
            ValueTask<InitiateTransfers> TransfersTask =
                this.transfersService.PostInitiateTransferAsync(nullInitiateTransfers);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    TransfersTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(exceptedTransfersValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostInitiateTransferAsync(
                    It.IsAny<ExternalInitiateTransferRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnInitiateTransfersIfRequestIsNullAsync()
        {
            // given


            var invalidTransfers = new InitiateTransfers();
            invalidTransfers.Request = null;

            var invalidTransfersException =
                new InvalidTransfersException();

            invalidTransfersException.AddData(
                key: nameof(InitiateTransferRequest),
                values: "Value is required");


            var expectedTransfersValidationException =
                new TransfersValidationException(
                    invalidTransfersException);

            // when
            ValueTask<InitiateTransfers> InitiateTransfersTask =
                this.transfersService.PostInitiateTransferAsync(invalidTransfers);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    InitiateTransfersTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(expectedTransfersValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostInitiateTransferAsync(
                    It.IsAny<ExternalInitiateTransferRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null, null, null, null, null)]
        [InlineData("", "", "", "", "", "", "")]
        [InlineData(" ", " ", " ", " ", " ", " ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostInitiateTransfersIfInitiateTransferRequestIsInvalidAsync(
            string invalidAccountBank, string invalidAccountNumber, string invalidNarration, string invalidDebitCurrency,
            string invalidCallBackUrl, string invalidCurrency, string invalidReference

            )
        {
            // given


            var validateTransfers = new InitiateTransfers
            {
                Request = new InitiateTransferRequest
                {

                    AccountBank = invalidAccountBank,
                    AccountNumber = invalidAccountNumber,
                    Currency = invalidCurrency,
                    CallbackUrl = invalidCallBackUrl,
                    Reference = invalidReference,
                    DebitCurrency = invalidDebitCurrency,
                    Narration = invalidNarration,


                }
            };

            var invalidTransfersException = new InvalidTransfersException();

            invalidTransfersException.AddData(
                   key: nameof(InitiateTransferRequest.Amount),
                   values: "Value is required");

            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.Narration),
                      values: "Value is required");


            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.AccountBank),
                      values: "Value is required");


            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.DebitCurrency),
                      values: "Value is required");


            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.Reference),
                      values: "Value is required");


            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.AccountNumber),
                      values: "Value is required");


            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.CallbackUrl),
                      values: "Value is required");


            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.Currency),
                      values: "Value is required");



            var expectedTransfersValidationException =
                new TransfersValidationException(invalidTransfersException);

            // when
            ValueTask<InitiateTransfers> InitiateTransfersTask =
                this.transfersService.PostInitiateTransferAsync(validateTransfers);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(InitiateTransfersTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostInitiateTransfersIfInitiateTransferRequestIsEmptyAsync()
        {
            // given


            var validateTransfers = new InitiateTransfers
            {
                Request = new InitiateTransferRequest
                {


                    AccountBank = string.Empty,
                    AccountNumber = string.Empty,
                    Currency = string.Empty,
                    CallbackUrl = string.Empty,
                    Reference = string.Empty,
                    DebitCurrency = string.Empty,
                    Narration = string.Empty,

                }
            };

            var invalidTransfersException = new InvalidTransfersException();


            invalidTransfersException.AddData(
                  key: nameof(InitiateTransferRequest.Amount),
                  values: "Value is required");

            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.Narration),
                      values: "Value is required");


            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.AccountBank),
                      values: "Value is required");


            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.DebitCurrency),
                      values: "Value is required");


            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.Reference),
                      values: "Value is required");


            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.AccountNumber),
                      values: "Value is required");


            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.CallbackUrl),
                      values: "Value is required");


            invalidTransfersException.AddData(
                      key: nameof(InitiateTransferRequest.Currency),
                      values: "Value is required");



            var expectedTransfersValidationException =
                new TransfersValidationException(invalidTransfersException);

            // when
            ValueTask<InitiateTransfers> InitiateTransfersTask =
                this.transfersService.PostInitiateTransferAsync(validateTransfers);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    InitiateTransfersTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}