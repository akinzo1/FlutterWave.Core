using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.VirtualAccountsService
{
    internal partial class VirtualAccountsService
    {


        private static void ValidateCreateVirtualAccount(CreateVirtualAccounts virtualAccounts)
        {
            ValidateCreateVirtualAccountNotNull(virtualAccounts);
            ValidateCreateVirtualAccountRequestNotNull(virtualAccounts.Request);
            Validate(
                (Rule: IsInvalid(virtualAccounts), Parameter: nameof(virtualAccounts)));

            Validate(
                (Rule: IsInvalid(virtualAccounts.Request.PhoneNumber), Parameter: nameof(CreateVirtualAccountRequest.PhoneNumber)),
                (Rule: IsInvalid(virtualAccounts.Request.TxRef), Parameter: nameof(CreateVirtualAccountRequest.TxRef)),
                (Rule: IsInvalid(virtualAccounts.Request.Email), Parameter: nameof(CreateVirtualAccountRequest.Email)),
                (Rule: IsInvalid(virtualAccounts.Request.Bvn), Parameter: nameof(CreateVirtualAccountRequest.Bvn)),
                (Rule: IsInvalid(virtualAccounts.Request.LastName), Parameter: nameof(CreateVirtualAccountRequest.LastName)),
                (Rule: IsInvalid(virtualAccounts.Request.FirstName), Parameter: nameof(CreateVirtualAccountRequest.FirstName)),
                (Rule: IsInvalid(virtualAccounts.Request.Narration), Parameter: nameof(CreateVirtualAccountRequest.Narration))

                );

        }

        private static void ValidateBulkCreateVirtualAccount(BulkCreateVirtualAccounts virtualAccounts)
        {
            ValidateCreateBulkVirtualAccountNotNull(virtualAccounts);
            ValidateBulkCreateVirtualAccountRequestNotNull(virtualAccounts.Request);
            Validate(
                (Rule: IsInvalid(virtualAccounts), Parameter: nameof(virtualAccounts)));

            Validate(
                (Rule: IsInvalid(virtualAccounts.Request.Email), Parameter: nameof(BulkCreateVirtualAccountsRequest.Email)),
                (Rule: IsInvalid(virtualAccounts.Request.TxRef), Parameter: nameof(BulkCreateVirtualAccountsRequest.TxRef)),
                (Rule: IsInvalid(virtualAccounts.Request.Accounts), Parameter: nameof(BulkCreateVirtualAccountsRequest.Accounts))


                );

        }

        private static void ValidateUpdateVirtualAccount(UpdateBvnVirtualAccounts virtualAccounts)
        {
            ValidateUpdateVirtualAccountNotNull(virtualAccounts);
            ValidateUpdateVirtualAccountRequestNotNull(virtualAccounts.Request);


            Validate(
                (Rule: IsInvalid(virtualAccounts), Parameter: nameof(virtualAccounts)));

            Validate(
                (Rule: IsInvalid(virtualAccounts.Request.Bvn), Parameter: nameof(UpdateVirtualAccountBvnRequest.Bvn)));

        }

        private static void ValidateDeleteVirtualAccount(DeleteVirtualAccounts virtualAccounts)
        {
            ValidateDeleteVirtualAccountNotNull(virtualAccounts);
            ValidateDeleteVirtualAccountRequestNotNull(virtualAccounts.Request);


            Validate(
                (Rule: IsInvalid(virtualAccounts), Parameter: nameof(virtualAccounts)));

            Validate(
                (Rule: IsInvalid(virtualAccounts.Request.Status), Parameter: nameof(DeleteVirtualAccountRequest.Status)));

        }

        private static void ValidateBulkCreateVirtualAccountRequestNotNull(BulkCreateVirtualAccountsRequest virtualAccounts)
        {
            Validate((Rule: IsInvalid(virtualAccounts), Parameter: nameof(BulkCreateVirtualAccountsRequest)));
        }
        private static void ValidateCreateVirtualAccountRequestNotNull(CreateVirtualAccountRequest virtualAccounts)
        {
            Validate((Rule: IsInvalid(virtualAccounts), Parameter: nameof(CreateVirtualAccountRequest)));
        }

        private static void ValidateUpdateVirtualAccountRequestNotNull(UpdateVirtualAccountBvnRequest virtualAccounts)
        {
            Validate((Rule: IsInvalid(virtualAccounts), Parameter: nameof(UpdateVirtualAccountBvnRequest)));
        }

        private static void ValidateDeleteVirtualAccountRequestNotNull(DeleteVirtualAccountRequest virtualAccounts)
        {
            Validate((Rule: IsInvalid(virtualAccounts), Parameter: nameof(DeleteVirtualAccountRequest)));
        }
        private static void ValidateCreateVirtualAccountNotNull(CreateVirtualAccounts virtualAccounts)
        {
            if (virtualAccounts is null)
            {
                throw new NullVirtualAccountsException();
            }
        }

        private static void ValidateUpdateVirtualAccountNotNull(UpdateBvnVirtualAccounts virtualAccounts)
        {
            if (virtualAccounts is null)
            {
                throw new NullVirtualAccountsException();
            }
        }

        private static void ValidateDeleteVirtualAccountNotNull(DeleteVirtualAccounts virtualAccounts)
        {
            if (virtualAccounts is null)
            {
                throw new NullVirtualAccountsException();
            }
        }

        private static void ValidateCreateBulkVirtualAccountNotNull(BulkCreateVirtualAccounts virtualAccounts)
        {
            if (virtualAccounts is null)
            {
                throw new NullVirtualAccountsException();
            }
        }

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };

        private static void ValidateFetchVirtualAccountId(string virtualAccountText) =>
            Validate((Rule: IsInvalid(virtualAccountText), Parameter: nameof(FetchVirtualAccounts)));

        private static void ValidateDeleteVirtualAccountId(string virtualAccountText) =>
          Validate((Rule: IsInvalid(virtualAccountText), Parameter: nameof(DeleteVirtualAccounts)));

        private static void ValidateBulkVirtualAccountId(string virtualAccountText) =>
          Validate((Rule: IsInvalid(virtualAccountText), Parameter: nameof(BulkCreateVirtualAccounts)));

        private static void ValidateBulkVirtualAccountDetails(string virtualAccountText) =>
        Validate((Rule: IsInvalid(virtualAccountText), Parameter: nameof(BulkVirtualAccountDetails)));
        private static void ValidateUpdateVirtualAccountId(string virtualAccountInt) =>
            Validate((Rule: IsInvalid(virtualAccountInt), Parameter: nameof(UpdateBvnVirtualAccounts)));

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
            var invalidVirtualAccountException = new InvalidVirtualAccountsException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidVirtualAccountException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidVirtualAccountException.ThrowIfContainsErrors();
        }
    }
}