



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
        public async Task ShouldRetrievePayoutSubaccountsAsync()
        {
            // given


            ExternalListPayoutSubaccountsResponse randomExternalListPayoutSubaccountsResponse =
                CreateRandomExternalListPayoutSubaccountsResponseResult();

            ExternalListPayoutSubaccountsResponse retrievedPayoutSubaccountsResult =
                randomExternalListPayoutSubaccountsResponse;

            ListPayoutSubaccounts expectedListPayoutSubaccountsResponse =
               ConvertToPayoutSubaccountResponse(retrievedPayoutSubaccountsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/payout-subaccounts")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedPayoutSubaccountsResult));

            // when
            ListPayoutSubaccounts actualResult =
                await this.flutterWaveClient.PayoutSubaccounts.RetrieveListPayoutSubaccountsAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedListPayoutSubaccountsResponse);
        }
    }
}
