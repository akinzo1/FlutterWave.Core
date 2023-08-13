using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {


        public async ValueTask<ExternalPaymentPlanResponse> PostCreatePaymentPlanAsync(
          ExternalCreatePaymentPlanRequest externalCreatePaymentPlanRequest)
        {
            return await PostAsync<ExternalCreatePaymentPlanRequest, ExternalPaymentPlanResponse>(
                relativeUrl: "v3/payment-plans",
                content: externalCreatePaymentPlanRequest);
        }

        public async ValueTask<ExternalPaymentPlansResponse> GetPaymentPlansAsync()
        {
            return await GetAsync<ExternalPaymentPlansResponse>(
                relativeUrl: "v3/payment-plans");
        }

        public async ValueTask<ExternalPaymentPlanResponse> GetPaymentPlanAsync(string paymentPlanId)
        {
            return await GetAsync<ExternalPaymentPlanResponse>(
                relativeUrl: $"v3/payment-plans/{paymentPlanId}");
        }

        public async ValueTask<ExternalPaymentPlanResponse> UpdatePaymentPlanAsync(
            string paymentPlanId, ExternalUpdatePaymentPlanRequest externalUpdatePaymentPlanRequest)
        {
            return await PutAsync<ExternalUpdatePaymentPlanRequest, ExternalPaymentPlanResponse>(
                relativeUrl: $"v3/payment-plans/{paymentPlanId}",
                content: externalUpdatePaymentPlanRequest
                );
        }


        public async ValueTask<ExternalPaymentPlanResponse> PostCancelPaymentPlanAsync(string paymentPlanId)
        {
            return await PutAsync<ExternalPaymentPlanResponse>(
                relativeUrl: $"v3/payment-plans/{paymentPlanId}/cancel",
                content: null
                );
        }

    }
}
