using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class OtpServiceException : Xeption
    {
        public OtpServiceException(Xeption innerException)
            : base(message: "Otp service error occurred, contact support.",
                  innerException)
        { }

        public OtpServiceException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}