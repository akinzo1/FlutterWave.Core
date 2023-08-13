using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class InvalidOtpException : Xeption
    {
        public InvalidOtpException()
            : base(message: "Invalid Otp error occurred, fix errors and try again.")
        { }

        public InvalidOtpException(Exception innerException)
            : base(message: "Invalid Otp error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidOtpException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}