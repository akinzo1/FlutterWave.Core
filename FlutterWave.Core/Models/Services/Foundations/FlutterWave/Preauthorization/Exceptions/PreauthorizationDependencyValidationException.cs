using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class PreauthorizationDependencyValidationException : Xeption
    {
        public PreauthorizationDependencyValidationException(Xeption innerException)
            : base(message: "Preauthorization dependency validation error occurred, contact support.",
                  innerException)
        { }

        public PreauthorizationDependencyValidationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}