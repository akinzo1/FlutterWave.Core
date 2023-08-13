



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
        public async Task ShouldPostUpdatePayoutSubaccountAsync()
        {

            // given
            UpdatePayoutSubaccount randomUpdatePayoutSubaccount = CreateRandomUpdatePayoutSubaccountResult();
            UpdatePayoutSubaccount inputUpdatePayoutSubaccount = randomUpdatePayoutSubaccount;
            string inputRandomId = GetRandomString();

            ExternalUpdatePayoutSubaccountRequest UpdatePayoutSubaccountRequest =
                ConvertToPayoutSubaccountRequest(inputUpdatePayoutSubaccount);

            ExternalUpdatePayoutSubaccountResponse UpdatePayoutSubaccountResponse =
                            CreateRandomExternalUpdatePayoutSubaccountResponseResult();

            UpdatePayoutSubaccount expectedUpdatePayoutSubaccount = inputUpdatePayoutSubaccount.DeepClone();
            expectedUpdatePayoutSubaccount = ConvertToPayoutSubaccountResponse(expectedUpdatePayoutSubaccount, UpdatePayoutSubaccountResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPut()
                    .WithPath($"/v3/payout-subaccounts/{inputRandomId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        UpdatePayoutSubaccountRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(UpdatePayoutSubaccountResponse));

            // when
            UpdatePayoutSubaccount actualResult =
                await this.flutterWaveClient.PayoutSubaccounts.UpdatePayoutSubaccountAsync(inputRandomId, inputUpdatePayoutSubaccount);

            // then
            actualResult.Should().BeEquivalentTo(expectedUpdatePayoutSubaccount);
        }
    }
}
