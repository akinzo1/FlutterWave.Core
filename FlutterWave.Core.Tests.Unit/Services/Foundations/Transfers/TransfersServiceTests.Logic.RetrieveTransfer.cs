



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveTransfersByIdAsync()
        {
            // given 
            int inputTransfersId = GetRandomNumber();
            dynamic createRandomFetchTransfersProperties =
                     CreateRandomFetchTransferProperties();


            var randomExternalFetchTransfersResponse = new ExternalFetchTransferResponse
            {

                Message = createRandomFetchTransfersProperties.Message,
                Status = createRandomFetchTransfersProperties.Status,
                Data = new ExternalFetchTransferResponse.ExternalFetchTransferDataModel
                {
                    AccountNumber = createRandomFetchTransfersProperties.Data.AccountNumber,
                    Amount = createRandomFetchTransfersProperties.Data.Amount,
                    Approver = createRandomFetchTransfersProperties.Data.Approver,
                    BankCode = createRandomFetchTransfersProperties.Data.BankCode,
                    BankName = createRandomFetchTransfersProperties.Data.BankName,
                    CompleteMessage = createRandomFetchTransfersProperties.Data.CompleteMessage,
                    CreatedAt = createRandomFetchTransfersProperties.Data.CreatedAt,
                    Currency = createRandomFetchTransfersProperties.Data.Currency,
                    DebitCurrency = createRandomFetchTransfersProperties.Data.DebitCurrency,
                    Fee = createRandomFetchTransfersProperties.Data.Fee,
                    FullName = createRandomFetchTransfersProperties.Data.FullName,
                    Id = createRandomFetchTransfersProperties.Data.Id,
                    IsApproved = createRandomFetchTransfersProperties.Data.IsApproved,
                    Meta = createRandomFetchTransfersProperties.Data.Meta,
                    Narration = createRandomFetchTransfersProperties.Data.Narration,
                    Reference = createRandomFetchTransfersProperties.Data.Reference,
                    RequiresApproval = createRandomFetchTransfersProperties.Data.RequiresApproval,
                    Status = createRandomFetchTransfersProperties.Data.Status,
                }



            };

            var randomFetchTransfersResponse = new FetchTransferResponse
            {

                Message = createRandomFetchTransfersProperties.Message,
                Status = createRandomFetchTransfersProperties.Status,
                Data = new FetchTransferResponse.FetchTransferDataModel
                {
                    AccountNumber = createRandomFetchTransfersProperties.Data.AccountNumber,
                    Amount = createRandomFetchTransfersProperties.Data.Amount,
                    Approver = createRandomFetchTransfersProperties.Data.Approver,
                    BankCode = createRandomFetchTransfersProperties.Data.BankCode,
                    BankName = createRandomFetchTransfersProperties.Data.BankName,
                    CompleteMessage = createRandomFetchTransfersProperties.Data.CompleteMessage,
                    CreatedAt = createRandomFetchTransfersProperties.Data.CreatedAt,
                    Currency = createRandomFetchTransfersProperties.Data.Currency,
                    DebitCurrency = createRandomFetchTransfersProperties.Data.DebitCurrency,
                    Fee = createRandomFetchTransfersProperties.Data.Fee,
                    FullName = createRandomFetchTransfersProperties.Data.FullName,
                    Id = createRandomFetchTransfersProperties.Data.Id,
                    IsApproved = createRandomFetchTransfersProperties.Data.IsApproved,
                    Meta = createRandomFetchTransfersProperties.Data.Meta,
                    Narration = createRandomFetchTransfersProperties.Data.Narration,
                    Reference = createRandomFetchTransfersProperties.Data.Reference,
                    RequiresApproval = createRandomFetchTransfersProperties.Data.RequiresApproval,
                    Status = createRandomFetchTransfersProperties.Data.Status,
                }

            };

            var expectedTransfers = new FetchTransfers
            {
                Response = randomFetchTransfersResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransferAsync(inputTransfersId))
                    .ReturnsAsync(randomExternalFetchTransfersResponse);

            // when
            FetchTransfers actualTransfers =
               await this.transfersService.GetTransferAsync(inputTransfersId);

            // then
            actualTransfers.Should().BeEquivalentTo(expectedTransfers);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransferAsync(inputTransfersId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}