using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;

namespace FlutterWave.Core.Tests.Integration.API.Miscellaneous
{
    public partial class MiscellaneousApiTests
    {
        [Fact]
        public async Task ShouldVerifyCardBinAsync()
        {
            // given
            string inputCardBin = "123456";

            // when
            BinVerification retrievedAIModel =
              await this.flutterWaveClient.Miscellaneous.CardBinVerificationAsync(inputCardBin);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}