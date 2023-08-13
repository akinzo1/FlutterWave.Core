using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;

namespace FlutterWave.Core.Tests.Integration.API.PaymentPlans
{
    public partial class PaymentPlansApiTests
    {
        [Fact]
        public async Task ShouldCreatePaymentPlanAsync()
        {
            // given

            var inputPaymentPlan = new CreatePaymentPlan
            {
                Request = new CreatePaymentPlanRequest
                {
                    Amount = 1,
                    Duration = 3,
                    Interval = "Circle",
                    Name = "Airtime"
                }
            };

            // when
            CreatePaymentPlan retrievedAIModel =
              await this.flutterWaveClient.PaymentPlan.CreatePaymentPlanAsync(inputPaymentPlan);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}