using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.PaymentPlanService
{
    internal interface IPaymentPlanService
    {
        ValueTask<CreatePaymentPlan> PostCreatePaymentPlanAsync(
                         CreatePaymentPlan paymentPlan);

        ValueTask<AllPaymentPlans> GetPaymentPlansAsync();
        ValueTask<PaymentPlan> GetPaymentPlanAsync(string paymentPlanId);

        ValueTask<UpdatePaymentPlan> UpdatePaymentPlanAsync(
            string paymentPlanId, UpdatePaymentPlan paymentPlan);

        ValueTask<PaymentPlan> PostCancelPaymentPlanAsync(string paymentPlanId);
    }
}
