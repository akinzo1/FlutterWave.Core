



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
        public async Task ShouldPostBulkBillPaymentsAsync()
        {

            // given
            BulkBillPayments randomBulkBillPayments = CreateRandomBulkBillPaymentsResult();
            BulkBillPayments inputBulkBillPayments = randomBulkBillPayments;

            ExternalBulkBillPaymentsRequest BulkBillPaymentsRequest =
                ConvertToBulkBillPaymentRequest(inputBulkBillPayments);

            ExternalBulkBillPaymentsResponse BulkBillPaymentsResponse =
                            CreateExternalBulkBillPaymentsResponseResult();

            BulkBillPayments expectedBulkBillPayments = inputBulkBillPayments.DeepClone();
            expectedBulkBillPayments = ConvertToBillPaymentResponse(expectedBulkBillPayments, BulkBillPaymentsResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/bulk-bills")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        BulkBillPaymentsRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(BulkBillPaymentsResponse));

            // when
            BulkBillPayments actualResult =
                await this.flutterWaveClient.BillPayments.SendCreateBulkBillAsync(inputBulkBillPayments);

            // then
            actualResult.Should().BeEquivalentTo(expectedBulkBillPayments);
        }
    }
}
