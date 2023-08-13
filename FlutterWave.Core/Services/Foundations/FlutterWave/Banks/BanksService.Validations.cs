using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.BanksService
{
    internal partial class BanksService
    {
        private static void ValidateBankCountryCode(string text) =>
           Validate((Rule: IsInvalid(text), Parameter: nameof(Bank)));
        private static void ValidateBankBranchesBankCode(int text) =>
          Validate((Rule: IsInvalid(text), Parameter: nameof(BankBranches)));

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

        private static dynamic IsInvalid(int number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidBankException = new InvalidBanksException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidBankException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidBankException.ThrowIfContainsErrors();
        }
    }
}