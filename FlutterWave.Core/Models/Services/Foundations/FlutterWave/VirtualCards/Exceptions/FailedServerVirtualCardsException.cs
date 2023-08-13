using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class FailedServerVirtualCardsException : Xeption
    {
        public FailedServerVirtualCardsException(Exception innerException)
            : base(message: "Failed VirtualCards server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerVirtualCardsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}