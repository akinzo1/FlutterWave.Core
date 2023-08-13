using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack
{
    public class InvalidChargeBackException : Xeption
    {
        public InvalidChargeBackException()
            : base(message: "Invalid ChargeBack error occurred, fix errors and try again.")
        { }

        public InvalidChargeBackException(Exception innerException)
            : base(message: "Invalid ChargeBack error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidChargeBackException(string message, Exception innerException)
        : base(message: message,
              innerException)
        { }
    }
}