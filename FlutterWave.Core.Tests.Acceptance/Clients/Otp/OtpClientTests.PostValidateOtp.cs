



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
        public async Task ShouldPostValidateOtpAsync()
        {

            // given
            string inputOtpReference = GetRandomString();
            ValidateOtp randomValidateOtp = CreateRandomValidateOtp();
            ValidateOtp inputValidateOtp = randomValidateOtp;

            ExternalValidateOtpRequest ValidateOtpRequest =
                ConvertToValidateOtpRequest(inputValidateOtp);
            ExternalValidateOtpResponse ValidateOtpResponse =
                            CreateExternalValidateOtpResult();

            ValidateOtp expectedValidateOtp = inputValidateOtp.DeepClone();
            expectedValidateOtp = ConvertToOtpResponse(expectedValidateOtp, ValidateOtpResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/otps/{inputOtpReference}/validate")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        ValidateOtpRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(ValidateOtpResponse));

            // when
            ValidateOtp actualResult =
                await this.flutterWaveClient.Otp.ValidateOtpAsync(inputOtpReference, inputValidateOtp);

            // then
            actualResult.Should().BeEquivalentTo(expectedValidateOtp);
        }
    }
}
