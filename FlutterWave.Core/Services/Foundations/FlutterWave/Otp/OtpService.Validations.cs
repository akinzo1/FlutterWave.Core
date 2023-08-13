using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.OtpService
{
    internal partial class OtpService
    {
        private static void ValidateCreateOtp(CreateOtp otp)
        {
            ValidateCreateOtpNotNull(otp);
            ValidateOtpRequestNotNull(otp.Request);

            Validate(
                (Rule: IsInvalid(otp), Parameter: nameof(CreateOtp)));

            Validate(
                (Rule: IsInvalid(otp.Request.Sender), Parameter: nameof(CreateOtpRequest.Sender)),
                (Rule: IsInvalid(otp.Request.Expiry), Parameter: nameof(CreateOtpRequest.Expiry)),
                (Rule: IsInvalid(otp.Request.Length), Parameter: nameof(CreateOtpRequest.Length)),
                (Rule: IsInvalid(otp.Request.Customer), Parameter: nameof(CreateOtpRequest.Customer)),
                (Rule: IsInvalid(otp.Request.Medium), Parameter: nameof(CreateOtpRequest.Send)),
                (Rule: IsInvalid(otp.Request.Medium), Parameter: nameof(CreateOtpRequest.Medium))

                );

        }

        private static void ValidateOtpRequestNotNull(CreateOtpRequest request)
        {
            Validate(
                (Rule: IsInvalid(request), Parameter: nameof(CreateOtpRequest)));
        }

        private static void ValidateOtpCustomerRequestNotNull(CreateOtpRequest.CustomerModel request)
        {
            Validate(
                (Rule: IsInvalid(request.Email), Parameter: nameof(CreateOtpRequest.CustomerModel.Email)),
                (Rule: IsInvalid(request.Phone), Parameter: nameof(CreateOtpRequest.CustomerModel.Phone)),
                (Rule: IsInvalid(request.Name), Parameter: nameof(CreateOtpRequest.CustomerModel.Name))
                );
        }
        private static void ValidateOtp(ValidateOtp otp)
        {
            ValidateOtpNotNull(otp);

            Validate(
                (Rule: IsInvalid(otp.Request), Parameter: nameof(ValidateOtpRequest)));

            Validate(
                (Rule: IsInvalid(otp.Request.Otp), Parameter: nameof(ValidateOtpRequest.Otp))


                );

        }


        private static void ValidateCreateOtpNotNull(CreateOtp createOtp)
        {
            if (createOtp is null)
            {
                throw new NullOtpException();
            }
        }

        private static void ValidateOtpNotNull(ValidateOtp validateOtp)
        {
            if (validateOtp is null)
            {
                throw new NullOtpException();
            }
        }

        private static void ValidateOtpId(string otpId) =>
          Validate((Rule: IsInvalid(otpId), Parameter: nameof(CreateOtp)));

        private static void ValidateOtpInt(double otpInt) =>
           Validate(
               (Rule: IsInvalid(otpInt), Parameter: nameof(CreateOtp))
               );
        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };


        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private static dynamic IsInvalid(double number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidOtpException = new InvalidOtpException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidOtpException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidOtpException.ThrowIfContainsErrors();
        }
    }
}