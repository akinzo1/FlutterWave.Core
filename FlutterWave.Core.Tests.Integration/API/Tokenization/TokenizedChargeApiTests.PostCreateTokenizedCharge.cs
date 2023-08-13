using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;

namespace FlutterWave.Core.Tests.Integration.API.TokenizedCharge
{
    public partial class TokenizedChargeApiTests
    {
        [Fact]
        public async Task ShouldPostCreateTokenizedChargeAsync()
        {

            // given
            var request = new CreateTokenizedCharge
            {
                Request = new CreateTokenizedChargeRequest
                {
                    TxRef = "we",
                    Token = "NG",
                    LastName = "Ahmad",
                    Ip = "qe",
                    FirstName = "ee",
                    Email = "rtt",
                    Amount = 100,
                    Country = "NG",
                    Currency = "we",
                    Narration = "ytr"
                }
            };

            // . when
            CreateTokenizedCharge responseAIModels =
                await this.flutterWaveClient.TokenizedCharge.CreateTokenizedChargeAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
