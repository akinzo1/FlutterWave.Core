



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
        public async Task ShouldRetrieveSubaccountAvailableBalanceAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomReference = randomString;
            string inputReference = randomReference;

            string randomString4 = GetRandomString();
            string randomCurrency = randomString4;
            string inputCurrency = randomCurrency;

            ExternalFetchSubaccountAvailableBalanceResponse randomExternalFetchSubaccountAvailableBalanceResponse =
                CreateRandomExternalFetchSubaccountAvailableBalanceResponseResult();

            ExternalFetchSubaccountAvailableBalanceResponse retrievedPayoutSubaccountsResult =
                randomExternalFetchSubaccountAvailableBalanceResponse;

            FetchSubaccountAvailableBalance expectedFetchSubaccountAvailableBalanceResponse =
               ConvertToPayoutSubaccountResponse(retrievedPayoutSubaccountsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/payout-subaccounts/{inputReference}/balances")
                    .WithParam("currency", inputCurrency)
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedPayoutSubaccountsResult));

            // when
            FetchSubaccountAvailableBalance actualResult =
                await this.flutterWaveClient.PayoutSubaccounts.RetrievePayoutSubaccountsAvailableBalanceAsync(inputReference, inputCurrency);

            // then
            actualResult.Should().BeEquivalentTo(expectedFetchSubaccountAvailableBalanceResponse);
        }
    }
}
