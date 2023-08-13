using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class NotFoundSubscriptionsException : Xeption
    {
        public NotFoundSubscriptionsException(Exception innerException)
            : base(message: "Not found Subscriptions error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundSubscriptionsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}