



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.TransfersClient
{
    public partial class TransfersClientTests
    {
        [Fact]
        public async Task ShouldRetrieveTransfersRatesAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCurrency = randomString;
            string inputCurrency = randomCurrency;

            string randomString2 = GetRandomString();
            string randomDestinationCurrency = randomString2;
            string inputDestinationCurrency = randomDestinationCurrency;

            int randomNumber = GetRandomNumber();
            int randomAmount = randomNumber;
            int inputAmount = randomAmount;

            ExternalTransferRatesResponse randomExternalTransferRatesResponse =
                CreateExternalTransferRatesResponseResult();

            ExternalTransferRatesResponse retrievedTransferRatesResult =
                randomExternalTransferRatesResponse;

            TransferRates expectedBanksResponse =
                ConvertToTransfersResponse(retrievedTransferRatesResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/v3/transfers/rates")
                    .WithParam("amount", inputAmount.ToString())
                    .WithParam("destination_currency", inputDestinationCurrency)
                    .WithParam("source_currency", inputCurrency)
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedTransferRatesResult));

            // when
            TransferRates actualResult =
                await this.flutterWaveClient.Transfers.RetrieveTransferRatesAsync(inputDestinationCurrency, inputAmount, inputCurrency);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
