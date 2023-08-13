using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class FailedChargeServiceException : Xeption
    {
        public FailedChargeServiceException(Exception innerException)
            : base(message: "Failed Charge service error occurred, contact support.",
                  innerException)
        { }

        public FailedChargeServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}