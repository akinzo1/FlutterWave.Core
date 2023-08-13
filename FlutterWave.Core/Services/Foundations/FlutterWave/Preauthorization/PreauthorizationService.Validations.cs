using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;

using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.PreauthorizationService
{
    internal partial class PreauthorizationService
    {


        private static void ValidateCreateCharge(CreateCharge createCharge)
        {
            ValidateCreateChargeNotNull(createCharge);
            ValidateCreateChargeRequestNotNull(createCharge.Request);
            Validate(
                (Rule: IsInvalid(createCharge), Parameter: nameof(createCharge)));

            Validate(
                (Rule: IsInvalid(createCharge.Request.Currency), Parameter: nameof(CreateChargeRequest.Currency)),
                (Rule: IsInvalid(createCharge.Request.Amount), Parameter: nameof(CreateChargeRequest.Amount)),
                (Rule: IsInvalid(createCharge.Request.CardNumber), Parameter: nameof(CreateChargeRequest.CardNumber)),
                (Rule: IsInvalid(createCharge.Request.Cvv), Parameter: nameof(CreateChargeRequest.Cvv)),
                (Rule: IsInvalid(createCharge.Request.Email), Parameter: nameof(CreateChargeRequest.Email)),
                (Rule: IsInvalid(createCharge.Request.ExpiryMonth), Parameter: nameof(CreateChargeRequest.ExpiryMonth)),
                (Rule: IsInvalid(createCharge.Request.TxRef), Parameter: nameof(CreateChargeRequest.TxRef))



                );

        }

        private static void ValidateCaptureCharge(CaptureCharge captureCharge)
        {
            ValidateCaptureChargeNotNull(captureCharge);
            ValidateCaptureChargeRequestNotNull(captureCharge.Request);
            Validate(
                (Rule: IsInvalid(captureCharge), Parameter: nameof(captureCharge)));

            Validate(
                (Rule: IsInvalid(captureCharge.Request.Amount), Parameter: nameof(CaptureChargeRequest.Amount))
                );

        }

        private static void ValidateCapturePaypalCharge(CapturePayPalCharge capturePayPalCharge)
        {
            ValidateCapturePayPalChargeNotNull(capturePayPalCharge);
            ValidateCapturePayPalChargeRequestNotNull(capturePayPalCharge.Request);
            Validate(
                (Rule: IsInvalid(capturePayPalCharge), Parameter: nameof(capturePayPalCharge)));

            Validate(
                (Rule: IsInvalid(capturePayPalCharge.Request.FlwRef), Parameter: nameof(CapturePayPalChargeRequest.FlwRef))
                );

        }

        private static void ValidateCreatePreauthorizationRefund(string flwRef, CreatePreauthorizationRefund createPreauthorizationRefund)
        {
            ValidateCreatePreauthorizationRefundNotNull(createPreauthorizationRefund);
            ValidateCreatePreauthorizationRefundRequestNotNull(createPreauthorizationRefund.Request);


            Validate(
                (Rule: IsInvalid(createPreauthorizationRefund), Parameter: nameof(createPreauthorizationRefund)));

            Validate(

                (Rule: IsInvalid(createPreauthorizationRefund.Request.Amount), Parameter: nameof(CreatePreauthorizationRefundRequest.Amount)),
                (Rule: IsInvalid(flwRef), Parameter: nameof(CreatePreauthorizationRefundRequest))
                );
        }



        private static void ValidateCaptureChargeRequestNotNull(CaptureChargeRequest createPreauthorizationRefund)
        {
            Validate((Rule: IsInvalid(createPreauthorizationRefund), Parameter: nameof(CaptureChargeRequest)));
        }
        private static void ValidateCapturePayPalChargeRequestNotNull(CapturePayPalChargeRequest capturePaypalChargeRequest)
        {
            Validate((Rule: IsInvalid(capturePaypalChargeRequest), Parameter: nameof(CapturePayPalChargeRequest)));
        }
        private static void ValidateCreateChargeRequestNotNull(CreateChargeRequest createPreauthorizationRefund)
        {
            Validate((Rule: IsInvalid(createPreauthorizationRefund), Parameter: nameof(CreateChargeRequest)));
        }

        private static void ValidateCreatePreauthorizationRefundRequestNotNull(CreatePreauthorizationRefundRequest createPreauthorizationRefund)
        {
            Validate((Rule: IsInvalid(createPreauthorizationRefund), Parameter: nameof(CreatePreauthorizationRefundRequest)));
        }

        private static void ValidateCreateChargeNotNull(CreateCharge createPreauthorizationRefund)
        {
            if (createPreauthorizationRefund is null)
            {
                throw new NullPreauthorizationException();
            }
        }

        private static void ValidateCapturePayPalChargeNotNull(CapturePayPalCharge capturePayPalCharge)
        {
            if (capturePayPalCharge is null)
            {
                throw new NullPreauthorizationException();
            }
        }
        private static void ValidateCreatePreauthorizationRefundNotNull(CreatePreauthorizationRefund createPreauthorizationRefund)
        {
            if (createPreauthorizationRefund is null)
            {
                throw new NullPreauthorizationException();
            }
        }



        private static void ValidateCaptureChargeNotNull(CaptureCharge createPreauthorizationRefund)
        {
            if (createPreauthorizationRefund is null)
            {
                throw new NullPreauthorizationException();
            }
        }

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };

        private static void ValidateCreatePreauthorizationRefundString(string reference) =>
            Validate((Rule: IsInvalid(reference), Parameter: nameof(CreatePreauthorizationRefund)));

        private static void ValidateVoidPayPalChargeString(string reference) =>
            Validate((Rule: IsInvalid(reference), Parameter: nameof(VoidPayPalCharge)));
        private static void ValidateVoidChargeString(string reference) =>
        Validate((Rule: IsInvalid(reference), Parameter: nameof(VoidCharge)));

        private static void ValidateCaptureChargeString(string reference) =>
       Validate((Rule: IsInvalid(reference), Parameter: nameof(CaptureCharge)));



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
            var invalidVirtualCardException = new InvalidPreauthorizationException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidVirtualCardException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidVirtualCardException.ThrowIfContainsErrors();
        }
    }
}