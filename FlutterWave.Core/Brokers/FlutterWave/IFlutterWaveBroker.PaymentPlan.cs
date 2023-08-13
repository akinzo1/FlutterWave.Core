using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalPaymentPlanResponse> PostCreatePaymentPlanAsync(
                  ExternalCreatePaymentPlanRequest externalCreatePaymentPlanRequest);
        ValueTask<ExternalPaymentPlansResponse> GetPaymentPlansAsync();
        ValueTask<ExternalPaymentPlanResponse> GetPaymentPlanAsync(string paymentPlanId);
        ValueTask<ExternalPaymentPlanResponse> UpdatePaymentPlanAsync(
            string paymentPlanId, ExternalUpdatePaymentPlanRequest externalUpdatePaymentPlanRequest);
        ValueTask<ExternalPaymentPlanResponse> PostCancelPaymentPlanAsync(string paymentPlanId);


    }
}
