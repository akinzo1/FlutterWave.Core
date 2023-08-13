using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class InvalidChargeException : Xeption
    {
        public InvalidChargeException()
            : base(message: "Invalid Charge error occurred, fix errors and try again.")
        { }

        public InvalidChargeException(Exception innerException)
            : base(message: "Invalid Charge error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidChargeException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}