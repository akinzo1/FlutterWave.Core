



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveTransferRatesAsync()
        {
            // given 
            string inputCurrency = GetRandomString();
            string inputDestinationCurrency = GetRandomString();
            int inputAmount = GetRandomNumber();

            dynamic createRandomTransferRatesProperties =
                     CreateRandomTransferRatesProperties();


            var randomExternalTransferRatesResponse = new ExternalTransferRatesResponse
            {

                Message = createRandomTransferRatesProperties.Message,
                Status = createRandomTransferRatesProperties.Status,
                Data = new ExternalTransferRatesResponse.ExternalTransferRateModel
                {
                    Destination = new ExternalTransferRatesResponse.Destination
                    {
                        Amount = createRandomTransferRatesProperties.Data.Destination.Amount,
                        Currency = createRandomTransferRatesProperties.Data.Destination.Currency
                    },
                    Rate = createRandomTransferRatesProperties.Data.Rate,
                    Source = new ExternalTransferRatesResponse.Source
                    {
                        Amount = createRandomTransferRatesProperties.Data.Source.Amount,
                        Currency = createRandomTransferRatesProperties.Data.Source.Currency
                    }
                }

            };

            var randomTransferRatesResponse = new TransferRatesResponse
            {


                Message = createRandomTransferRatesProperties.Message,
                Status = createRandomTransferRatesProperties.Status,
                Data = new TransferRatesResponse.TransferRateModel
                {
                    Destination = new TransferRatesResponse.Destination
                    {
                        Amount = createRandomTransferRatesProperties.Data.Destination.Amount,
                        Currency = createRandomTransferRatesProperties.Data.Destination.Currency
                    },
                    Rate = createRandomTransferRatesProperties.Data.Rate,
                    Source = new TransferRatesResponse.Source
                    {
                        Amount = createRandomTransferRatesProperties.Data.Source.Amount,
                        Currency = createRandomTransferRatesProperties.Data.Source.Currency
                    }
                }


            };

            var expectedTransfers = new TransferRates
            {
                Response = randomTransferRatesResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputCurrency))
                    .ReturnsAsync(randomExternalTransferRatesResponse);

            // when
            TransferRates actualTransfers =
               await this.transfersService.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputCurrency);

            // then
            actualTransfers.Should().BeEquivalentTo(expectedTransfers);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}