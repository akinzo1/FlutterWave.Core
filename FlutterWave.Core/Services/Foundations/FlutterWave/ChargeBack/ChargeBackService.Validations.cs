using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.ChargeBackService
{
    internal partial class ChargeBackService
    {
        private static void ValidateChargeBack(string chargeBackId, AcceptDeclineChargeBack acceptDeclineChargeBack)
        {
            ValidateAcceptDeclineChargeBackNotNull(acceptDeclineChargeBack);
            ValidateAcceptDeclineChargeBackRequestNotNull(acceptDeclineChargeBack.Request);
            Validate(
                (Rule: IsInvalid(acceptDeclineChargeBack.Request), Parameter: nameof(AcceptDeclineChargeBackRequest)));

            Validate(
                (Rule: IsInvalid(acceptDeclineChargeBack.Request.Comment), Parameter: nameof(AcceptDeclineChargeBackRequest.Comment)),
                (Rule: IsInvalid(chargeBackId), Parameter: nameof(AcceptDeclineChargeBackRequest)),
                (Rule: IsInvalid(acceptDeclineChargeBack.Request.Action), Parameter: nameof(AcceptDeclineChargeBackRequest.Action))
                );

        }


        private static void ValidateAcceptDeclineChargeBackNotNull(AcceptDeclineChargeBack acceptDeclineChargeBack)
        {
            if (acceptDeclineChargeBack is null)
            {
                throw new NullChargeBackException();
            }
        }

        private static void ValidateAcceptDeclineChargeBackRequestNotNull(AcceptDeclineChargeBackRequest acceptDeclineChargeBackRequest)
        {
            Validate(
                 (Rule: IsInvalid(acceptDeclineChargeBackRequest), Parameter: nameof(AcceptDeclineChargeBackRequest)));
        }
        private static void ValidateChargeBackId(string chargeBackId) =>
             Validate((Rule: IsInvalid(chargeBackId), Parameter: nameof(ChargeBack)));

        private static void ValidateAcceptDeclineChargeBackId(string chargeBackId) =>
             Validate((Rule: IsInvalid(chargeBackId), Parameter: nameof(AcceptDeclineChargeBack)));

        private static void ValidateChargeBackInt(double chargeBackInt) =>
           Validate(
               (Rule: IsInvalid(chargeBackInt), Parameter: nameof(ChargeBack))
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
            Condition = number >= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidChargeBackException = new InvalidChargeBackException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidChargeBackException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidChargeBackException.ThrowIfContainsErrors();
        }
    }
}