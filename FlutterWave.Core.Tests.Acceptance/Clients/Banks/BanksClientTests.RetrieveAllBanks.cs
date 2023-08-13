



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBanks;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.Banks
{
    public partial class BanksClientTests
    {
        [Fact]
        public async Task ShouldRetrieveAllBanksByCountryAsync()
        {
            // given
            string randomString = CreateRandomString();
            string randomCountry = randomString;
            string inputRandomCountry = randomCountry;


            ExternalBankResponse randomExternalBanksResponse =
                CreateRandomExternalBanksResult();

            ExternalBankResponse retrievedBanksResult =
                randomExternalBanksResponse;

            Bank expectedBanksResponse =
                ConvertToBankResponse(retrievedBanksResult);


            this.wireMockServer.Given(
                Request.Create()
                       .UsingGet()
                       .WithPath($"/v3/banks/{inputRandomCountry}")
                       .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                     Response.Create()
                    .WithBodyAsJson(retrievedBanksResult));

            // when
            Bank actualResult =
                await this.flutterWaveClient.Banks.RetrieveAllBanksByCountryAsync(inputRandomCountry);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
