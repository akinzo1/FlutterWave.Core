



using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.BillPaymentService
{
    internal partial class BillPaymentService
    {
        private static void ValidateBulkBillPayments(BulkBillPayments billPayments)
        {
            ValidateBulkBillPaymentsNotNull(billPayments);
            ValidateBulkBillPaymentsRequest(billPayments.Request);
            Validate(
                (Rule: IsInvalid(billPayments.Request), Parameter: nameof(billPayments.Request)));

            Validate(
                (Rule: IsInvalid(billPayments.Request.BulkReference), Parameter: nameof(BulkBillPaymentsRequest.BulkReference)),
                (Rule: IsInvalid(billPayments.Request.BulkData), Parameter: nameof(BulkBillPaymentsRequest.BulkData)),
                (Rule: IsInvalid(billPayments.Request.CallbackUrl), Parameter: nameof(BulkBillPaymentsRequest.CallbackUrl))
                );

        }


        private static void ValidateCreateBillPayment(PostBillPayments BillPayments)
        {
            ValidateCreateBillPaymentNotNull(BillPayments);
            ValidateCreateBillPaymentRequest(BillPayments.Request);
            Validate(
                (Rule: IsInvalid(BillPayments.Request), Parameter: nameof(BillPayments.Request)));

            Validate(
                (Rule: IsInvalid(BillPayments.Request.Country), Parameter: nameof(CreateBillPaymentRequest.Country)),
                (Rule: IsInvalid(BillPayments.Request.Type), Parameter: nameof(CreateBillPaymentRequest.Type)),
                (Rule: IsInvalid(BillPayments.Request.Recurrence), Parameter: nameof(CreateBillPaymentRequest.Recurrence)),
                (Rule: IsInvalid(BillPayments.Request.Reference), Parameter: nameof(CreateBillPaymentRequest.Reference)),
                (Rule: IsInvalid(BillPayments.Request.BillerName), Parameter: nameof(CreateBillPaymentRequest.BillerName)),
                (Rule: IsInvalid(BillPayments.Request.Amount), Parameter: nameof(CreateBillPaymentRequest.Amount)),
                (Rule: IsInvalid(BillPayments.Request.Customer), Parameter: nameof(CreateBillPaymentRequest.Customer))

                );

        }


        private static void ValidateCreateBillPaymentNotNull(PostBillPayments createBillPaymentRequest)
        {
            if (createBillPaymentRequest is null)
            {
                throw new NullBillPaymentException();
            }
        }

        private static void ValidateCreateBillPaymentRequest(CreateBillPaymentRequest createBillPaymentRequest)
        {
            Validate((Rule: IsInvalid(createBillPaymentRequest), Parameter: nameof(CreateBillPaymentRequest)));
        }
        private static void ValidateBulkBillPaymentsNotNull(BulkBillPayments bulkBillPayments)
        {
            if (bulkBillPayments is null)
            {
                throw new NullBillPaymentException();
            }
        }

        private static void ValidateBulkBillPaymentsRequest(BulkBillPaymentsRequest bulkBillPaymentsRequest)
        {
            Validate((Rule: IsInvalid(bulkBillPaymentsRequest), Parameter: nameof(BulkBillPaymentsRequest)));
        }

        private static void ValidateBillServiceParameters(string billPayment) =>
          Validate((Rule: IsInvalid(billPayment), Parameter: nameof(ValidateBillService)));

        private static void ValidateBillPaymentStatusParameters(string reference) =>
         Validate((Rule: IsInvalid(reference), Parameter: nameof(BillPaymentsStatus)));

        private static void ValidateBillPaymentInt(double billPayment) =>
           Validate(
               (Rule: IsInvalid(billPayment), Parameter: nameof(BillPayments))
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
            var invalidBillPaymentsException = new InvalidBillPaymentException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidBillPaymentsException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidBillPaymentsException.ThrowIfContainsErrors();
        }
    }
}