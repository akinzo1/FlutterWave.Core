



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveBulkTransfersByBatchIdAsync()
        {
            // given 
            string inputBatchId = GetRandomString();
            dynamic createRandomBulkTransferProperties =
                     CreateRandomFetchBulkTransferProperties();


            var randomExternalFetchBulkTransferResponse = new ExternalFetchBulkTransferResponse
            {


                Data = ((List<dynamic>)createRandomBulkTransferProperties.Data).Select(data =>
                     {
                         return new ExternalFetchBulkTransferResponse.Datum
                         {
                             Status = data.Status,
                             AccountNumber = data.AccountNumber,
                             Amount = data.Amount,
                             Approver = data.Approver,
                             BankCode = data.BankCode,
                             BankName = data.BankName,
                             CompleteMessage = data.CompleteMessage,
                             CreatedAt = data.CreatedAt,
                             Currency = data.Currency,
                             DebitCurrency = data.DebitCurrency,
                             Fee = data.Fee,
                             FullName = data.FullName,
                             Id = data.Id,
                             IsApproved = data.IsApproved,
                             Meta = data.Meta,
                             Narration = data.Narration,
                             Reference = data.Reference,
                             RequiresApproval = data.RequiresApproval
                         };
                     }).ToList(),
                Meta = new ExternalFetchBulkTransferResponse.ExternalMeta
                {
                    PageInfo = new ExternalFetchBulkTransferResponse.PageInfo
                    {
                        CurrentPage = createRandomBulkTransferProperties.Meta.PageInfo.CurrentPage,
                        Total = createRandomBulkTransferProperties.Meta.PageInfo.Total,
                        TotalPages = createRandomBulkTransferProperties.Meta.PageInfo.TotalPages
                    }
                },
                Message = createRandomBulkTransferProperties.Message,
                Status = createRandomBulkTransferProperties.Status,


            };

            var randomFetchBulkTransferResponse = new FetchBulkTransferResponse
            {


                Data = ((List<dynamic>)createRandomBulkTransferProperties.Data).Select(data =>
                {
                    return new FetchBulkTransferResponse.Datum
                    {
                        Status = data.Status,
                        AccountNumber = data.AccountNumber,
                        Amount = data.Amount,
                        Approver = data.Approver,
                        BankCode = data.BankCode,
                        BankName = data.BankName,
                        CompleteMessage = data.CompleteMessage,
                        CreatedAt = data.CreatedAt,
                        Currency = data.Currency,
                        DebitCurrency = data.DebitCurrency,
                        Fee = data.Fee,
                        FullName = data.FullName,
                        Id = data.Id,
                        IsApproved = data.IsApproved,
                        Meta = data.Meta,
                        Narration = data.Narration,
                        Reference = data.Reference,
                        RequiresApproval = data.RequiresApproval
                    };
                }).ToList(),
                Meta = new FetchBulkTransferResponse.ExternalMeta
                {
                    PageInfo = new FetchBulkTransferResponse.PageInfo
                    {
                        CurrentPage = createRandomBulkTransferProperties.Meta.PageInfo.CurrentPage,
                        Total = createRandomBulkTransferProperties.Meta.PageInfo.Total,
                        TotalPages = createRandomBulkTransferProperties.Meta.PageInfo.TotalPages
                    }
                },
                Message = createRandomBulkTransferProperties.Message,
                Status = createRandomBulkTransferProperties.Status,


            };

            var expectedTransfers = new FetchBulkTransfers
            {
                Response = randomFetchBulkTransferResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBulkTransferAsync(inputBatchId))
                    .ReturnsAsync(randomExternalFetchBulkTransferResponse);

            // when
            FetchBulkTransfers actualTransfers =
               await this.transfersService.GetBulkTransferAsync(inputBatchId);

            // then
            actualTransfers.Should().BeEquivalentTo(expectedTransfers);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTransferAsync(inputBatchId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}