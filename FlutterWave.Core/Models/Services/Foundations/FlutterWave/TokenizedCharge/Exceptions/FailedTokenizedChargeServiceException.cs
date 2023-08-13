using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class FailedTokenizedChargeServiceException : Xeption
    {
        public FailedTokenizedChargeServiceException(Exception innerException)
            : base(message: "Failed TokenizedCharge service error occurred, contact support.",
                  innerException)
        { }

        public FailedTokenizedChargeServiceException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}