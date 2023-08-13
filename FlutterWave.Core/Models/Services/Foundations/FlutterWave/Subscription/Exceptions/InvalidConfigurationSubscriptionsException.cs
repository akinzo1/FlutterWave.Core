using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class InvalidConfigurationSubscriptionsException : Xeption
    {
        public InvalidConfigurationSubscriptionsException(Exception innerException)
            : base(message: "Invalid Subscriptions configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationSubscriptionsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}