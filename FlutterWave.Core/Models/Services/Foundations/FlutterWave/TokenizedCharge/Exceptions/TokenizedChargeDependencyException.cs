using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class TokenizedChargeDependencyException : Xeption
    {
        public TokenizedChargeDependencyException(Xeption innerException)
            : base(message: "TokenizedCharge dependency error occurred, contact support.",
                  innerException)
        { }

        public TokenizedChargeDependencyException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}