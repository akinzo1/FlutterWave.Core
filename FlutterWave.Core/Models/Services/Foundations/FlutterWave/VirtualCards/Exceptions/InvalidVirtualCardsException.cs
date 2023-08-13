using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class InvalidVirtualCardsException : Xeption
    {
        public InvalidVirtualCardsException()
            : base(message: "Invalid VirtualCards error occurred, fix errors and try again.")
        { }

        public InvalidVirtualCardsException(Exception innerException)
            : base(message: "Invalid VirtualCards error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidVirtualCardsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}