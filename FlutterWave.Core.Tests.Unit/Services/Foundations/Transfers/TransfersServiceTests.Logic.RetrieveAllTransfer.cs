



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveAllTransfersAsync()
        {
            // given 

            dynamic createRandomAllTransferProperties =
                     CreateRandomAllTransferProperties();


            var randomExternalAllTransferResponse = new ExternalAllTransfersResponse
            {

                Message = createRandomAllTransferProperties.Message,
                Status = createRandomAllTransferProperties.Status,
                Data = ((List<dynamic>)createRandomAllTransferProperties.Data).Select(data =>
                {
                    return new ExternalAllTransfersResponse.Datum
                    {
                        Id = data.Id,
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
                        IsApproved = data.IsApproved,
                        Meta = data.Meta,
                        Narration = data.Narration,
                        Reference = data.Reference,
                        RequiresApproval = data.RequiresApproval,
                        Status = data.Status,
                    };
                }).ToList(),
                Meta = new ExternalAllTransfersResponse.ExternalTransfersMetaModel
                {
                    PageInfo = new ExternalAllTransfersResponse.PageInfo
                    {
                        CurrentPage = createRandomAllTransferProperties.Meta.CurrentPage,
                        PageSize = createRandomAllTransferProperties.Meta.PageSize,
                        Total = createRandomAllTransferProperties.Meta.Total,
                        TotalPages = createRandomAllTransferProperties.Meta.TotalPages
                    }
                }

            };

            var randomAllTransferResponse = new AllTransfersResponse
            {


                Message = createRandomAllTransferProperties.Message,
                Status = createRandomAllTransferProperties.Status,
                Data = ((List<dynamic>)createRandomAllTransferProperties.Data).Select(data =>
                {
                    return new AllTransfersResponse.Datum
                    {
                        Id = data.Id,
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
                        IsApproved = data.IsApproved,
                        Meta = data.Meta,
                        Narration = data.Narration,
                        Reference = data.Reference,
                        RequiresApproval = data.RequiresApproval,
                        Status = data.Status,
                    };
                }).ToList(),
                Meta = new AllTransfersResponse.TransfersMetaModel
                {
                    PageInfo = new AllTransfersResponse.PageInfo
                    {
                        CurrentPage = createRandomAllTransferProperties.Meta.CurrentPage,
                        PageSize = createRandomAllTransferProperties.Meta.PageSize,
                        Total = createRandomAllTransferProperties.Meta.Total,
                        TotalPages = createRandomAllTransferProperties.Meta.TotalPages
                    }
                }


            };

            var expectedTransfers = new AllTransfers
            {
                Response = randomAllTransferResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllTransfersAsync())
                    .ReturnsAsync(randomExternalAllTransferResponse);

            // when
            AllTransfers actualTransfers =
               await this.transfersService.GetAllTransfersAsync();

            // then
            actualTransfers.Should().BeEquivalentTo(expectedTransfers);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllTransfersAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}