



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
        public async Task ShouldRetrieveValidateBillPaymentsByReferenceAsync()
        {
            // given
            string randomItemCode = GetRandomString();
            string inputItemCode = randomItemCode;
            string randomCustomer = GetRandomString();
            string inputCustomer = randomCustomer;
            string randomCode = GetRandomString();
            string inputCode = randomCode;

            ExternalValidateBillServiceResponse randomExternalValidateBillServiceResponse =
                CreateExternalValidateBillServiceResponseResult();

            ExternalValidateBillServiceResponse retrievedValidateBillPaymentResult =
                randomExternalValidateBillServiceResponse;

            ValidateBillService expectedValidatedBillServiceResponse =
               ConvertToBillPaymentResponse(retrievedValidateBillPaymentResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/bill-items/{inputItemCode}/validate")
                     .WithParam("code", inputCode)
                     .WithParam("customer", inputCustomer)
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedValidateBillPaymentResult));

            // when
            ValidateBillService actualResult =
                await this.flutterWaveClient.BillPayments.FetchValidateBillServiceAsync(inputItemCode, inputCode, inputCustomer);

            // then
            actualResult.Should().BeEquivalentTo(expectedValidatedBillServiceResponse);
        }
    }
}
