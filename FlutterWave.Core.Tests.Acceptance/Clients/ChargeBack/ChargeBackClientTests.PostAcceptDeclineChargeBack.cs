



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.ChargeBackClient
{
    public partial class ChargeBackClientTests
    {
        [Fact]
        public async Task ShouldPostAcceptDeclineChargeBackAsync()
        {

            // given
            AcceptDeclineChargeBack randomAcceptDeclineChargeBack = CreateRandomAcceptDeclineChargeBack();
            AcceptDeclineChargeBack inputAcceptDeclineChargeBack = randomAcceptDeclineChargeBack;
            string inputChargeBackId = GetRandomString();

            ExternalAcceptDeclineChargeBackRequest AcceptDeclineChargeBackRequest =
                ConvertToAcceptDeclineRequest(inputAcceptDeclineChargeBack);

            ExternalAcceptDeclineChargeBackResponse AcceptDeclineChargeBackResponse =
                            CreateRandomAcceptDeclineChargeBackResult();

            AcceptDeclineChargeBack expectedAcceptDeclineChargeBack = inputAcceptDeclineChargeBack.DeepClone();
            expectedAcceptDeclineChargeBack = ConvertToChargeBackResponse(expectedAcceptDeclineChargeBack, AcceptDeclineChargeBackResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPut()
                    .WithPath($"/v3/chargebacks/{inputChargeBackId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        AcceptDeclineChargeBackRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(AcceptDeclineChargeBackResponse));

            // when
            AcceptDeclineChargeBack actualResult =
                await this.flutterWaveClient.ChargeBack.AcceptDeclineChargeBacksAsync(inputChargeBackId, inputAcceptDeclineChargeBack);

            // then
            actualResult.Should().BeEquivalentTo(expectedAcceptDeclineChargeBack);
        }
    }
}
