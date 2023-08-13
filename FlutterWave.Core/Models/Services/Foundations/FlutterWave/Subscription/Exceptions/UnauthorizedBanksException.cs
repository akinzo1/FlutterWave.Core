using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class UnauthorizedSubscriptionsException : Xeption
    {
        public UnauthorizedSubscriptionsException(Exception innerException)
            : base(message: "Unauthorized Subscriptions request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedSubscriptionsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}