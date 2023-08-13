using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class FailedOtpServiceException : Xeption
    {
        public FailedOtpServiceException(Exception innerException)
            : base(message: "Failed Otp service error occurred, contact support.",
                  innerException)
        { }

        public FailedOtpServiceException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}