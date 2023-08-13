



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveAllTransferFeesByAmountAsync()
        {
            // given 
            int inputAmount = GetRandomNumber();
            dynamic createRandomTransferFeesProperties =
                     CreateRandomTransferFeesProperties();


            var randomExternalTransferFeesResponse = new ExternalTransferFeesResponse
            {

                Message = createRandomTransferFeesProperties.Message,
                Status = createRandomTransferFeesProperties.Status,
                Data = ((List<dynamic>)createRandomTransferFeesProperties.Data).Select(data =>
                {
                    return new ExternalTransferFeesResponse.Datum
                    {
                        Currency = data.Currency,
                        Fee = data.Fee,
                        FeeType = data.FeeType,
                    };
                }).ToList(),



            };

            var randomTransferFeesResponse = new TransferFeesResponse
            {

                Message = createRandomTransferFeesProperties.Message,
                Status = createRandomTransferFeesProperties.Status,
                Data = ((List<dynamic>)createRandomTransferFeesProperties.Data).Select(data =>
                {
                    return new TransferFeesResponse.Datum
                    {
                        Currency = data.Currency,
                        Fee = data.Fee,
                        FeeType = data.FeeType,
                    };
                }).ToList(),

            };

            var expectedTransfers = new TransferFees
            {
                Response = randomTransferFeesResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllTransferFeesAsync(inputAmount))
                    .ReturnsAsync(randomExternalTransferFeesResponse);

            // when
            TransferFees actualTransfers =
               await this.transfersService.GetAllTransferFeesAsync(inputAmount);

            // then
            actualTransfers.Should().BeEquivalentTo(expectedTransfers);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllTransferFeesAsync(inputAmount),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}