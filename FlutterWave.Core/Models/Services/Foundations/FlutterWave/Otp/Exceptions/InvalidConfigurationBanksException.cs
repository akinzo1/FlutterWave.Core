using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class InvalidConfigurationOtpException : Xeption
    {
        public InvalidConfigurationOtpException(Exception innerException)
            : base(message: "Invalid Otp configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationOtpException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}