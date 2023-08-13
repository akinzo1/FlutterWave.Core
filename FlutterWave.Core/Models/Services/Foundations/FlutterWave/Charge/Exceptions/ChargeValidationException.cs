using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class ChargeValidationException : Xeption
    {
        public ChargeValidationException(Xeption innerException)
            : base(message: "Charge validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public ChargeValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}