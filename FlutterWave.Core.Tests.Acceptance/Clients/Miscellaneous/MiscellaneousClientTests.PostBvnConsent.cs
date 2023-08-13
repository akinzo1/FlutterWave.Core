



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.MiscellaneousClient
{
    public partial class MiscellaneousClientTests
    {
        [Fact]
        public async Task ShouldPostBvnConsentAsync()
        {

            // given
            BvnConsent randomBvnConsent = CreateRandomBvnConsent();
            BvnConsent inputBvnConsent = randomBvnConsent;

            ExternalBvnConsentRequest BvnConsentRequest =
                ConvertToBvnConsentRequest(inputBvnConsent);

            ExternalBvnConsentResponse BvnConsentResponse =
                            CreateExternalBvnConsentResponseResult();

            BvnConsent expectedBvnConsent = inputBvnConsent.DeepClone();
            expectedBvnConsent = ConvertToMiscellaneousResponse(expectedBvnConsent, BvnConsentResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/bvn/verifications")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        BvnConsentRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(BvnConsentResponse));

            // when
            BvnConsent actualResult =
                await this.flutterWaveClient.Miscellaneous.BvnConsentAsync(inputBvnConsent);

            // then
            actualResult.Should().BeEquivalentTo(expectedBvnConsent);
        }
    }
}
