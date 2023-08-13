using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class TokenizedChargeDependencyValidationException : Xeption
    {
        public TokenizedChargeDependencyValidationException(Xeption innerException)
            : base(message: "TokenizedCharge dependency validation error occurred, contact support.",
                  innerException)
        { }

        public TokenizedChargeDependencyValidationException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}