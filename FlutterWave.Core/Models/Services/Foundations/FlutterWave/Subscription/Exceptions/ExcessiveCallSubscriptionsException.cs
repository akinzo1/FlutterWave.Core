using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class ExcessiveCallSubscriptionsException : Xeption
    {
        public ExcessiveCallSubscriptionsException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallSubscriptionsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}