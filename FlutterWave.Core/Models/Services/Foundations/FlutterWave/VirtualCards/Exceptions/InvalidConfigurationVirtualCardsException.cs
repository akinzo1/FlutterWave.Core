using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class InvalidConfigurationVirtualCardsException : Xeption
    {
        public InvalidConfigurationVirtualCardsException(Exception innerException)
            : base(message: "Invalid VirtualCards configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationVirtualCardsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}