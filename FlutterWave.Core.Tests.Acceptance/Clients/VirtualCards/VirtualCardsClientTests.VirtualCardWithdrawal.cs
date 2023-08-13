



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.VirtualCardsClient
{
    public partial class VirtualCardsClientTests
    {
        [Fact]
        public async Task ShouldPostVirtualCardWithdrawalAsync()
        {

            // given
            VirtualCardWithdrawal randomVirtualCardWithdrawal = CreateRandomVirtualCardWithdrawalResult();
            VirtualCardWithdrawal inputVirtualCardWithdrawal = randomVirtualCardWithdrawal;
            string inputRandomId = GetRandomString();

            ExternalVirtualCardWithdrawalRequest VirtualCardWithdrawalRequest =
                ConvertToVirtualCardRequest(inputVirtualCardWithdrawal);

            ExternalVirtualCardWithdrawalResponse VirtualCardWithdrawalResponse =
                            CreateRandomExternalVirtualCardWithdrawalResponseResult();

            VirtualCardWithdrawal expectedVirtualCardWithdrawal = inputVirtualCardWithdrawal.DeepClone();
            expectedVirtualCardWithdrawal = ConvertToVirtualCardResponse(expectedVirtualCardWithdrawal, VirtualCardWithdrawalResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/virtual-cards/{inputRandomId}/withdraw")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        VirtualCardWithdrawalRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(VirtualCardWithdrawalResponse));

            // when
            VirtualCardWithdrawal actualResult =
                await this.flutterWaveClient.VirtualCards.VirtualCardWithdrawalAsync(inputRandomId, inputVirtualCardWithdrawal);

            // then
            actualResult.Should().BeEquivalentTo(expectedVirtualCardWithdrawal);
        }
    }
}
