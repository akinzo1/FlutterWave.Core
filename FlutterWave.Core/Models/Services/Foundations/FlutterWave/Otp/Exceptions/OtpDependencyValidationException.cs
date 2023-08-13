using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class OtpDependencyValidationException : Xeption
    {
        public OtpDependencyValidationException(Xeption innerException)
            : base(message: "Otp dependency validation error occurred, contact support.",
                  innerException)
        { }

        public OtpDependencyValidationException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}