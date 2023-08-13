using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;

namespace FlutterWave.Core.Tests.Integration.API.ChargeBacks
{
    public partial class ChargeBackApiTests
    {
        [Fact]
        public async Task ShouldPostAcceptOrDeclineChargeBackAsync()
        {
            // given
            string inputChargeBackId = "122";
            var inputAction = new AcceptDeclineChargeBack
            {
                Request = new AcceptDeclineChargeBackRequest
                {
                    Action = "accept",
                    Comment = "Service Rendered"
                }
            };

            // when
            AcceptDeclineChargeBack retrievedAIModel =
              await this.flutterWaveClient.ChargeBack.AcceptDeclineChargeBacksAsync(inputChargeBackId, inputAction);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}