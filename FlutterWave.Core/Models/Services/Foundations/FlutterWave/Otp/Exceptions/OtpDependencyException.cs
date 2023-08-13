using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class OtpDependencyException : Xeption
    {
        public OtpDependencyException(Xeption innerException)
            : base(message: "Otp dependency error occurred, contact support.",
                  innerException)
        { }

        public OtpDependencyException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}