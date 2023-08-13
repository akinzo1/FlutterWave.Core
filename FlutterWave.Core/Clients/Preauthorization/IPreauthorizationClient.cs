using FlutterWave.Core.Models.Clients.Preauthorization.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.Preauthorization
{
    public interface IPreauthorizationClient
    {
        /// <exception cref="PreauthorizationClientDependencyException" />
        /// <exception cref="PreauthorizationClientDependencyException" />
        /// <exception cref="PreauthorizationClientServiceException" />
        ValueTask<CreateCharge> CreateChargeAsync(
           CreateCharge externalCreateCharge, string encryptionKey);

        ValueTask<CaptureCharge> CaptureChargeAsync(
           string flwRef, CaptureCharge externalCaptureCharge);


        ValueTask<VoidCharge> VoidChargeAsync(
                 string flwRef);

        ValueTask<CreatePreauthorizationRefund> CreateRefundAsync(
               string flwRef, CreatePreauthorizationRefund externalCreatePreauthorizationRefund);
        ValueTask<CapturePayPalCharge> CapturePayPalChargeAsync(
               CapturePayPalCharge capturePayPalCharge);

        ValueTask<VoidPayPalCharge> VoidPayPalChargeAsync(
          string flwRef);
    }
}
