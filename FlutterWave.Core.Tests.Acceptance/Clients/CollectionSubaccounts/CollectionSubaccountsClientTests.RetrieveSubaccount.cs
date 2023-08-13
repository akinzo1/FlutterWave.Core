



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
        public async Task ShouldRetrieveSubaccountAsync()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomId = randomNumber;
            int inputSubaccountId = randomId;

            ExternalFetchSubaccountResponse randomExternalFetchSubaccountResponse =
                CreateRandomExternalFetchSubaccountResponseResult();

            ExternalFetchSubaccountResponse retrievedSubaccountsResult =
                randomExternalFetchSubaccountResponse;

            FetchSubaccount expectedFetchSubaccountResponse =
               ConvertToCollectionSubaccountResponse(retrievedSubaccountsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/subaccounts/{inputSubaccountId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedSubaccountsResult));

            // when
            FetchSubaccount actualResult =
                await this.flutterWaveClient.CollectionSubaccounts.RetrieveSubaccountAsync(inputSubaccountId);

            // then
            actualResult.Should().BeEquivalentTo(expectedFetchSubaccountResponse);
        }
    }
}
