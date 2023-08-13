using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class InvalidConfigurationPreauthorizationException : Xeption
    {
        public InvalidConfigurationPreauthorizationException(Exception innerException)
            : base(message: "Invalid Preauthorization configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationPreauthorizationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}