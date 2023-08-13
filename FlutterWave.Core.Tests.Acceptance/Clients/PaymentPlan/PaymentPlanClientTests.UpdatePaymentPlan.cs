



using FluentAssertions;
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
        public async Task ShouldUpdatePaymentPlanAsync()
        {

            // given
            UpdatePaymentPlan randomUpdatePaymentPlan = CreateRandomUpdatePaymentPlan();
            UpdatePaymentPlan inputUpdatePaymentPlan = randomUpdatePaymentPlan;
            string inputRandomId = GetRandomString();

            ExternalUpdatePaymentPlanRequest UpdatePaymentPlanRequest =
                ConvertToPaymentPlanRequest(inputUpdatePaymentPlan);

            ExternalPaymentPlanResponse UpdatePaymentPlanResponse =
                            CreateExternalPaymentPlanResponseResult();

            UpdatePaymentPlan expectedUpdatePaymentPlan = inputUpdatePaymentPlan.DeepClone();
            expectedUpdatePaymentPlan = ConvertToUpdatePaymentPlanResponse(expectedUpdatePaymentPlan, UpdatePaymentPlanResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPut()
                    .WithPath($"/v3/payment-plans/{inputRandomId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        UpdatePaymentPlanRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(UpdatePaymentPlanResponse));

            // when
            UpdatePaymentPlan actualResult =
                await this.flutterWaveClient.PaymentPlan.SendUpdatePaymentPlanAsync(inputRandomId, inputUpdatePaymentPlan);

            // then
            actualResult.Should().BeEquivalentTo(expectedUpdatePaymentPlan);
        }
    }
}
