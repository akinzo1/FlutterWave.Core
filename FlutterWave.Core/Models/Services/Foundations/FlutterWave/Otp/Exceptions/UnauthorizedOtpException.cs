using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class UnauthorizedOtpException : Xeption
    {
        public UnauthorizedOtpException(Exception innerException)
            : base(message: "Unauthorized Otp request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedOtpException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}