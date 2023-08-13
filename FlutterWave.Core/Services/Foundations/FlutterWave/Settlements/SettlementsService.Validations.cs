using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.SettlementsService
{
    internal partial class SettlementsService
    {




        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };

        private static void ValidateSettlementId(string settlementId) =>
            Validate((Rule: IsInvalid(settlementId), Parameter: nameof(Settlement)));

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidAIFileException = new InvalidSettlementsException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidAIFileException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidAIFileException.ThrowIfContainsErrors();
        }
    }
}