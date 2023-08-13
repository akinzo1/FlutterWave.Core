



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.PayoutSubaccountsClient
{
    public partial class PayoutSubaccountsClientTests
    {
        [Fact]
        public async Task ShouldRetrievePayoutSubaccountTransactionsAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomReference = randomString;
            string inputReference = randomReference;

            string randomString2 = GetRandomString();
            string randomFrom = randomString2;
            string inputFrom = randomFrom;

            string randomString3 = GetRandomString();
            string randomTo = randomString3;
            string inputTo = randomTo;

            string randomString4 = GetRandomString();
            string randomCurrency = randomString4;
            string inputCurrency = randomCurrency;

            ExternalFetchPayoutSubaccountTransactionsResponse randomExternalFetchPayoutSubaccountTransactionsResponse =
                CreateRandomExternalFetchPayoutSubaccountTransactionsResponseResult();

            ExternalFetchPayoutSubaccountTransactionsResponse retrievedPayoutSubaccountsResult =
                randomExternalFetchPayoutSubaccountTransactionsResponse;

            FetchPayoutSubaccountTransactions expectedFetchPayoutSubaccountTransactionsResponse =
               ConvertToPayoutSubaccountResponse(retrievedPayoutSubaccountsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/payout-subaccounts/{inputReference}/transactions")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithParam("from", inputFrom)
                    .WithParam("to", inputTo)
                    .WithParam("currency", inputCurrency))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedPayoutSubaccountsResult));

            // when
            FetchPayoutSubaccountTransactions actualResult =
                await this.flutterWaveClient.PayoutSubaccounts.RetrievePayoutSubaccountTransactionsAsync(inputReference, inputFrom, inputTo, inputCurrency);

            // then
            actualResult.Should().BeEquivalentTo(expectedFetchPayoutSubaccountTransactionsResponse);
        }
    }
}
