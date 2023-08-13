using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack
{
    public class FailedChargeBackServiceException : Xeption
    {
        public FailedChargeBackServiceException(Exception innerException)
            : base(message: "Failed ChargeBack service error occurred, contact support.",
                  innerException)
        { }

        public FailedChargeBackServiceException(string message, Exception innerException)
        : base(message: message,
              innerException)
        { }
    }
}