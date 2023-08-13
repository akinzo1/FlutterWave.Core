



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalBalance;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.MiscellaneousClient
{
    public partial class MiscellaneousClientTests
    {
        [Fact]
        public async Task ShouldRetrieveStatementOfAccountAsync()
        {
            // given

            ExternalStatementResponse randomExternalStatementResponse =
                CreateExternalStatementResponseResult();

            ExternalStatementResponse retrievedStatementResult =
                randomExternalStatementResponse;

            Statement expectedStatementResponse =
                ConvertToMiscellaneousResponse(retrievedStatementResult);


            this.wireMockServer.Given(
                Request.Create()
                       .UsingGet()
                       .WithPath($"/v3/wallet/statement/")
                       .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                     Response.Create()
                    .WithBodyAsJson(retrievedStatementResult));

            // when
            Statement actualResult =
                await this.flutterWaveClient.Miscellaneous.AccountStatementAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedStatementResponse);
        }
    }
}
