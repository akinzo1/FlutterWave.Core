using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class PreauthorizationValidationException : Xeption
    {
        public PreauthorizationValidationException(Xeption innerException)
            : base(message: "Preauthorization validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public PreauthorizationValidationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}