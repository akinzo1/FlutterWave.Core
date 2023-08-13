using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;

namespace FlutterWave.Core.Tests.Integration.API.Miscellaneous
{
    public partial class MiscellaneousApiTests
    {
        [Fact]
        public async Task ShouldRetrieveStatementOfAccountAsync()
        {
            // given


            // when
            Statement retrievedAIModel =
              await this.flutterWaveClient.Miscellaneous.AccountStatementAsync();

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}