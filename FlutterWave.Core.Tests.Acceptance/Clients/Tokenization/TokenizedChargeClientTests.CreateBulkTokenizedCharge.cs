



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.TokenizedChargeClient
{
    public partial class TokenizedChargeClientTests
    {
        [Fact]
        public async Task ShouldCreateBulkTokenizedChargeAsync()
        {

            // given
            CreateBulkTokenizedCharge randomCreateBulkTokenizedCharge = CreateRandomCreateBulkTokenizedChargeResult();
            CreateBulkTokenizedCharge inputCreateBulkTokenizedCharge = randomCreateBulkTokenizedCharge;

            ExternalCreateBulkTokenizedChargeRequest CreateBulkTokenizedChargeRequest =
                ConvertToTokenizedChargeRequest(inputCreateBulkTokenizedCharge);

            ExternalCreateBulkTokenizedChargeResponse CreateBulkTokenizedChargeResponse =
                            CreateRandomExternalCreateBulkTokenizedChargeResponseResult();

            CreateBulkTokenizedCharge expectedCreateBulkTokenizedCharge = inputCreateBulkTokenizedCharge.DeepClone();
            expectedCreateBulkTokenizedCharge = ConvertToTokenizedChargeResponse(expectedCreateBulkTokenizedCharge, CreateBulkTokenizedChargeResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/bulk-tokenized-charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        CreateBulkTokenizedChargeRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(CreateBulkTokenizedChargeResponse));

            // when
            CreateBulkTokenizedCharge actualResult =
                await this.flutterWaveClient.TokenizedCharge.CreateBulkTokenizedChargeAsync(inputCreateBulkTokenizedCharge);

            // then
            actualResult.Should().BeEquivalentTo(expectedCreateBulkTokenizedCharge);
        }
    }
}
