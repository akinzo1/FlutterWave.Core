using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class VirtualCardsServiceException : Xeption
    {
        public VirtualCardsServiceException(Xeption innerException)
            : base(message: "VirtualCards service error occurred, contact support.",
                  innerException)
        { }

        public VirtualCardsServiceException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}