using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class ExcessiveCallOtpException : Xeption
    {
        public ExcessiveCallOtpException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallOtpException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}