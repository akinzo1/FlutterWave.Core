using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class FailedServerChargeException : Xeption
    {
        public FailedServerChargeException(Exception innerException)
            : base(message: "Failed Charge server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerChargeException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}