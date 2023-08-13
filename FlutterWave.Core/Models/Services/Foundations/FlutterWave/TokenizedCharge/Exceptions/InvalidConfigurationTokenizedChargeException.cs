using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class InvalidConfigurationTokenizedChargeException : Xeption
    {
        public InvalidConfigurationTokenizedChargeException(Exception innerException)
            : base(message: "Invalid TokenizedCharge configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationTokenizedChargeException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}