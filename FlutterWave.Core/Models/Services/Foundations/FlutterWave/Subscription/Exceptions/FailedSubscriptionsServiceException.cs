using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class FailedSubscriptionsServiceException : Xeption
    {
        public FailedSubscriptionsServiceException(Exception innerException)
            : base(message: "Failed Subscription service error occurred, contact support.",
                  innerException)
        { }

        public FailedSubscriptionsServiceException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}