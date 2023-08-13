



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
        public async Task ShouldRetrieveBillPaymentsStatusAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomReference = randomString;
            string inputReference = randomReference;

            ExternalBillStatusPaymentResponse randomExternalBillStatusPaymentResponse =
                CreateExternalBillStatusPaymentResponseResult();

            ExternalBillStatusPaymentResponse retrievedBillPaymentsResult =
                randomExternalBillStatusPaymentResponse;

            BillPaymentsStatus expectedBillPaymentsStatusResponse =
               ConvertToBillPaymentResponse(retrievedBillPaymentsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/bills/{inputReference}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBillPaymentsResult));

            // when
            BillPaymentsStatus actualResult =
                await this.flutterWaveClient.BillPayments.FetchBillStatusPaymentAsync(inputReference);

            // then
            actualResult.Should().BeEquivalentTo(expectedBillPaymentsStatusResponse);
        }
    }
}
