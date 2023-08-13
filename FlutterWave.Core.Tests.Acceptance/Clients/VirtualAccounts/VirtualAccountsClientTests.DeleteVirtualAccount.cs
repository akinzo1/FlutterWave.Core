



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
        public async Task ShouldDeleteVirtualAccountsAsync()
        {

            // given
            DeleteVirtualAccounts randomDeleteVirtualAccounts = CreateRandomDeleteVirtualAccounts();
            DeleteVirtualAccounts inputDeleteVirtualAccounts = randomDeleteVirtualAccounts;
            string inputReference = GetRandomString();

            ExternalDeleteVirtualAccountRequest externalDeleteVirtualAccountsRequest =
                ConvertToDeleteVirtualAccountRequest(inputDeleteVirtualAccounts);

            ExternalDeleteVirtualAccountResponse externalDeleteVirtualAccountsResponse =
                            CreateExternalDeleteVirtualAccountResponseResult();

            DeleteVirtualAccounts expectedDeleteVirtualAccounts = inputDeleteVirtualAccounts.DeepClone();
            expectedDeleteVirtualAccounts = ConvertToVirtualAccountsResponse(expectedDeleteVirtualAccounts, externalDeleteVirtualAccountsResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/virtual-account-numbers/{inputReference}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        externalDeleteVirtualAccountsRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(externalDeleteVirtualAccountsResponse));

            // when
            DeleteVirtualAccounts actualResult =
                await this.flutterWaveClient.VirtualAccounts.RemoveVirtualAccountsAsync(inputDeleteVirtualAccounts, inputReference);

            // then
            actualResult.Should().BeEquivalentTo(expectedDeleteVirtualAccounts);
        }
    }
}
