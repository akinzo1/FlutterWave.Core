using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;

namespace FlutterWave.Core.Tests.Integration.API.PaymentPlans
{
    public partial class PaymentPlansApiTests
    {
        [Fact]
        public async Task ShouldRetrievePaymentPlanByReferenceAsync()
        {
            // given
            string inputPaymentPlanReference = "yuyutr";

            // when
            PaymentPlan retrievedAIModel =
              await this.flutterWaveClient.PaymentPlan.FetchPaymentPlanAsync(inputPaymentPlanReference);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}