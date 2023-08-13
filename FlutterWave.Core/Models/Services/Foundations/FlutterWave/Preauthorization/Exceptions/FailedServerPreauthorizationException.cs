using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class FailedServerPreauthorizationException : Xeption
    {
        public FailedServerPreauthorizationException(Exception innerException)
            : base(message: "Failed Preauthorization server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerPreauthorizationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}