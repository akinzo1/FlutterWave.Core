using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.OtpService
{
    internal interface IOtpService
    {
        ValueTask<CreateOtp> PostCreateOtpAsync(
        CreateOtp otp);


        ValueTask<ValidateOtp> PostValidateOtpAsync(
          string otpReference, ValidateOtp otp);
    }
}
