using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class PreauthorizationServiceException : Xeption
    {
        public PreauthorizationServiceException(Xeption innerException)
            : base(message: "Preauthorization service error occurred, contact support.",
                  innerException)
        { }

        public PreauthorizationServiceException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}