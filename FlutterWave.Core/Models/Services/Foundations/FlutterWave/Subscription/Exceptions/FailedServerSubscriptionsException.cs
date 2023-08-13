using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class FailedServerSubscriptionsException : Xeption
    {
        public FailedServerSubscriptionsException(Exception innerException)
            : base(message: "Failed Subscription server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerSubscriptionsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}