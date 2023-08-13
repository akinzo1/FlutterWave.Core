



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.BillPaymentsClient
{
    public partial class BillPaymentsClientTests
    {
        [Fact]
        public async Task ShouldRetrieveBillPaymentsByReferenceAsync()
        {
            // given


            ExternalBillPaymentsResponse randomExternalBillPaymentsResponse =
                CreateExternalBillPaymentsResult();

            ExternalBillPaymentsResponse retrievedBillPaymentsResult =
                randomExternalBillPaymentsResponse;

            BillPayments expectedBillPaymentsResponse =
                ConvertToBillPaymentResponse(retrievedBillPaymentsResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/v3/bills")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBillPaymentsResult));

            // when
            BillPayments actualResult =
                await this.flutterWaveClient.BillPayments.FetchBillPaymentsAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedBillPaymentsResponse);
        }
    }
}
