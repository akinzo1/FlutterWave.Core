using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.PreauthorizationService
{
    internal interface IPreauthorizationService
    {
        ValueTask<CreateCharge> PostCreateChargeRequestAsync(
          CreateCharge externalCreateCharge, string encryptionKey);

        ValueTask<CaptureCharge> PostCaptureChargeRequestAsync(
           string flwRef, CaptureCharge externalCaptureCharge);


        ValueTask<VoidCharge> PostVoidChargeRequestAsync(
                 string flwRef);

        ValueTask<CreatePreauthorizationRefund> PostCreateRefundRequestAsync(
               string flwRef, CreatePreauthorizationRefund externalCreatePreauthorizationRefund);
        ValueTask<CapturePayPalCharge> PostCapturePayPalChargeRequestAsync(
               CapturePayPalCharge capturePayPalCharge);

        ValueTask<VoidPayPalCharge> PostVoidPayPalChargeRequestAsync(
          string flwRef);
    }
}
