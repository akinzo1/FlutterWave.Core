using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc
{
    public class FailedMiscServiceException : Xeption
    {
        public FailedMiscServiceException(Exception innerException)
            : base(message: "Failed Misc service error occurred, contact support.",
                  innerException)
        { }

        public FailedMiscServiceException(string message, Exception innerException)
          : base(message: message, innerException)
        { }
    }
}