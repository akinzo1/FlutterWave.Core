using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.OtpService
{
    internal partial class OtpService : IOtpService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public OtpService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<CreateOtp> PostCreateOtpAsync(CreateOtp otp) =>
        TryCatch(async () =>
        {
            ValidateCreateOtp(otp);
            ExternalCreateOtpRequest externalCreateOtpRequest = ConvertToCreateOtpRequest(otp);
            ExternalCreateOtpResponse externalCreateOtpResponse =
            await flutterWaveBroker.PostCreateOtpAsync(externalCreateOtpRequest);
            return ConvertToOtpResponse(otp, externalCreateOtpResponse);
        });

        public ValueTask<ValidateOtp> PostValidateOtpAsync(string otpReference, ValidateOtp otp) =>
        TryCatch(async () =>
        {
            ValidateOtp(otp);
            ExternalValidateOtpRequest externalValidateOtpRequest = ConvertToValidateOtpRequest(otp);
            ExternalValidateOtpResponse externalValidateOtpResponse =
            await flutterWaveBroker.PostValidateOtpAsync(otpReference, externalValidateOtpRequest);
            return ConvertToOtpResponse(otp, externalValidateOtpResponse);
        });

        private static ExternalValidateOtpRequest ConvertToValidateOtpRequest(ValidateOtp otp)
        {

            return new ExternalValidateOtpRequest
            {
                Otp = otp.Request.Otp
            };


        }

        private static ExternalCreateOtpRequest ConvertToCreateOtpRequest(CreateOtp otp)
        {

            return new ExternalCreateOtpRequest
            {
                Customer = new ExternalCreateOtpRequest.ExternalCustomerModel
                {
                    Email = otp.Request.Customer.Email,
                    Name = otp.Request.Customer.Name,
                    Phone = otp.Request.Customer.Phone,
                },
                Expiry = otp.Request.Expiry,
                Length = otp.Request.Length,
                Medium = otp.Request.Medium,
                Send = otp.Request.Send,
                Sender = otp.Request.Sender,
            };


        }


        private static CreateOtp ConvertToOtpResponse(CreateOtp otp, ExternalCreateOtpResponse externalCreateOtpResponse)
        {

            otp.Response = new CreateOtpResponse
            {
                Status = externalCreateOtpResponse.Status,
                Message = externalCreateOtpResponse.Message,
                Data = externalCreateOtpResponse.Data.Select(data =>
                {
                    return new CreateOtpResponse.Datum
                    {
                        Expiry = data.Expiry,
                        Medium = data.Medium,
                        Otp = data.Otp,
                        Reference = data.Reference
                    };
                }).ToList(),
            };
            return otp;


        }

        private static ValidateOtp ConvertToOtpResponse(ValidateOtp otp, ExternalValidateOtpResponse externalValidateOtpResponse)
        {
            otp.Response = new ValidateOtpResponse
            {
                Data = externalValidateOtpResponse.Data,
                Message = externalValidateOtpResponse.Message,
                Status = externalValidateOtpResponse.Status,
            };
            return otp;



        }


    }
}
