using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;

namespace FlutterWave.Core.Tests.Integration.API.Preauthorization
{
    public partial class PreauthorizationApiTests
    {
        [Fact]
        public async Task ShouldPostCreateRefundAsync()
        {

            // given
            var request = new CreatePreauthorizationRefund
            {
                Request = new CreatePreauthorizationRefundRequest
                {
                    Amount = 100,
                }
            };

            var flwRef = "1234";
            // . when
            CreatePreauthorizationRefund responseAIModels =
                await this.flutterWaveClient.Preauthorization.CreateRefundAsync(flwRef, request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
