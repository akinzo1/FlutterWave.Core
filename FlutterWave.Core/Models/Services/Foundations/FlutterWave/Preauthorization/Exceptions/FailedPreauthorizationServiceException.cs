using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class FailedPreauthorizationServiceException : Xeption
    {
        public FailedPreauthorizationServiceException(Exception innerException)
            : base(message: "Failed Preauthorization service error occurred, contact support.",
                  innerException)
        { }

        public FailedPreauthorizationServiceException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}