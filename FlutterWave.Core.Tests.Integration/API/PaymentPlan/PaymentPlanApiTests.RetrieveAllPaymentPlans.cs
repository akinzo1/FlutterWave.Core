using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;

namespace FlutterWave.Core.Tests.Integration.API.PaymentPlans
{
    public partial class PaymentPlansApiTests
    {
        [Fact]
        public async Task ShouldRetrieveAllPaymentPlansAsync()
        {

            // given

            // . when
            AllPaymentPlans responseAIModels =
                await this.flutterWaveClient.PaymentPlan.FetchPaymentPlansAsync();

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
