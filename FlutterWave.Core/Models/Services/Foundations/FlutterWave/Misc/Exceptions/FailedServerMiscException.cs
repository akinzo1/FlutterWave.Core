using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc
{
    public class FailedServerMiscException : Xeption
    {
        public FailedServerMiscException(Exception innerException)
            : base(message: "Failed Misc server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerMiscException(string message, Exception innerException)
          : base(message: message, innerException)
        { }
    }
}