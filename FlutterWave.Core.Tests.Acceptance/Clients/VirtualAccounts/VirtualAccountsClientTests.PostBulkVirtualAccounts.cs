



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
        public async Task ShouldPostBulkVirtualAccountsAsync()
        {

            // given
            BulkCreateVirtualAccounts randomBulkCreateVirtualAccounts = CreateRandomBulkCreateVirtualAccounts();
            BulkCreateVirtualAccounts inputBulkCreateVirtualAccounts = randomBulkCreateVirtualAccounts;
            string inputRandomId = GetRandomString();

            ExternalCreateBulkVirtualAccountsRequest externalBulkCreateVirtualAccountsRequest =
                ConvertToCreateBulkVirtualAccountRequest(inputBulkCreateVirtualAccounts);

            ExternalBulkCreateVirtualAccountsResponse externalBulkCreateVirtualAccountsResponse =
                            CreateExternalBulkCreateVirtualAccountsResponseResult();

            BulkCreateVirtualAccounts expectedBulkCreateVirtualAccounts = inputBulkCreateVirtualAccounts.DeepClone();
            expectedBulkCreateVirtualAccounts = ConvertToVirtualAccountsResponse(expectedBulkCreateVirtualAccounts, externalBulkCreateVirtualAccountsResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/bulk-virtual-account-numbers")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        externalBulkCreateVirtualAccountsRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(externalBulkCreateVirtualAccountsResponse));

            // when
            BulkCreateVirtualAccounts actualResult =
                await this.flutterWaveClient.VirtualAccounts.BulkCreateVirtualAccountsAsync(inputBulkCreateVirtualAccounts);

            // then
            actualResult.Should().BeEquivalentTo(expectedBulkCreateVirtualAccounts);
        }
    }
}
