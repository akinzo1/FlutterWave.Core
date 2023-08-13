using FlutterWave.Core.Models.Clients.Otp.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using FlutterWave.Core.Services.Foundations.FlutterWave.OtpService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.OTP
{
    internal class OtpClient : IOtpClient
    {
        private readonly IOtpService otpService;

        public OtpClient(IOtpService otpService) =>
              this.otpService = otpService;

        public async ValueTask<CreateOtp> CreateOtpAsync(CreateOtp otp)
        {
            try
            {
                return await otpService.PostCreateOtpAsync(otp);
            }
            catch (OtpValidationException OtpValidationException)
            {
                throw new OtpClientValidationException(
                    OtpValidationException.InnerException as Xeption);
            }
            catch (OtpDependencyValidationException OtpDependencyValidationException)
            {

                var message = OtpDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CreateOtp
                    {
                        Response = new CreateOtpResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new OtpClientValidationException(
                    OtpDependencyValidationException.InnerException as Xeption);
            }
            catch (OtpDependencyException OtpDependencyException)
            {
                throw new OtpClientDependencyException(
                    OtpDependencyException.InnerException as Xeption);
            }
            catch (OtpServiceException OtpServiceException)
            {
                throw new OtpClientServiceException(
                    OtpServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<ValidateOtp> ValidateOtpAsync(string otpReference, ValidateOtp otp)
        {
            try
            {
                return await otpService.PostValidateOtpAsync(otpReference, otp);
            }
            catch (OtpValidationException OtpValidationException)
            {
                throw new OtpClientValidationException(
                    OtpValidationException.InnerException as Xeption);
            }
            catch (OtpDependencyValidationException OtpDependencyValidationException)
            {

                var message = OtpDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new ValidateOtp
                    {
                        Response = new ValidateOtpResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new OtpClientValidationException(
                    OtpDependencyValidationException.InnerException as Xeption);
            }
            catch (OtpDependencyException OtpDependencyException)
            {
                throw new OtpClientDependencyException(
                    OtpDependencyException.InnerException as Xeption);
            }
            catch (OtpServiceException OtpServiceException)
            {
                throw new OtpClientServiceException(
                    OtpServiceException.InnerException as Xeption);
            }
        }
    }
}
