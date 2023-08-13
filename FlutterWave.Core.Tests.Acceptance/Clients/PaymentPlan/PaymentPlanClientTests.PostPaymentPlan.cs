



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.PaymentPlanClient
{
    public partial class PaymentPlanClientTests
    {
        [Fact]
        public async Task ShouldPostPaymentPlanAsync()
        {

            // given
            CreatePaymentPlan randomPaymentPlan = CreateRandomCreatePaymentPlan();
            CreatePaymentPlan inputPaymentPlan = randomPaymentPlan;

            ExternalCreatePaymentPlanRequest PaymentPlanRequest =
                ConvertToPaymentPlanRequest(inputPaymentPlan);

            ExternalPaymentPlanResponse PaymentPlanResponse =
                            CreateExternalPaymentPlanResponseResult();

            CreatePaymentPlan expectedPaymentPlan = inputPaymentPlan.DeepClone();
            expectedPaymentPlan = ConvertToPaymentPlanResponse(expectedPaymentPlan, PaymentPlanResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/payment-plans")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        PaymentPlanRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(PaymentPlanResponse));

            // when
            CreatePaymentPlan actualResult =
                await this.flutterWaveClient.PaymentPlan.CreatePaymentPlanAsync(inputPaymentPlan);

            // then
            actualResult.Should().BeEquivalentTo(expectedPaymentPlan);
        }
    }
}
