using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {
        public async ValueTask<ExternalCreateChargeResponse> PostCreateChargeAsync(
         ExternalEncryptedChargeRequest externalEncryptedChargeRequest)
        {
            return await PostAsync<ExternalEncryptedChargeRequest, ExternalCreateChargeResponse>(
                relativeUrl: "v3/charges?type=card",
                content: externalEncryptedChargeRequest);
        }

        public async ValueTask<ExternalCaptureChargeResponse> PostCaptureChargeAsync(
            string flwRef, ExternalCaptureChargeRequest externalCaptureChargeRequest)
        {
            return await PostAsync<ExternalCaptureChargeRequest, ExternalCaptureChargeResponse>(
                relativeUrl: $"v3/charges/{flwRef}/capture",
                content: externalCaptureChargeRequest);
        }


        public async ValueTask<ExternalVoidChargeResponse> PostVoidChargeAsync(
                 string flwRef)
        {
            return await PostAsync<ExternalVoidChargeResponse>(
                relativeUrl: $"v3/charges/{flwRef}/",
                content: null);
        }

        public async ValueTask<ExternalCreatePreauthorizationRefundResponse> PostCreateRefundAsync(
               string flwRef, ExternalCreatePreauthorizationRefundRequest externalCreatePreauthorizationRefundRequest)
        {
            return await PostAsync<ExternalCreatePreauthorizationRefundRequest, ExternalCreatePreauthorizationRefundResponse>(
                relativeUrl: $"v3/charges/{flwRef}/refund",
                content: externalCreatePreauthorizationRefundRequest);
        }
        public async ValueTask<ExternalCapturePayPalChargeResponse> PostCapturePayPalChargeAsync(
               ExternalCapturePayPalChargeRequest externalCapturePaypalChargeRequest)
        {
            return await PostAsync<ExternalCapturePayPalChargeRequest, ExternalCapturePayPalChargeResponse>(
                relativeUrl: "v3/charges/paypal-capture",
                content: externalCapturePaypalChargeRequest);
        }

        public async ValueTask<ExternalVoidPayPalChargeResponse> PostVoidPayPalChargeAsync(
          string flwRef)
        {
            return await PostAsync<ExternalVoidPayPalChargeResponse>(
                relativeUrl: $"v3/charges/paypal-void/{flwRef}",
                content: null
                );
        }
    }
}
