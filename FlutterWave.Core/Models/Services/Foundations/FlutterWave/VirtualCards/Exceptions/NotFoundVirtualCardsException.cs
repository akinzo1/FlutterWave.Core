using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class NotFoundVirtualCardsException : Xeption
    {
        public NotFoundVirtualCardsException(Exception innerException)
            : base(message: "Not found VirtualCards error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundVirtualCardsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}