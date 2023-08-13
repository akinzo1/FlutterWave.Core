



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
        public async Task ShouldRetrievePayoutSubaccountAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomId = randomString;
            string inputPayoutSubaccountId = randomId;

            ExternalFetchPayoutSubaccountResponse randomExternalFetchPayoutSubaccountResponse =
                CreateRandomExternalFetchPayoutSubaccountResponseResult();

            ExternalFetchPayoutSubaccountResponse retrievedPayoutSubaccountsResult =
                randomExternalFetchPayoutSubaccountResponse;

            FetchPayoutSubaccount expectedFetchPayoutSubaccountResponse =
               ConvertToPayoutSubaccountResponse(retrievedPayoutSubaccountsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/payout-subaccounts/{inputPayoutSubaccountId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedPayoutSubaccountsResult));

            // when
            FetchPayoutSubaccount actualResult =
                await this.flutterWaveClient.PayoutSubaccounts.RetrievePayoutSubaccountAsync(inputPayoutSubaccountId);

            // then
            actualResult.Should().BeEquivalentTo(expectedFetchPayoutSubaccountResponse);
        }
    }
}
