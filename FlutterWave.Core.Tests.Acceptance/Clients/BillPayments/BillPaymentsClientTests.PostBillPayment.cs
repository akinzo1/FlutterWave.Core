



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.BillPaymentsClient
{
    public partial class BillPaymentsClientTests
    {
        [Fact]
        public async Task ShouldPostBillPaymentAsync()
        {

            // given
            PostBillPayments randomPostBillPayments = CreateRandomPostBillPaymentsResult();
            PostBillPayments inputPostBillPayments = randomPostBillPayments;

            ExternalCreateBillPaymentRequest PostBillPaymentsRequest =
                ConvertToBillPaymentRequest(inputPostBillPayments);

            ExternalCreateBillPaymentResponse PostBillPaymentsResponse =
                            CreateExternalCreateBillPaymentResponseResult();

            PostBillPayments expectedPostBillPayments = inputPostBillPayments.DeepClone();
            expectedPostBillPayments = ConvertToBillPaymentResponse(expectedPostBillPayments, PostBillPaymentsResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/bills")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        PostBillPaymentsRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(PostBillPaymentsResponse));

            // when
            PostBillPayments actualResult =
                await this.flutterWaveClient.BillPayments.SendCreateBillPaymentAsync(inputPostBillPayments);

            // then
            actualResult.Should().BeEquivalentTo(expectedPostBillPayments);
        }
    }
}
