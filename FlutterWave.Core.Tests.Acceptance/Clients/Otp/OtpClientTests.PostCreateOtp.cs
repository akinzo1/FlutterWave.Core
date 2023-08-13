



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.OtpClient
{
    public partial class OtpClientTests
    {
        [Fact]
        public async Task ShouldPostCreateOtpAsync()
        {

            // given
            CreateOtp randomCreateOtp = CreateRandomOtp();
            CreateOtp inputCreateOtp = randomCreateOtp;

            ExternalCreateOtpRequest CreateOtpRequest =
                ConvertToCreateOtpRequest(inputCreateOtp);
            ExternalCreateOtpResponse CreateOtpResponse =
                            CreateExternalCreateOtpResult();

            CreateOtp expectedCreateOtp = inputCreateOtp.DeepClone();
            expectedCreateOtp = ConvertToOtpResponse(expectedCreateOtp, CreateOtpResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath("/v3/otps")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        CreateOtpRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(CreateOtpResponse));

            // when
            CreateOtp actualResult =
                await this.flutterWaveClient.Otp.CreateOtpAsync(inputCreateOtp);

            // then
            actualResult.Should().BeEquivalentTo(expectedCreateOtp);
        }
    }
}
