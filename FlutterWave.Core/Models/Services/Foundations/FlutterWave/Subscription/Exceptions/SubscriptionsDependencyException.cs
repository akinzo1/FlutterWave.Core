using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class SubscriptionsDependencyException : Xeption
    {
        public SubscriptionsDependencyException(Xeption innerException)
            : base(message: "Subscriptions dependency error occurred, contact support.",
                  innerException)
        { }

        public SubscriptionsDependencyException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}