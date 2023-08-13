using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {

        ValueTask<ExternalCreateOtpResponse> PostCreateOtpAsync(
         ExternalCreateOtpRequest externalCreateOtpRequest);


        ValueTask<ExternalValidateOtpResponse> PostValidateOtpAsync(
          string otpReference, ExternalValidateOtpRequest externalValidateOtpRequest);

    }
}
