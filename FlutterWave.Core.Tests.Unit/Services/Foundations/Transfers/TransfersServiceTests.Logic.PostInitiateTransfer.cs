



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldPostInitiateTransferWithInitiateTransfersRequestAsync()
        {
            // given
            string inputAccountBank = GetRandomString();
            int inputAmount = GetRandomNumber();
            string inputAccountNumber = GetRandomString();
            string inputCallBackUrl = GetRandomString();
            string inputCurrency = GetRandomString();
            string inputDebitCurrency = GetRandomString();
            string inputNarration = GetRandomString();
            string inputReference = GetRandomString();
            bool inputIsPermanent = GetRandomBoolean();



            dynamic createRandomInitiateTransferProperties =
                   CreateRandomInitiateTransferProperties();


            var randomExternalInitiateTransfersRequest = new ExternalInitiateTransferRequest
            {

                AccountBank = inputAccountBank,
                AccountNumber = inputAccountNumber,
                Amount = inputAmount,
                CallbackUrl = inputCallBackUrl,
                Currency = inputCurrency,
                DebitCurrency = inputDebitCurrency,
                Narration = inputNarration,
                Reference = inputReference

            };



            var randomExternalInitiateTransfersResponse = new ExternalInitiateTransferResponse
            {

                Message = createRandomInitiateTransferProperties.Message,
                Status = createRandomInitiateTransferProperties.Status,
                Data = new ExternalInitiateTransferResponse.ExternalInitiateTransferDataModel
                {
                    FullName = createRandomInitiateTransferProperties.Data.FullName,
                    Reference = createRandomInitiateTransferProperties.Data.Reference,
                    Narration = createRandomInitiateTransferProperties.Data.Narration,
                    DebitCurrency = createRandomInitiateTransferProperties.Data.DebitCurrency,
                    Currency = createRandomInitiateTransferProperties.Data.Currency,
                    Amount = createRandomInitiateTransferProperties.Data.Amount,
                    AccountNumber = createRandomInitiateTransferProperties.Data.AccountNumber,
                    BankCode = createRandomInitiateTransferProperties.Data.BankCode,
                    BankName = createRandomInitiateTransferProperties.Data.BankName,
                    CompleteMessage = createRandomInitiateTransferProperties.Data.CompleteMessage,
                    CreatedAt = createRandomInitiateTransferProperties.Data.CreatedAt,
                    Fee = createRandomInitiateTransferProperties.Data.Fee,
                    Id = createRandomInitiateTransferProperties.Data.Id,
                    IsApproved = createRandomInitiateTransferProperties.Data.IsApproved,
                    Meta = createRandomInitiateTransferProperties.Data.Meta,
                    RequiresApproval = createRandomInitiateTransferProperties.Data.RequiresApproval,
                    Status = createRandomInitiateTransferProperties.Data.Status
                }

            };



            var randomInitiateTransferResponse = new InitiateTransferResponse
            {

                Message = createRandomInitiateTransferProperties.Message,
                Status = createRandomInitiateTransferProperties.Status,
                Data = new InitiateTransferResponse.InitiateTransferDataModel
                {
                    FullName = createRandomInitiateTransferProperties.Data.FullName,
                    Reference = createRandomInitiateTransferProperties.Data.Reference,
                    Narration = createRandomInitiateTransferProperties.Data.Narration,
                    DebitCurrency = createRandomInitiateTransferProperties.Data.DebitCurrency,
                    Currency = createRandomInitiateTransferProperties.Data.Currency,
                    Amount = createRandomInitiateTransferProperties.Data.Amount,
                    AccountNumber = createRandomInitiateTransferProperties.Data.AccountNumber,
                    BankCode = createRandomInitiateTransferProperties.Data.BankCode,
                    BankName = createRandomInitiateTransferProperties.Data.BankName,
                    CompleteMessage = createRandomInitiateTransferProperties.Data.CompleteMessage,
                    CreatedAt = createRandomInitiateTransferProperties.Data.CreatedAt,
                    Fee = createRandomInitiateTransferProperties.Data.Fee,
                    Id = createRandomInitiateTransferProperties.Data.Id,
                    IsApproved = createRandomInitiateTransferProperties.Data.IsApproved,
                    Meta = createRandomInitiateTransferProperties.Data.Meta,
                    RequiresApproval = createRandomInitiateTransferProperties.Data.RequiresApproval,
                    Status = createRandomInitiateTransferProperties.Data.Status
                }

            };



            var randomInitiateTransfersRequest = new InitiateTransferRequest
            {
                AccountBank = inputAccountBank,
                AccountNumber = inputAccountNumber,
                Amount = inputAmount,
                CallbackUrl = inputCallBackUrl,
                Currency = inputCurrency,
                DebitCurrency = inputDebitCurrency,
                Narration = inputNarration,
                Reference = inputReference


            };


            var randomInitiateTransfer = new InitiateTransfers
            {
                Request = randomInitiateTransfersRequest,
            };

            InitiateTransfers inputInitiateTransfers = randomInitiateTransfer;
            InitiateTransfers expectedInitiateTransfers = inputInitiateTransfers.DeepClone();
            expectedInitiateTransfers.Response = randomInitiateTransferResponse;

            ExternalInitiateTransferRequest mappedExternalInitiateTransfersRequest =
               randomExternalInitiateTransfersRequest;

            ExternalInitiateTransferResponse returnedExternalInitiateTransfersResponse =
                randomExternalInitiateTransfersResponse;


            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostInitiateTransferAsync(It.Is(
                 SameExternalInitiateTransferRequestAs(mappedExternalInitiateTransfersRequest))))
                .ReturnsAsync(randomExternalInitiateTransfersResponse);


            // when
            InitiateTransfers actualInitiateTransfers =
                await this.transfersService.PostInitiateTransferAsync(inputInitiateTransfers);

            // then
            actualInitiateTransfers.Should().BeEquivalentTo(expectedInitiateTransfers);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostInitiateTransferAsync(It.Is(
                   SameExternalInitiateTransferRequestAs(mappedExternalInitiateTransfersRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}