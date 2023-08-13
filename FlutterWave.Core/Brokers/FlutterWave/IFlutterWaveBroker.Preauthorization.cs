using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalCreateChargeResponse> PostCreateChargeAsync(
           ExternalEncryptedChargeRequest externalCreateChargeRequest);

        ValueTask<ExternalCaptureChargeResponse> PostCaptureChargeAsync(
           string flwRef, ExternalCaptureChargeRequest externalCaptureChargeResponse);


        ValueTask<ExternalVoidChargeResponse> PostVoidChargeAsync(
                 string flwRef);

        ValueTask<ExternalCreatePreauthorizationRefundResponse> PostCreateRefundAsync(
               string flwRef, ExternalCreatePreauthorizationRefundRequest externalCreatePreauthorizationRefundRequest);
        ValueTask<ExternalCapturePayPalChargeResponse> PostCapturePayPalChargeAsync(
               ExternalCapturePayPalChargeRequest flwRef);

        ValueTask<ExternalVoidPayPalChargeResponse> PostVoidPayPalChargeAsync(
          string flwRef);
    }
}
