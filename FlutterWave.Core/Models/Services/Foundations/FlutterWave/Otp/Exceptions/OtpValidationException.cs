using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class OtpValidationException : Xeption
    {
        public OtpValidationException(Xeption innerException)
            : base(message: "Otp validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public OtpValidationException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}