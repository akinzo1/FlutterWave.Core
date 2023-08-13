using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;

namespace FlutterWave.Core.Tests.Integration.API.TokenizedCharge
{
    public partial class TokenizedChargeApiTests
    {
        [Fact]
        public async Task ShouldPostUpdateCardTokenAsync()
        {

            // given
            var request = new UpdateCardToken
            {
                Request = new UpdateCardTokenRequest
                {
                    Email = "wee",
                    FullName = "eedfgfddd",
                    PhoneNumber = " 2345677",
                }
            };

            var token = "1234";
            // . when
            UpdateCardToken responseAIModels =
                await this.flutterWaveClient.TokenizedCharge.UpdateCardTokenAsync(token, request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
