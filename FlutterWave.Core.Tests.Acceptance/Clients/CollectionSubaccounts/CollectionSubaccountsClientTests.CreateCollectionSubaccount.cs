



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
        public async Task ShouldCreateCollectionSubaccountAsync()
        {

            // given
            CreateCollectionSubaccount randomCreateCollectionSubaccount = CreateRandomCreateCollectionSubaccountResult();
            CreateCollectionSubaccount inputCreateCollectionSubaccount = randomCreateCollectionSubaccount;

            ExternalCreateCollectionSubaccountRequest CreateCollectionSubaccountRequest =
                ConvertToCollectionSubaccountRequest(inputCreateCollectionSubaccount);

            ExternalCreateCollectionSubaccountResponse CreateCollectionSubaccountResponse =
                            CreateRandomExternalCreateCollectionSubaccountResponseResult();

            CreateCollectionSubaccount expectedCreateCollectionSubaccount = inputCreateCollectionSubaccount.DeepClone();
            expectedCreateCollectionSubaccount = ConvertToCollectionSubaccountResponse(expectedCreateCollectionSubaccount, CreateCollectionSubaccountResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/subaccounts")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        CreateCollectionSubaccountRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(CreateCollectionSubaccountResponse));

            // when
            CreateCollectionSubaccount actualResult =
                await this.flutterWaveClient.CollectionSubaccounts.CreateCollectionSubaccountAsync(inputCreateCollectionSubaccount);

            // then
            actualResult.Should().BeEquivalentTo(expectedCreateCollectionSubaccount);
        }
    }
}
