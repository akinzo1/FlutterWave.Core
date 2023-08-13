



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveRetryTransfersByIdAsync()
        {
            // given 
            int inputTransfersId = GetRandomNumber();
            dynamic createRandomRetryTransferProperties =
                     CreateRandomRetryTransferProperties();


            var randomExternalRetryTransfersResponse = new ExternalRetryTransferResponse
            {

                Message = createRandomRetryTransferProperties.Message,
                Status = createRandomRetryTransferProperties.Status,
                Data = new ExternalRetryTransferResponse.Datum
                {
                    AccountNumber = createRandomRetryTransferProperties.Data.AccountNumber,
                    Amount = createRandomRetryTransferProperties.Data.Amount,
                    BankCode = createRandomRetryTransferProperties.Data.BankCode,
                    BankName = createRandomRetryTransferProperties.Data.BankName,
                    CompleteMessage = createRandomRetryTransferProperties.Data.CompleteMessage,
                    CreatedAt = createRandomRetryTransferProperties.Data.CreatedAt,
                    Currency = createRandomRetryTransferProperties.Data.Currency,
                    DebitCurrency = createRandomRetryTransferProperties.Data.DebitCurrency,
                    Fee = createRandomRetryTransferProperties.Data.Fee,
                    FullName = createRandomRetryTransferProperties.Data.FullName,
                    Id = createRandomRetryTransferProperties.Data.Id,
                    IsApproved = createRandomRetryTransferProperties.Data.IsApproved,
                    Meta = createRandomRetryTransferProperties.Data.Meta,
                    Reference = createRandomRetryTransferProperties.Data.Reference,
                    RequiresApproval = createRandomRetryTransferProperties.Data.RequiresApproval,
                    Status = createRandomRetryTransferProperties.Data.Status,

                }



            };

            var randomRetryTransfersResponse = new RetryTransferResponse
            {

                Message = createRandomRetryTransferProperties.Message,
                Status = createRandomRetryTransferProperties.Status,
                Data = new RetryTransferResponse.Datum
                {
                    AccountNumber = createRandomRetryTransferProperties.Data.AccountNumber,
                    Amount = createRandomRetryTransferProperties.Data.Amount,
                    BankCode = createRandomRetryTransferProperties.Data.BankCode,
                    BankName = createRandomRetryTransferProperties.Data.BankName,
                    CompleteMessage = createRandomRetryTransferProperties.Data.CompleteMessage,
                    CreatedAt = createRandomRetryTransferProperties.Data.CreatedAt,
                    Currency = createRandomRetryTransferProperties.Data.Currency,
                    DebitCurrency = createRandomRetryTransferProperties.Data.DebitCurrency,
                    Fee = createRandomRetryTransferProperties.Data.Fee,
                    FullName = createRandomRetryTransferProperties.Data.FullName,
                    Id = createRandomRetryTransferProperties.Data.Id,
                    IsApproved = createRandomRetryTransferProperties.Data.IsApproved,
                    Meta = createRandomRetryTransferProperties.Data.Meta,
                    Reference = createRandomRetryTransferProperties.Data.Reference,
                    RequiresApproval = createRandomRetryTransferProperties.Data.RequiresApproval,
                    Status = createRandomRetryTransferProperties.Data.Status,

                }

            };

            var expectedTransfers = new RetryTransfers
            {
                Response = randomRetryTransfersResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetRetryTransfersAsync(inputTransfersId))
                    .ReturnsAsync(randomExternalRetryTransfersResponse);

            // when
            RetryTransfers actualTransfers =
               await this.transfersService.GetRetryTransfersAsync(inputTransfersId);

            // then
            actualTransfers.Should().BeEquivalentTo(expectedTransfers);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRetryTransfersAsync(inputTransfersId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}