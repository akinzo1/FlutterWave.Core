using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class InvalidPreauthorizationException : Xeption
    {
        public InvalidPreauthorizationException()
            : base(message: "Invalid Preauthorization error occurred, fix errors and try again.")
        { }

        public InvalidPreauthorizationException(Exception innerException)
            : base(message: "Invalid Preauthorization error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidPreauthorizationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}