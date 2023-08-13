using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.MiscService
{
    internal partial class MiscellaneousService
    {
        private static void ValidateBankAccountVerification(BankAccountVerification bankAccountVerification)
        {
            ValidateBankAccountVerificationNotNull(bankAccountVerification);
            ValidateBankAccountVerificationRequestNotNull(bankAccountVerification.Request);
            Validate(
                (Rule: IsInvalid(bankAccountVerification.Request), Parameter: nameof(BankAccountVerification)));

            Validate(
                (Rule: IsInvalid(bankAccountVerification.Request.AccountNumber), Parameter: nameof(BankAccountVerificationRequest.AccountNumber)),
                (Rule: IsInvalid(bankAccountVerification.Request.AccountBank), Parameter: nameof(BankAccountVerificationRequest.AccountBank))
                );

        }


        private static void ValidateBvnConsent(BvnConsent bvnConsent)
        {
            ValidateBvnConsentNotNull(bvnConsent);
            ValidateBvnConsentRequestNotNull(bvnConsent.Request);
            Validate(
                (Rule: IsInvalid(bvnConsent.Request), Parameter: nameof(bvnConsent.Request)));

            Validate(
                (Rule: IsInvalid(bvnConsent.Request.Bvn), Parameter: nameof(BvnConsentRequest.Bvn)),
                (Rule: IsInvalid(bvnConsent.Request.FirstName), Parameter: nameof(BvnConsentRequest.FirstName)),
                (Rule: IsInvalid(bvnConsent.Request.LastName), Parameter: nameof(BvnConsentRequest.LastName)),
                 (Rule: IsInvalid(bvnConsent.Request.RedirectUrl), Parameter: nameof(BvnConsentRequest.RedirectUrl))
                );

        }


        private static void ValidateBankAccountVerificationNotNull(BankAccountVerification bankAccountVerification)
        {
            if (bankAccountVerification is null)
            {
                throw new NullMiscellaneousException();
            }
        }

        private static void ValidateBvnConsentRequestNotNull(BvnConsentRequest request)
        {
            Validate(
                (Rule: IsInvalid(request), Parameter: nameof(BvnConsentRequest)));
        }
        private static void ValidateBankAccountVerificationRequestNotNull(BankAccountVerificationRequest request)
        {
            Validate(
                (Rule: IsInvalid(request), Parameter: nameof(BankAccountVerificationRequest)));
        }

        private static void ValidateBvnConsentNotNull(BvnConsent bvnConsent)
        {
            if (bvnConsent is null)
            {
                throw new NullMiscellaneousException();
            }
        }


        private static void ValidateBalanceCurrency(string currency) =>
            Validate((Rule: IsInvalid(currency), Parameter: nameof(BalanceByCurrency)));

        private static void ValidateCardBin(string bin) =>
          Validate((Rule: IsInvalid(bin), Parameter: nameof(BinVerification)));

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
            var invalidMiscException = new InvalidMiscellaneousException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidMiscException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidMiscException.ThrowIfContainsErrors();
        }
    }
}