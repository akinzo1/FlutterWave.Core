using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class TokenizedChargeServiceException : Xeption
    {
        public TokenizedChargeServiceException(Xeption innerException)
            : base(message: "TokenizedCharge service error occurred, contact support.",
                  innerException)
        { }

        public TokenizedChargeServiceException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}