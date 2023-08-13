



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.CollectionSubaccountClient
{
    public partial class CollectionSubaccountsClientTests
    {
        [Fact]
        public async Task ShouldUpdateSubaccountAsync()
        {

            // given
            UpdateSubaccount randomUpdateSubaccount = CreateRandomUpdateSubaccountResult();
            UpdateSubaccount inputUpdateSubaccount = randomUpdateSubaccount;
            int inputRandomId = GetRandomNumber();

            ExternalUpdateSubaccountRequest UpdateSubaccountRequest =
                ConvertToCollectionSubaccountRequest(inputUpdateSubaccount);

            ExternalUpdateSubaccountResponse UpdateSubaccountResponse =
                            CreateRandomExternalUpdateSubaccountResponseResult();

            UpdateSubaccount expectedUpdateSubaccount = inputUpdateSubaccount.DeepClone();
            expectedUpdateSubaccount = ConvertToCollectionSubaccountResponse(expectedUpdateSubaccount, UpdateSubaccountResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPut()
                    .WithPath($"/v3/subaccounts/{inputRandomId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        UpdateSubaccountRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(UpdateSubaccountResponse));

            // when
            UpdateSubaccount actualResult =
                await this.flutterWaveClient.CollectionSubaccounts.UpdateCollectionSubaccountAsync(inputRandomId, inputUpdateSubaccount);

            // then
            actualResult.Should().BeEquivalentTo(expectedUpdateSubaccount);
        }
    }
}
