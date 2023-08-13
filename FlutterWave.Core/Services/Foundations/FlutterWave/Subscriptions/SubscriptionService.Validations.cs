using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.SubscriptionService
{
    internal partial class SubscriptionService
    {

        private static void ValidateSubscriptionId(string subscriptionId) =>
           Validate((Rule: IsInvalid(subscriptionId), Parameter: nameof(Subscription)));

        private static void ValidateSubscriptionInt(double subscriptionInt) =>
           Validate(
               (Rule: IsInvalid(subscriptionInt), Parameter: nameof(Subscription))
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
            var invalidSubscriptionException = new InvalidSubscriptionsException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidSubscriptionException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidSubscriptionException.ThrowIfContainsErrors();
        }
    }
}