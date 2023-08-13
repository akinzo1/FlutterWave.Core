using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class FailedServerOtpException : Xeption
    {
        public FailedServerOtpException(Exception innerException)
            : base(message: "Failed Otp server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerOtpException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}