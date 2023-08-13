



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.ChargeClient
{
    public partial class ChargeClientTests
    {
        [Fact]
        public async Task ShouldPostACHPaymentsAsync()
        {

            // given
            ACHPayments randomACHPayments = CreateRandomACHPaymentsResult();
            ACHPayments inputACHPayments = randomACHPayments;

            ExternalACHPaymentsRequest ACHPaymentsRequest =
                ConvertToChargeRequest(inputACHPayments);

            ExternalACHPaymentsResponse ACHPaymentsResponse =
                            CreateRandomExternalACHPaymentsResponseResult();

            ACHPayments expectedACHPayments = inputACHPayments.DeepClone();
            expectedACHPayments = ConvertToChargeResponse(expectedACHPayments, ACHPaymentsResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "ach_payment")
                    .WithBody(JsonConvert.SerializeObject(
                        ACHPaymentsRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(ACHPaymentsResponse));

            // when
            ACHPayments actualResult =
                await this.flutterWaveClient.Charge.ChargeACHPaymentsAsync(inputACHPayments);

            // then
            actualResult.Should().BeEquivalentTo(expectedACHPayments);
        }
    }
}
