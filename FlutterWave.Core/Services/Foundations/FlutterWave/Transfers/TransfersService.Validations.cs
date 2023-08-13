using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.TransfersService
{
    internal partial class TransfersService
    {
        private static void ValidateCreateBulkTransfers(BulkCreateTransfers transfer)
        {
            ValidateCreateBulkTransferNotNull(transfer);
            ValidateCreateBulkTransferRequestNotNull(transfer.Request);

            Validate(
                (Rule: IsInvalid(transfer), Parameter: nameof(BulkCreateTransfers)));

            Validate(
                (Rule: IsInvalid(transfer.Request.Title), Parameter: nameof(CreateBulkTransferRequest.Title)),
                (Rule: IsInvalid(transfer.Request.BulkData), Parameter: nameof(CreateBulkTransferRequest.BulkData))
                );

        }

        private static void ValidateInitiateTransfers(InitiateTransfers transfer)
        {
            ValidateInitiateTransferNotNull(transfer);
            ValidateInitiateTransferRequestNotNull(transfer.Request);
            Validate(
                (Rule: IsInvalid(transfer), Parameter: nameof(InitiateTransfers)));

            Validate(
                (Rule: IsInvalid(transfer.Request.AccountNumber), Parameter: nameof(InitiateTransferRequest.AccountNumber)),
                (Rule: IsInvalid(transfer.Request.Narration), Parameter: nameof(InitiateTransferRequest.Narration)),
                (Rule: IsInvalid(transfer.Request.Currency), Parameter: nameof(InitiateTransferRequest.Currency)),
                (Rule: IsInvalid(transfer.Request.Reference), Parameter: nameof(InitiateTransferRequest.Reference)),
                (Rule: IsInvalid(transfer.Request.AccountBank), Parameter: nameof(InitiateTransferRequest.AccountBank)),
                (Rule: IsInvalid(transfer.Request.Amount), Parameter: nameof(InitiateTransferRequest.Amount)),
                (Rule: IsInvalid(transfer.Request.CallbackUrl), Parameter: nameof(InitiateTransferRequest.CallbackUrl)),
                (Rule: IsInvalid(transfer.Request.DebitCurrency), Parameter: nameof(InitiateTransferRequest.DebitCurrency))

                );

        }

        private static void ValidateInitiateTransferNotNull(InitiateTransfers transfer)
        {
            if (transfer is null)
            {
                throw new NullTransfersException();
            }
        }

        private static void ValidateInitiateTransferRequestNotNull(InitiateTransferRequest transfer)
        {
            Validate((Rule: IsInvalid(transfer), Parameter: nameof(InitiateTransferRequest)));
        }

        private static void ValidateCreateBulkTransferRequestNotNull(CreateBulkTransferRequest transfer)
        {
            Validate((Rule: IsInvalid(transfer), Parameter: nameof(CreateBulkTransferRequest)));
        }

        private static void ValidateCreateBulkTransferNotNull(BulkCreateTransfers transfer)
        {
            if (transfer is null)
            {
                throw new NullTransfersException();
            }
        }

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


        private static void ValidateTransferText(string transfer) =>
            Validate((Rule: IsInvalid(transfer), Parameter: nameof(FetchRetryTransfers)));
        private static void ValidateTransferInt(int transfer) =>
           Validate((Rule: IsInvalid(transfer), Parameter: nameof(FetchRetryTransfers)));

        private static void ValidateTransferFees(int transfer) =>
           Validate((Rule: IsInvalid(transfer), Parameter: nameof(TransferFees)));

        private static void ValidateFetchBulkTransfer(string transfer) =>
           Validate((Rule: IsInvalid(transfer), Parameter: nameof(FetchBulkTransfers)));

        private static void ValidateRetryTransferId(int transfer) =>
         Validate((Rule: IsInvalid(transfer), Parameter: nameof(RetryTransfers)));

        private static void ValidateFetchTransferId(int transfer) =>
            Validate((Rule: IsInvalid(transfer), Parameter: nameof(FetchTransfers)));

        private static void ValidateTransferRates(string transfer) =>
        Validate((Rule: IsInvalid(transfer), Parameter: nameof(TransferRates)));

        private static void ValidateTransferRates(int transfer) =>
        Validate((Rule: IsInvalid(transfer), Parameter: nameof(TransferRates)));

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidTransferException = new InvalidTransfersException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidTransferException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidTransferException.ThrowIfContainsErrors();
        }
    }
}