using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class SubscriptionsValidationException : Xeption
    {
        public SubscriptionsValidationException(Xeption innerException)
            : base(message: "Subscriptions validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public SubscriptionsValidationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}