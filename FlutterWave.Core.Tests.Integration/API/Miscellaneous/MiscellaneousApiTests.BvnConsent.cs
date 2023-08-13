using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;

namespace FlutterWave.Core.Tests.Integration.API.Miscellaneous
{
    public partial class MiscellaneousApiTests
    {
        [Fact]
        public async Task ShouldRetrieveBvnConsentAsync()
        {
            // given
            var bvn = new BvnConsent
            {
                Request = new BvnConsentRequest
                {
                    Bvn = "22416807419",
                    FirstName = "Ahmad",
                    LastName = "Abdulrazzak",
                    RedirectUrl = "panda-tut.com.ng"
                }
            };

            // when
            BvnConsent retrievedAIModel =
              await this.flutterWaveClient.Miscellaneous.BvnConsentAsync(bvn);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}