using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public partial class NullOtpException : Xeption
    {
        public NullOtpException()
            : base(message: "Otp is null.")
        { }

        public NullOtpException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}
