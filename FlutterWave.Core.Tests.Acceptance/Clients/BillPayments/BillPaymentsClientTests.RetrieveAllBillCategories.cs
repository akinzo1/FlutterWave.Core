



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
        public async Task ShouldRetrieveAllBillCategoriesAsync()
        {
            // given

            ExternalBillCategoriesResponse randomExternalBillCategoriesResponse =
                CreateExternalBillCategoriesResponseResult();

            ExternalBillCategoriesResponse retrievedBillCategoriesResult =
                randomExternalBillCategoriesResponse;

            BillCategories expectedBillCategoriesResponse =
                ConvertToBillPaymentResponse(retrievedBillCategoriesResult);


            this.wireMockServer.Given(
                Request.Create()
                       .UsingGet()
                       .WithPath($"/v3/bill-categories")
                       .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                     Response.Create()
                    .WithBodyAsJson(retrievedBillCategoriesResult));

            // when
            BillCategories actualResult =
                await this.flutterWaveClient.BillPayments.FetchBillCategoriesAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedBillCategoriesResponse);
        }
    }
}
