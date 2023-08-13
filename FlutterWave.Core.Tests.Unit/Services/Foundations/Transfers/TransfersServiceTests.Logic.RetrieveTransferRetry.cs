



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveTransferRetryByIdAsync()
        {
            // given 
            int inputAmount = GetRandomNumber();
            dynamic createRandomTransferRetryProperties =
                     CreateRandomTransferRetryProperties();


            var randomExternalFetchTransferRetryResponse = new ExternalFetchTransferRetryResponse
            {

                Message = createRandomTransferRetryProperties.Message,
                Status = createRandomTransferRetryProperties.Status,
                Data = ((List<dynamic>)createRandomTransferRetryProperties.Data).Select(data =>
                {
                    return new ExternalFetchTransferRetryResponse.Datum
                    {
                        Currency = data.Currency,
                        Fee = data.Fee,
                        AccountNumber = data.AccountNumber,
                        Amount = data.Amount,
                        BankCode = data.BankCode,
                        BankName = data.BankName,
                        CompleteMessage = data.CompleteMessage,
                        CreatedAt = data.CreatedAt,
                        DebitCurrency = data.DebitCurrency,
                        FullName = data.FullName,
                        Id = data.Id,
                        IsApproved = data.IsApproved,
                        Meta = data.Meta,
                        Narration = data.Narration,
                        Reference = data.Reference,
                        RequiresApproval = data.RequiresApproval,
                        Status = data.Status,
                    };
                }).ToList(),



            };

            var randomFetchTransferRetryResponse = new FetchTransferRetryResponse
            {

                Message = createRandomTransferRetryProperties.Message,
                Status = createRandomTransferRetryProperties.Status,
                Data = ((List<dynamic>)createRandomTransferRetryProperties.Data).Select(data =>
                {
                    return new FetchTransferRetryResponse.Datum
                    {
                        Currency = data.Currency,
                        Fee = data.Fee,
                        AccountNumber = data.AccountNumber,
                        Amount = data.Amount,
                        BankCode = data.BankCode,
                        BankName = data.BankName,
                        CompleteMessage = data.CompleteMessage,
                        CreatedAt = data.CreatedAt,
                        DebitCurrency = data.DebitCurrency,
                        FullName = data.FullName,
                        Id = data.Id,
                        IsApproved = data.IsApproved,
                        Meta = data.Meta,
                        Narration = data.Narration,
                        Reference = data.Reference,
                        RequiresApproval = data.RequiresApproval,
                        Status = data.Status,
                    };
                }).ToList(),



            };

            var expectedTransfers = new FetchRetryTransfers
            {
                Response = randomFetchTransferRetryResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransferRetryAsync(inputAmount))
                    .ReturnsAsync(randomExternalFetchTransferRetryResponse);

            // when
            FetchRetryTransfers actualTransfers =
               await this.transfersService.GetTransferRetryAsync(inputAmount);

            // then
            actualTransfers.Should().BeEquivalentTo(expectedTransfers);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransferRetryAsync(inputAmount),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}