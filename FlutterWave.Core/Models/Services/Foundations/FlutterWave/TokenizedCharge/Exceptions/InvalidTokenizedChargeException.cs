using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class InvalidTokenizedChargeException : Xeption
    {
        public InvalidTokenizedChargeException()
            : base(message: "Invalid TokenizedCharge error occurred, fix errors and try again.")
        { }

        public InvalidTokenizedChargeException(Exception innerException)
            : base(message: "Invalid TokenizedCharge error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidTokenizedChargeException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}