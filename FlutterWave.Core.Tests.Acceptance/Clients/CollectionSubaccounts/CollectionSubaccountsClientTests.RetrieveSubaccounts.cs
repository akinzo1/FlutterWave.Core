



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.CollectionSubaccountClient
{
    public partial class CollectionSubaccountsClientTests
    {
        [Fact]
        public async Task ShouldRetrieveSubaccountsAsync()
        {
            // given


            ExternalFetchSubaccountsResponse randomExternalFetchSubaccountsResponse =
                CreateRandomExternalFetchSubaccountsResponseResult();

            ExternalFetchSubaccountsResponse retrievedSubaccountsResult =
                randomExternalFetchSubaccountsResponse;

            FetchSubaccounts expectedFetchSubaccountsResponse =
               ConvertToCollectionSubaccountResponse(retrievedSubaccountsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/subaccounts")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedSubaccountsResult));

            // when
            FetchSubaccounts actualResult =
                await this.flutterWaveClient.CollectionSubaccounts.RetrieveSubaccountsAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedFetchSubaccountsResponse);
        }
    }
}
