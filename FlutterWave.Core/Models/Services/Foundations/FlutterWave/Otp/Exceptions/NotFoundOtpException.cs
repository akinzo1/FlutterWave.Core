using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class NotFoundOtpException : Xeption
    {
        public NotFoundOtpException(Exception innerException)
            : base(message: "Not found Otp error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundOtpException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}