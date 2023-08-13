



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.PaymentPlanClient
{
    public partial class PaymentPlanClientTests
    {
        [Fact]
        public async Task ShouldCancelPaymentPlanByPlanIdAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomId = randomString;
            string inputPaymentPlanId = randomId;

            ExternalPaymentPlanResponse randomExternalCancelPaymentPlanResponse =
                CreateExternalPaymentPlanResponseResult();

            ExternalPaymentPlanResponse retrievedPaymentPlanResult =
                randomExternalCancelPaymentPlanResponse;

            PaymentPlan expectedBanksResponse =
                ConvertToPaymentPlanResponse(retrievedPaymentPlanResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingPut()
                    .WithPath($"/v3/payment-plans/{inputPaymentPlanId}/cancel")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedPaymentPlanResult));

            // when
            PaymentPlan actualResult =
                await this.flutterWaveClient.PaymentPlan.CancelPaymentPlanAsync(inputPaymentPlanId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
