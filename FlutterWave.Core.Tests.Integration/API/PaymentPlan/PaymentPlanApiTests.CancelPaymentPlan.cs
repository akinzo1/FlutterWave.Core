using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;

namespace FlutterWave.Core.Tests.Integration.API.PaymentPlans
{
    public partial class PaymentPlansApiTests
    {
        [Fact]
        public async Task ShouldCancelPaymentPlanAsync()
        {

            // given
            string paymentPlanId = "34";
            // . when
            PaymentPlan responseAIModels =
                await this.flutterWaveClient.PaymentPlan.CancelPaymentPlanAsync(paymentPlanId);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
