using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class InvalidSubscriptionsException : Xeption
    {
        public InvalidSubscriptionsException()
            : base(message: "Invalid Subscriptions error occurred, fix errors and try again.")
        { }

        public InvalidSubscriptionsException(Exception innerException)
            : base(message: "Invalid Subscriptions error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidSubscriptionsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}