using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class FailedServerTokenizedChargeException : Xeption
    {
        public FailedServerTokenizedChargeException(Exception innerException)
            : base(message: "Failed TokenizedCharge server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerTokenizedChargeException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}