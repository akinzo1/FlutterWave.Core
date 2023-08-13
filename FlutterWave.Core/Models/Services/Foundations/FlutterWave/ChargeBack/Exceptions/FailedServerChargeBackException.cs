using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack
{
    public class FailedServerChargeBackException : Xeption
    {
        public FailedServerChargeBackException(Exception innerException)
            : base(message: "Failed ChargeBack server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerChargeBackException(string message, Exception innerException)
        : base(message: message,
              innerException)
        { }
    }
}