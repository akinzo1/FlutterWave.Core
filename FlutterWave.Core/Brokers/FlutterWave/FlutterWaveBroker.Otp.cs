using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {


        public async ValueTask<ExternalCreateOtpResponse> PostCreateOtpAsync(
          ExternalCreateOtpRequest externalCreateOtpRequest)
        {
            return await PostAsync<ExternalCreateOtpRequest, ExternalCreateOtpResponse>(
                relativeUrl: "v3/otps",
                content: externalCreateOtpRequest);
        }

        public async ValueTask<ExternalValidateOtpResponse> PostValidateOtpAsync(
         string otpReference, ExternalValidateOtpRequest externalValidateOtpRequest)
        {
            return await PostAsync<ExternalValidateOtpRequest, ExternalValidateOtpResponse>(
                relativeUrl: $"v3/otps/{otpReference}/validate",
                content: externalValidateOtpRequest);
        }
    }
}
