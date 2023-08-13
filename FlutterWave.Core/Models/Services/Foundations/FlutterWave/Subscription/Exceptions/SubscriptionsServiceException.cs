using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class SubscriptionsServiceException : Xeption
    {
        public SubscriptionsServiceException(Xeption innerException)
            : base(message: "Subscriptions service error occurred, contact support.",
                  innerException)
        { }

        public SubscriptionsServiceException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}