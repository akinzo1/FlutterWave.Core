using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class UnauthorizedPreauthorizationException : Xeption
    {
        public UnauthorizedPreauthorizationException(Exception innerException)
            : base(message: "Unauthorized Preauthorization request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedPreauthorizationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}