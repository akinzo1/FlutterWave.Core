using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class InvalidConfigurationChargeException : Xeption
    {
        public InvalidConfigurationChargeException(Exception innerException)
            : base(message: "Invalid Charge configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationChargeException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}