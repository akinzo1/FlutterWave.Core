using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class FailedVirtualCardsServiceException : Xeption
    {
        public FailedVirtualCardsServiceException(Exception innerException)
            : base(message: "Failed VirtualCards service error occurred, contact support.",
                  innerException)
        { }

        public FailedVirtualCardsServiceException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}