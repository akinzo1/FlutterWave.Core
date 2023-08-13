



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.VirtualAccountsClient
{
    public partial class VirtualAccountsClientTests
    {
        [Fact]
        public async Task ShouldPostVirtualAccountsAsync()
        {

            // given
            CreateVirtualAccounts randomVirtualAccounts = CreateRandomCreateVirtualAccounts();
            CreateVirtualAccounts inputVirtualAccounts = randomVirtualAccounts;

            ExternalCreateVirtualAccountRequest externalVirtualAccountsRequest =
                ConvertToCreateVirtualAccountRequest(inputVirtualAccounts);

            ExternalCreateVirtualAccountResponse externalVirtualAccountsResponse =
                            CreateExternalCreateVirtualAccountResponseResult();

            CreateVirtualAccounts expectedVirtualAccounts = inputVirtualAccounts.DeepClone();
            expectedVirtualAccounts = ConvertToVirtualAccountsResponse(expectedVirtualAccounts, externalVirtualAccountsResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/virtual-account-numbers")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        externalVirtualAccountsRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(externalVirtualAccountsResponse));

            // when
            CreateVirtualAccounts actualResult =
                await this.flutterWaveClient.VirtualAccounts.CreateVirtualAccountAsync(inputVirtualAccounts);

            // then
            actualResult.Should().BeEquivalentTo(expectedVirtualAccounts);
        }
    }
}
