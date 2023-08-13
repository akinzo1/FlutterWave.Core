using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class SubscriptionsDependencyValidationException : Xeption
    {
        public SubscriptionsDependencyValidationException(Xeption innerException)
            : base(message: "Subscriptions dependency validation error occurred, contact support.",
                  innerException)
        { }

        public SubscriptionsDependencyValidationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}