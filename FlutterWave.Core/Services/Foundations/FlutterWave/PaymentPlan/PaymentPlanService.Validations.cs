using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.PaymentPlanService
{
    internal partial class PaymentPlanService
    {
        private static void ValidateCreatePaymentPlan(CreatePaymentPlan paymentPlan)
        {
            ValidateCreatePaymentPlanNotNull(paymentPlan);
            ValidateCreatePaymentPlanRequestNotNull(paymentPlan.Request);
            Validate(
                (Rule: IsInvalid(paymentPlan), Parameter: nameof(paymentPlan)));

            Validate(
                (Rule: IsInvalid(paymentPlan.Request.Amount), Parameter: nameof(CreatePaymentPlanRequest.Amount)),
                (Rule: IsInvalid(paymentPlan.Request.Interval), Parameter: nameof(CreatePaymentPlanRequest.Interval)),
                (Rule: IsInvalid(paymentPlan.Request.Duration), Parameter: nameof(CreatePaymentPlanRequest.Duration)),
                (Rule: IsInvalid(paymentPlan.Request.Name), Parameter: nameof(CreatePaymentPlanRequest.Name))

                );

        }

        private static void ValidateUpdatePaymentPlan(UpdatePaymentPlan paymentPlan)
        {
            ValidateUpdatePaymentPlanNotNull(paymentPlan);
            ValidateUpdatePaymentPlanRequestNotNull(paymentPlan.Request);
            Validate(
                (Rule: IsInvalid(paymentPlan), Parameter: nameof(paymentPlan)));

            Validate(
                (Rule: IsInvalid(paymentPlan.Request.Name), Parameter: nameof(UpdatePaymentPlanRequest.Name)),
                (Rule: IsInvalid(paymentPlan.Request.Status), Parameter: nameof(UpdatePaymentPlanRequest.Status))



                );

        }

        private static void ValidateCreatePaymentPlanRequestNotNull(CreatePaymentPlanRequest paymentPlan)
        {
            Validate((Rule: IsInvalid(paymentPlan), Parameter: nameof(CreatePaymentPlanRequest)));
        }
        private static void ValidateCreatePaymentPlanNotNull(CreatePaymentPlan paymentPlan)
        {
            if (paymentPlan is null)
            {
                throw new NullPaymentPlanException();
            }
        }

        private static void ValidateUpdatePaymentPlanRequestNotNull(UpdatePaymentPlanRequest paymentPlan)
        {
            Validate((Rule: IsInvalid(paymentPlan), Parameter: nameof(UpdatePaymentPlanRequest)));
        }

        private static void ValidateUpdatePaymentPlanNotNull(UpdatePaymentPlan paymentPlan)
        {
            if (paymentPlan is null)
            {
                throw new NullPaymentPlanException();
            }
        }

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };

        private static void ValidatePaymentPlanId(string paymentPlanId) =>
            Validate((Rule: IsInvalid(paymentPlanId), Parameter: nameof(PaymentPlan)));

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

        private static void ValidateTransferInt(int paymentPlan) =>
         Validate((Rule: IsInvalid(paymentPlan), Parameter: nameof(PaymentPlan)));

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidPaymentPlanException = new InvalidPaymentPlanException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidPaymentPlanException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidPaymentPlanException.ThrowIfContainsErrors();
        }
    }
}