using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class PreauthorizationDependencyException : Xeption
    {
        public PreauthorizationDependencyException(Xeption innerException)
            : base(message: "Preauthorization dependency error occurred, contact support.",
                  innerException)
        { }

        public PreauthorizationDependencyException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}