



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
        public async Task ShouldRetrievePaymentPlansAsync()
        {
            // given

            ExternalPaymentPlansResponse randomExternalPaymentPlansResponse =
                CreateExternalPaymentPlansResponseResult();

            ExternalPaymentPlansResponse retrievedStatementResult =
                randomExternalPaymentPlansResponse;

            AllPaymentPlans expectedPaymentPlanResponse =
                ConvertToPaymentPlanResponse(retrievedStatementResult);


            this.wireMockServer.Given(
                Request.Create()
                       .UsingGet()
                       .WithPath($"/v3/payment-plans")
                       .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                     Response.Create()
                    .WithBodyAsJson(retrievedStatementResult));

            // when
            AllPaymentPlans actualResult =
                await this.flutterWaveClient.PaymentPlan.FetchPaymentPlansAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedPaymentPlanResponse);
        }
    }
}
