



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.PayoutSubaccountsClient
{
    public partial class PayoutSubaccountsClientTests
    {
        [Fact]
        public async Task ShouldCreatePayoutSubaccountAsync()
        {

            // given
            CreatePayoutSubaccount randomCreatePayoutSubaccount = CreateRandomCreatePayoutSubaccountResult();
            CreatePayoutSubaccount inputCreatePayoutSubaccount = randomCreatePayoutSubaccount;

            ExternalCreatePayoutSubaccountRequest CreatePayoutSubaccountRequest =
                ConvertToPayoutSubaccountRequest(inputCreatePayoutSubaccount);

            ExternalCreatePayoutSubaccountResponse CreatePayoutSubaccountResponse =
                            CreateRandomExternalCreatePayoutSubaccountResponseResult();

            CreatePayoutSubaccount expectedCreatePayoutSubaccount = inputCreatePayoutSubaccount.DeepClone();
            expectedCreatePayoutSubaccount = ConvertToPayoutSubaccountResponse(expectedCreatePayoutSubaccount, CreatePayoutSubaccountResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/payout-subaccounts")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        CreatePayoutSubaccountRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(CreatePayoutSubaccountResponse));

            // when
            CreatePayoutSubaccount actualResult =
                await this.flutterWaveClient.PayoutSubaccounts.CreatePayoutSubaccountAsync(inputCreatePayoutSubaccount);

            // then
            actualResult.Should().BeEquivalentTo(expectedCreatePayoutSubaccount);
        }
    }
}
