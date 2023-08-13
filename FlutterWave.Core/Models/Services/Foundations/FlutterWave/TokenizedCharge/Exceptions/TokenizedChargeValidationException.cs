using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class TokenizedChargeValidationException : Xeption
    {
        public TokenizedChargeValidationException(Xeption innerException)
            : base(message: "TokenizedCharge validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public TokenizedChargeValidationException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}