



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
        public async Task ShouldPostENairaAsync()
        {

            // given
            ENaira randomENaira = CreateRandomENairaResult();
            ENaira inputENaira = randomENaira;

            ExternalENairaRequest ENairaRequest =
                ConvertToChargeRequest(inputENaira);

            ExternalENairaResponse ENairaResponse =
                            CreateRandomExternalENairaResponseResult();

            ENaira expectedENaira = inputENaira.DeepClone();
            expectedENaira = ConvertToChargeResponse(expectedENaira, ENairaResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "enaira")
                    .WithBody(JsonConvert.SerializeObject(
                        ENairaRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(ENairaResponse));

            // when
            ENaira actualResult =
                await this.flutterWaveClient.Charge.ChargeENairaAsync(inputENaira);

            // then
            actualResult.Should().BeEquivalentTo(expectedENaira);
        }
    }
}
