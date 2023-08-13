using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public partial class NullSubscriptionsException : Xeption
    {
        public NullSubscriptionsException()
            : base(message: "Subscriptions is null.")
        { }

        public NullSubscriptionsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}
