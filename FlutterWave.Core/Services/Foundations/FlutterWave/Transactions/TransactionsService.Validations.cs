using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.TransactionsService
{
    internal partial class TransactionsService
    {
        private static void ValidateTransactionFees(FetchTransactionFeesRequest transactionFees)
        {
            ValidateTransactionFeesNotNull(transactionFees);

            Validate(
                (Rule: IsInvalid(transactionFees), Parameter: nameof(FetchTransactionFeesRequest)));

            Validate(
                (Rule: IsInvalid(transactionFees.Amount), Parameter: nameof(FetchTransactionFeesRequest.Amount)),
                (Rule: IsInvalid(transactionFees.Currency), Parameter: nameof(FetchTransactionFeesRequest.Currency))
                );

        }



        private static void ValidateMultipleTransactionRequestNotNull(FetchMultipleTransactionRequest request)
        {
            Validate(
                (Rule: IsInvalid(request), Parameter: nameof(MultipleTransaction)));
        }

        private static void ValidateTransactionFeesNotNull(FetchTransactionFeesRequest transactionFees)
        {
            if (transactionFees is null)
            {
                throw new NullTransactionsException();
            }
        }

        private static void ValidateMultipleTransactionNotNull(MultipleTransaction multipleTransaction)
        {
            if (multipleTransaction is null)
            {
                throw new NullTransactionsException();
            }
        }

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };

        private static void ValidateTransactionFees(int amount, string currency) =>
              Validate(
                (Rule: IsInvalid(amount), Parameter: nameof(TransactionFees)),
                (Rule: IsInvalid(currency), Parameter: nameof(TransactionFees))
                );

        private static void ValidateTransactionsId(string transactionsId) =>
            Validate((Rule: IsInvalid(transactionsId), Parameter: nameof(MultipleTransaction)));

        private static void ValidateRefundDetails(string transactionsId) =>
          Validate((Rule: IsInvalid(transactionsId), Parameter: nameof(RefundDetails)));

        private static void ValidateTransactionTimelineId(string transactionsId) =>
          Validate((Rule: IsInvalid(transactionsId), Parameter: nameof(TransactionTimeline)));


        private static void ValidateVerifyTransactionId(string transactionsId) =>
          Validate((Rule: IsInvalid(transactionsId), Parameter: nameof(VerifyTransaction)));

        private static void ValidateVerifyTransactionId(int transactionsId) =>
        Validate((Rule: IsInvalid(transactionsId), Parameter: nameof(VerifyTransaction)));

        private static void ValidateMultipleRefunds(string date) =>
            Validate((Rule: IsInvalid(date), Parameter: nameof(MultipleRefundTransaction)));

        private static void ValidateTransactionsDouble(double transactionsId) =>
        Validate(
            (Rule: IsInvalid(transactionsId), Parameter: nameof(CreateRefund)));
        private static void ValidateTransactionsInt(int transactionsInt) =>
           Validate(
               (Rule: IsInvalid(transactionsInt), Parameter: nameof(CreateRefund)));



        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private static dynamic IsInvalid(int number) => new
        {
            Condition = (number <= 0),
            Message = "A valid number is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidTransactionsException = new InvalidTransactionsException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidTransactionsException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidTransactionsException.ThrowIfContainsErrors();
        }
    }
}