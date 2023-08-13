



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.PreauthorizationClient
{
    public partial class PreauthorizationClientTests
    {
        [Fact]
        public async Task ShouldPostCreatePreauthorizationRefundAsync()
        {

            // given
            CreatePreauthorizationRefund randomCreatePreauthorizationRefund = CreateRandomCreatePreauthorizationRefundResult();
            CreatePreauthorizationRefund inputCreatePreauthorizationRefund = randomCreatePreauthorizationRefund;
            string inputFlwRef = GetRandomString();

            ExternalCreatePreauthorizationRefundRequest CreatePreauthorizationRefundRequest =
                ConvertToPreauthorizationRequest(inputCreatePreauthorizationRefund);

            ExternalCreatePreauthorizationRefundResponse CreatePreauthorizationRefundResponse =
                            CreateRandomExternalCreatePreauthorizationRefundResponseResult();

            CreatePreauthorizationRefund expectedCreatePreauthorizationRefund = inputCreatePreauthorizationRefund.DeepClone();
            expectedCreatePreauthorizationRefund = ConvertToPreauthorizationResponse(expectedCreatePreauthorizationRefund, CreatePreauthorizationRefundResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges/{inputFlwRef}/refund")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        CreatePreauthorizationRefundRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(CreatePreauthorizationRefundResponse));

            // when
            CreatePreauthorizationRefund actualResult =
                await this.flutterWaveClient.Preauthorization.CreateRefundAsync(inputFlwRef, inputCreatePreauthorizationRefund);

            // then
            actualResult.Should().BeEquivalentTo(expectedCreatePreauthorizationRefund);
        }
    }
}
