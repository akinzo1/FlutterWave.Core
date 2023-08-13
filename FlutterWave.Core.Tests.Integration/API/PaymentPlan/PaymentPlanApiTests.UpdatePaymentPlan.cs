using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;

namespace FlutterWave.Core.Tests.Integration.API.PaymentPlans
{
    public partial class PaymentPlansApiTests
    {
        [Fact]
        public async Task ShouldUpdatePaymentPlansAsync()
        {

            // given
            string paymentPlanId = "3007";

            var updatePaymentPlan = new UpdatePaymentPlan
            {
                Request = new UpdatePaymentPlanRequest
                {
                    Name = "January neighbourhood contribution",
                    Status = "Active"
                }
            };

            // . when
            UpdatePaymentPlan responseAIModels =
                await this.flutterWaveClient.PaymentPlan.SendUpdatePaymentPlanAsync(paymentPlanId, updatePaymentPlan);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
