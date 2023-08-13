



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
        public async Task ShouldUpdateBvnVirtualAccountsAsync()
        {

            // given
            UpdateBvnVirtualAccounts randomUpdateBvnVirtualAccounts = CreateRandomUpdateBvnVirtualAccounts();
            UpdateBvnVirtualAccounts inputUpdateBvnVirtualAccounts = randomUpdateBvnVirtualAccounts;
            string inputOrderReference = GetRandomString();

            ExternalUpdateVirtualAccountBvnRequest externalUpdateBvnVirtualAccountsRequest =
                ConvertToUpdateVirtualAccountBvnRequest(inputUpdateBvnVirtualAccounts);

            ExternalUpdateVirtualAccountBvnResponse externalUpdateBvnVirtualAccountsResponse =
                            CreateExternalUpdateVirtualAccountBvnResponseResult();

            UpdateBvnVirtualAccounts expectedUpdateBvnVirtualAccounts = inputUpdateBvnVirtualAccounts.DeepClone();
            expectedUpdateBvnVirtualAccounts = ConvertToVirtualAccountsResponse(
                expectedUpdateBvnVirtualAccounts, externalUpdateBvnVirtualAccountsResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPut()
                    .WithPath($"/v3/virtual-account-numbers/{inputOrderReference}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        externalUpdateBvnVirtualAccountsRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(externalUpdateBvnVirtualAccountsResponse));

            // when
            UpdateBvnVirtualAccounts actualResult =
                await this.flutterWaveClient.VirtualAccounts.UpdateVirtualAccountsBvnAsync(inputUpdateBvnVirtualAccounts, inputOrderReference);

            // then
            actualResult.Should().BeEquivalentTo(expectedUpdateBvnVirtualAccounts);
        }
    }
}
